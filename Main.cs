﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AppliPhoto
{
    public partial class Main : Form
    {
        private List<ImageData> mosaic = new List<ImageData>();
        private PictureBox clone;
        private int indexCloneInMosaic = -1;
        private PictureBox leftArrow, rightArrow;

        private const string tempFileName = @"C:\monApplicationPhoto\Images\@@@temp@@@.jpg";
        private const string localImageDirectory = @"c:\monApplicationPhoto\Images\";
        private const string metadataStore = @"c:\monApplicationPhoto\Images\metadata.json";

        enum eCommentActionType { Add, Delete }

        public Main()
        {
            Application.ApplicationExit += new EventHandler(serializeToJSON);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ClearTemporaryImages();
            DossierImage.CreateFolder();

            clone = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.None
            };
            soloImageLayout.Controls.Add(clone);

            leftArrow = new PictureBox();

            leftArrow.Image = new Bitmap(@"asset\left_arrow.png");
            leftArrow.SizeMode = PictureBoxSizeMode.Zoom;
            leftArrow.Anchor = AnchorStyles.Left;
            
            leftArrow.MouseClick += new MouseEventHandler(LeftImageButton_Click);
            leftArrow.Location = new Point(0, (soloImageLayout.Height - leftArrow.Height) / 4);

            rightArrow = new PictureBox
            {
                Image = new Bitmap(@"asset\right_arrow.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Right,
            };
            rightArrow.MouseClick += new MouseEventHandler(RightImageButton_Click);
            rightArrow.Location = new Point(soloImageLayout.Width - rightArrow.Width, (soloImageLayout.Height - leftArrow.Height) / 4);

            soloImageLayout.Controls.Add(leftArrow);
            soloImageLayout.Controls.Add(rightArrow);

            loadAllImportedImageMetadata();

            foreach (var picture in mosaic)
            {
                var fileName = picture.fileName;
                if (fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                 || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                 || fileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                 || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    SetAndAddPictureToMosaicLayout(fileName);
                }
            }

            test();
        }

        private void test()
        {
            //var blaise = @"C:\monApplicationPhoto\Images\blaise_pascal.jpg";

            for (int i = 0; i < 10; i++)
            {
                string content;

                if (i % 3 == 0)
                    content = "Salut je suis un tag n°1";
                else if (i % 3 == 1)
                    content = "Coucou je suis n°2";
                else
                    content = "prout prout";

                Tag c = new Tag(new Button { Text = "X" }, content, this);
                tagPanel.Controls.Add(c);
            }
        }

        private void ErasePictureFromApplication(string fileName)
        {
            mosaicLayout.Controls.Clear();
            mosaic.Remove(mosaic.First(s => s.fileName.Equals(fileName)));
            foreach (var picture in mosaic)
                SetAndAddPictureToMosaicLayout(picture.fileName);
        }

        private void ClearTemporaryImages()
        {
            if (File.Exists(tempFileName))
                File.Delete(tempFileName);
        }

        public void SetAndAddPictureToMosaicLayout(string fileName)
        {
            PictureBox picture = new PictureBox
            {
                Width = mosaicLayout.Width / 5,
                Height = 100,
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = fileName
            };

            picture.MouseClick += new MouseEventHandler(pictureClickEvent);
            mosaicLayout.Controls.Add(picture);
        }

        public void AddTag( string tag )
        {
            mosaic[indexCloneInMosaic].AddTag(tag);
        }

        public void DeleteTag( string tag )
        {
            mosaic[indexCloneInMosaic].DeleteTag(tag);
        }

        public void Modifytag( string newTag, string oldTag)
        {
            mosaic[indexCloneInMosaic].ModifyTagList(newTag, oldTag);
        }

        private List<ImageData> seekTagThroughMosaic(List<string> tagsToFind, List<string> tagsToAvoid)
        {
            var res = new List<ImageData>();

            foreach (var tagName in tagsToFind)
            {
                res = mosaic.Where(p => p.tags.Any(tag => tag.Equals(tagName))).ToList();
            }

            foreach (var r in res)
                foreach (var tagName in tagsToAvoid)
                    if (r.tags.Contains(tagName))
                        res.Remove(r);

            //foreach( var imageData in mosaic )
            //    foreach ( var acceptedTag in tagsToFind )
            //        foreach( var refusedTag in tagsToAvoid )
            //            if ( imageData.tags.Contains( acceptedTag ) && !imageData.tags.Contains( refusedTag ) )
            //                res.Add(imageData.fileName);

            return res;
        }

        private List<String> readTagsOfPicture(string fileName)
        {
            return mosaic.First(imageData => imageData.fileName.Equals(fileName)).tags;
        }

        private void pictureClickEvent(object sender, EventArgs e)
        {
            var picturePath = ((PictureBox)sender).ImageLocation;
            indexCloneInMosaic = mosaic.IndexOf(mosaic.Find(delegate (ImageData im) { return im.fileName.Equals(picturePath, StringComparison.OrdinalIgnoreCase); }));
            //var indexCloneInMosaic = mosaic.IndexOf( mosaic.First( s => s.fileName.Equals( picturePath, StringComparison.OrdinalIgnoreCase ) ) );

            clone.ImageLocation = picturePath;
            clone.Width = soloImageLayout.Width / 2;
            clone.Height = soloImageLayout.Height / 2;
            clone.Location = new Point((soloImageLayout.Width - clone.Width) / 2, 0);
        }

        private void loadAllImportedImageMetadata()
        {
            if (File.Exists(metadataStore))
            {
                using (var file = File.OpenText(metadataStore))
                {
                    var serializer = new JsonSerializer();
                    mosaic = (List<ImageData>)serializer.Deserialize(file, typeof(List<ImageData>));
                }
                if (mosaic == null)
                    mosaic = new List<ImageData>();
            }
            else
            {

            }
        }

        private void LeftImageButton_Click(object sender, EventArgs e)
        {
            if (indexCloneInMosaic == -1)
                return;
            if (indexCloneInMosaic == 0)
                indexCloneInMosaic = mosaic.Count - 1;
            else
                indexCloneInMosaic -= 1;

            clone.ImageLocation = mosaic[indexCloneInMosaic].fileName;

        }

        private void RightImageButton_Click(object sender, EventArgs e)
        {
            if (indexCloneInMosaic == -1)
                return;
            if (indexCloneInMosaic == mosaic.Count - 1)
                indexCloneInMosaic = 0;
            else
                indexCloneInMosaic += 1;

            clone.ImageLocation = mosaic[indexCloneInMosaic].fileName;
        }

        private void imageImport(object sender, EventArgs e)
        {
            using (var FileSelector = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp|All files (*.*)|*.*"
            })
            {
                if (FileSelector.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in FileSelector.FileNames)
                    {
                        var destination = localImageDirectory + Path.GetFileName(fileName);
                        if (!File.Exists(destination))
                        {
                            File.Copy(fileName, destination);
                            SetAndAddPictureToMosaicLayout(destination);

                            var imageData = new ImageData(destination, new List<String>());
                            mosaic.Add(imageData);
                        }
                    }
                }
            }
        }

        private void directoryImport(object sender, EventArgs e)
        {
            using (var browserSelector = new FolderBrowserDialog())
            {
                DialogResult result = browserSelector.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(browserSelector.SelectedPath))
                {
                    var files = Directory.GetFiles(browserSelector.SelectedPath, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                                                                                                                             || s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                                                                                                                             || s.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                                                                                                                             || s.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToArray();
                    var importedFiles = 0;
                    foreach (var fileName in files)
                    {
                        var destination = localImageDirectory + Path.GetFileName(fileName);
                        if (!File.Exists(destination))
                        {
                            File.Copy(fileName, destination);
                            SetAndAddPictureToMosaicLayout(destination);
                            ++importedFiles;

                            var imageData = new ImageData(destination, new List<String>());
                            mosaic.Add(imageData);
                        }
                    }

                    MessageBox.Show("Nombre de fichiers importés : " + importedFiles.ToString() + " sur un total de " + files.Length.ToString() + " trouvés.", "Rapport");
                }
            }
        }

        private void serializeToJSON(object sender, EventArgs e)
        {
            using (var file = File.CreateText(metadataStore))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mosaic);
            }
        }
    }
}
