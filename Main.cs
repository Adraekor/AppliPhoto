using Newtonsoft.Json;
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
        private PictureBox ImageToBeDeleted;
        private int indexCloneInMosaic = -1;
        private Button AddTagToPicture;

        private const string tempFileName = @"C:\monApplicationPhoto\Images\@@@temp@@@.jpg";
        private const string localImageDirectory = @"c:\monApplicationPhoto\Images\";
        private const string metadataStore = @"c:\monApplicationPhoto\Images\metadata.json";

        public Main()
        {
            Application.ApplicationExit += new EventHandler(SerializeToJSON);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadAllImportedImageMetadata();

            ClearTemporaryImages();
            DossierImage.CreateFolder();

            AddTagToPicture = new Button
            {
                Text = "+",
                Width = 20,
                Height = 20
            };
            AddTagToPicture.Click += AddTagButton;

            clone = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.None
            };
            soloImageLayout.Controls.Add(clone);

            var leftArrow = new PictureBox
            {
                Image = new Bitmap(@"asset\left_arrow.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Left
            };
            leftArrow.MouseClick += new MouseEventHandler(LeftImageButton_Click);
            leftArrow.Location = new Point(0, (soloImageLayout.Height - leftArrow.Height) / 4);

            var rightArrow = new PictureBox
            {
                Image = new Bitmap(@"asset\right_arrow.png"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Right,
            };
            rightArrow.MouseClick += new MouseEventHandler(RightImageButton_Click);
            rightArrow.Location = new Point(soloImageLayout.Width - rightArrow.Width, (soloImageLayout.Height - leftArrow.Height) / 4);

            soloImageLayout.Controls.Add(leftArrow);
            soloImageLayout.Controls.Add(rightArrow);


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

            //test();
        }
        private void test()
        {
            //var blaise = @"C:\monApplicationPhoto\Images\blaise_pascal.jpg";

        }

        public void ModifyTag( string newTag, string oldTag )
        {
            mosaic[indexCloneInMosaic].ModifyTagList(newTag, oldTag);
        }

        private void AddTagButton(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Veuillez entrer le nom du tag à ajouter", "Ajout d'un tag");
            if (promptValue.Trim() != "")
            {
                var c = new Tag(promptValue, this);
                tagPanel.Controls.Remove(AddTagToPicture);
                tagPanel.Controls.Add(c);
                tagPanel.Controls.Add(AddTagToPicture);
            }
        }

        private void ErasePictureFromApplication()
        {
            var fileName = ImageToBeDeleted.ImageLocation;
            ImageToBeDeleted.Dispose();
            mosaic.Remove(mosaic.First(s => s.fileName.Equals(fileName)));
        }

        private void ShowRightClickMenu()
        {

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

            picture.MouseClick += new MouseEventHandler(PictureClickEvent);
            mosaicLayout.Controls.Add(picture);
        }

        private List<ImageData> SeekTagThroughMosaic(List<string> tagsToFind, List<string> tagsToAvoid)
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

        private void PictureClickEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateTags();

                var picturePath = ((PictureBox)sender).ImageLocation;
                indexCloneInMosaic = mosaic.IndexOf(mosaic.First(s => s.fileName.Equals(picturePath, StringComparison.OrdinalIgnoreCase)));

                clone.ImageLocation = picturePath;
                clone.Width = soloImageLayout.Width / 2;
                clone.Height = 3 * soloImageLayout.Height / 4;
                clone.Location = new Point((soloImageLayout.Width - clone.Width) / 2, 0);

                LoadPictureTags();
            }
            else if (e.Button == MouseButtons.Right)
            {
                ImageToBeDeleted = (PictureBox)sender;
                ShowRightClickMenu();
            }
        }

        private void LoadPictureTags()
        {
            tagPanel.Controls.Clear();
            foreach ( var tag in mosaic[ indexCloneInMosaic ].tags )
                tagPanel.Controls.Add( new Tag( tag, this ) );

            tagPanel.Controls.Add(AddTagToPicture);
        }

        private void LoadAllImportedImageMetadata()
        {
            if (File.Exists(metadataStore))
            {
                using (var file = File.OpenText(metadataStore))
                {
                    var serializer = new JsonSerializer();
                    mosaic = (List<ImageData>)serializer.Deserialize(file, typeof(List<ImageData>));
                }
            }
            if (mosaic == null)
                mosaic = new List<ImageData>();
        }

        private void UpdateTags()
        {
            if (indexCloneInMosaic != -1)
            {
                mosaic[indexCloneInMosaic].tags.Clear();
                for( var i = 0; i < tagPanel.Controls.Count - 1; ++i )
                {
                    var tag = (Tag) tagPanel.Controls[i];
                    if (!mosaic[indexCloneInMosaic].tags.Contains(tag.mTextBox.Text.Trim()))
                        mosaic[indexCloneInMosaic].tags.Add(tag.mTextBox.Text.Trim());
                }
            }
        }

        private void LeftImageButton_Click(object sender, EventArgs e)
        {
            UpdateTags();

            if (indexCloneInMosaic == -1)
                return;
            if (indexCloneInMosaic == 0)
                indexCloneInMosaic = mosaic.Count - 1;
            else
                indexCloneInMosaic -= 1;

            clone.ImageLocation = mosaic[indexCloneInMosaic].fileName;
            LoadPictureTags();
        }

        private void RightImageButton_Click(object sender, EventArgs e)
        {
            UpdateTags();

            if (indexCloneInMosaic == -1)
                return;
            if (indexCloneInMosaic == mosaic.Count - 1)
                indexCloneInMosaic = 0;
            else
                indexCloneInMosaic += 1;

            clone.ImageLocation = mosaic[indexCloneInMosaic].fileName;
            LoadPictureTags();
        }

        private void ImageImport(object sender, EventArgs e)
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

        private void DirectoryImport(object sender, EventArgs e)
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

        private void SerializeToJSON(object sender, EventArgs e)
        {
            using (var file = File.CreateText(metadataStore))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mosaic);
            }
        }
    }
}
