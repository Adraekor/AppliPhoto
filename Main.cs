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
        private List<ImageData> mMosaic = new List<ImageData>();
        private PictureBox mClone;
        private PictureBox mImageToBeDeleted;
        private PictureBox mLastSelectedPicture;
        private int mIndexCloneInMosaic = -1;
        private Button mAddTagToPicture;
        private List<PictureBox> mSelectedItems = new List<PictureBox>();

        private List<String> tag_recherches = new List<string>();
        private List<String> tag_retirer = new List<string>();

        private const string kmTempFileName = @"C:\monApplicationPhoto\Images\@@@temp@@@.jpg";
        private const string kmLocalImageDirectory = @"c:\monApplicationPhoto\Images\";
        private const string kmMetadataStore = @"c:\monApplicationPhoto\Images\metadata.json";

        public Main()
        {
            Application.ApplicationExit += new EventHandler(SerializeToJSON);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mLastSelectedPicture = new PictureBox();

            LoadAllImportedImageMetadata();

            ClearTemporaryImages();
            DossierImage.CreateFolder();

            mAddTagToPicture = new Button
            {
                Text = "+",
                Width = 20,
                Height = 20
            };
            mAddTagToPicture.Click += AddTagButton;

            mClone = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.None
            };
            soloImageLayout.Controls.Add(mClone);

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

            foreach (var picture in mMosaic)
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
            mMosaic[mIndexCloneInMosaic].ModifyTagList(newTag, oldTag);
        }

        public void DeleteTag(string tag)
        {
            if(mIndexCloneInMosaic != -1)
                mMosaic[mIndexCloneInMosaic].DeleteTag(tag);
            // a mettre dans une autres fonction si possible
            tag_recherches.Remove(tag);
            tag_retirer.Remove(tag);
        }

        public void AddTag(string tag)
        {
            mMosaic[mIndexCloneInMosaic].AddTag(tag);
        }

        private void AddTagButton(object sender, EventArgs e)
        {
            var promptValue = Prompt.ShowDialog("Veuillez entrer le nom du tag à ajouter", "Ajout d'un tag");
            if (promptValue.Trim() != "")
            {
                mMosaic[mIndexCloneInMosaic].AddTag(promptValue);
                var c = new Tag(promptValue, this);
                tagPanel.Controls.Remove(mAddTagToPicture);
                tagPanel.Controls.Add(c);
                tagPanel.Controls.Add(mAddTagToPicture);
            }
        }

        private void ErasePictureFromApplication()
        {
            var fileName = mImageToBeDeleted.ImageLocation;
            mImageToBeDeleted.Dispose();
            mMosaic.Remove(mMosaic.First(s => s.fileName.Equals(fileName)));
        }

        private void ShowRightClickMenu()
        {

        }

        private void ClearTemporaryImages()
        {
            if (File.Exists(kmTempFileName))
                File.Delete(kmTempFileName);
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

            picture.MouseClick += new MouseEventHandler(PictureClick);
            mosaicLayout.Controls.Add(picture);
        }

        private List<ImageData> SeekTagThroughMosaic(List<string> tagsToFind, List<string> tagsToAvoid)
        {
            var res = new List<ImageData>();

            foreach (var tagName in tagsToFind)
            {
                res = mMosaic.Where(p => p.tags.Any(tag => tag.Equals(tagName))).ToList();
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

        private void PictureClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var currentPicture = ((PictureBox)sender);
                var picturePath = currentPicture.ImageLocation;
                currentPicture.BorderStyle = BorderStyle.FixedSingle;

                if (ModifierKeys == Keys.Control)
                {
                    if (mSelectedItems.Count == 1)
                        UpdateTags();
                    mSelectedItems.Add(currentPicture);
                    mLastSelectedPicture = currentPicture;
                    tagPanel.Controls.Clear();
                }
                else
                {
                    if(mSelectedItems.Count == 1)
                        UpdateTags();
                    mIndexCloneInMosaic = mMosaic.IndexOf(mMosaic.First(s => s.fileName.Equals(picturePath, StringComparison.OrdinalIgnoreCase)));
                    foreach ( var i in mSelectedItems )
                    {
                        i.BorderStyle = BorderStyle.None;
                    }
                    mSelectedItems.Clear();
                    mLastSelectedPicture.BorderStyle = BorderStyle.None;
                    mLastSelectedPicture = currentPicture;
                    mSelectedItems.Add(currentPicture);
                    currentPicture.BorderStyle = BorderStyle.FixedSingle;

                    LoadPictureTags();
                    mClone.ImageLocation = picturePath;
                    mClone.Width = soloImageLayout.Width / 2;
                    mClone.Height = 3 * soloImageLayout.Height / 4;
                    mClone.Location = new Point((soloImageLayout.Width - mClone.Width) / 2, 0);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                mImageToBeDeleted = (PictureBox)sender;
                ShowRightClickMenu();
            }
        }

        private void LoadPictureTags()
        {
            tagPanel.Controls.Clear();
            foreach ( var tag in mMosaic[ mIndexCloneInMosaic ].tags )
                tagPanel.Controls.Add( new Tag( tag, this ) );

            tagPanel.Controls.Add(mAddTagToPicture);
        }

        private void LoadAllImportedImageMetadata()
        {
            if (File.Exists(kmMetadataStore))
            {
                using (var file = File.OpenText(kmMetadataStore))
                {
                    var serializer = new JsonSerializer();
                    mMosaic = (List<ImageData>)serializer.Deserialize(file, typeof(List<ImageData>));
                }
            }
            if (mMosaic == null)
                mMosaic = new List<ImageData>();
        }

        private void UpdateTags()
        {
            if (mIndexCloneInMosaic != -1)
            {
                mMosaic[mIndexCloneInMosaic].tags.Clear();
                for( var i = 0; i < tagPanel.Controls.Count - 1; ++i )
                {
                    var tag = (Tag) tagPanel.Controls[i];
                    if (!mMosaic[mIndexCloneInMosaic].tags.Contains(tag.mTextBox.Text.Trim()))
                        mMosaic[mIndexCloneInMosaic].tags.Add(tag.mTextBox.Text.Trim());
                }
            }
        }

        private void LeftImageButton_Click(object sender, EventArgs e)
        {
            UpdateTags();

            if (mIndexCloneInMosaic == -1)
                return;
            if (mIndexCloneInMosaic == 0)
                mIndexCloneInMosaic = mMosaic.Count - 1;
            else
                mIndexCloneInMosaic -= 1;

            mClone.ImageLocation = mMosaic[mIndexCloneInMosaic].fileName;

            LoadPictureTags();
        }

        private void RightImageButton_Click(object sender, EventArgs e)
        {
            UpdateTags();

            if (mIndexCloneInMosaic == -1)
                return;
            if (mIndexCloneInMosaic == mMosaic.Count - 1)
                mIndexCloneInMosaic = 0;
            else
                mIndexCloneInMosaic += 1;

            mClone.ImageLocation = mMosaic[mIndexCloneInMosaic].fileName;
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
                        var destination = kmLocalImageDirectory + Path.GetFileName(fileName);
                        if (!File.Exists(destination))
                        {
                            File.Copy(fileName, destination);
                            SetAndAddPictureToMosaicLayout(destination);

                            var imageData = new ImageData(destination, new List<String>());
                            mMosaic.Add(imageData);
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
                        var destination = kmLocalImageDirectory + Path.GetFileName(fileName);
                        if (!File.Exists(destination))
                        {
                            File.Copy(fileName, destination);
                            SetAndAddPictureToMosaicLayout(destination);
                            ++importedFiles;

                            var imageData = new ImageData(destination, new List<String>());
                            mMosaic.Add(imageData);
                        }
                    }

                    MessageBox.Show("Nombre de fichiers importés : " + importedFiles.ToString() + " sur un total de " + files.Length.ToString() + " trouvés.", "Rapport");
                }
            }
        }

        private void SerializeToJSON(object sender, EventArgs e)
        {
            using (var file = File.CreateText(kmMetadataStore))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mMosaic);
            }
        }

        private void button_Recherche_Click(object sender, EventArgs e)
        {
            if(textBox_recherche.Text != "" && !tag_recherches.Contains(textBox_recherche.Text))
                tag_recherches.Add(textBox_recherche.Text);
            if (tag_retirer.Contains(textBox_recherche.Text))
                tag_retirer.Remove(textBox_recherche.Text);

            update_liste_recherche();
            
        }

        private void update_liste_recherche()
        {
            flowLayoutPanel_recherche.Controls.Clear();
            foreach (string tag in tag_recherches)
            {
                var lab = new Tag(tag, this);
       
                flowLayoutPanel_recherche.Controls.Add(lab);
            }
            textBox_recherche.Text = "";
            flowLayoutPanel_retirer.Controls.Clear();
            foreach (string tag in tag_retirer)
            {
                var lab = new Tag(tag, this);

                flowLayoutPanel_retirer.Controls.Add(lab);
            }
            textBox_retirer.Text = "";
        }

        private void button_retirer_Click(object sender, EventArgs e)
        {
            if (textBox_retirer.Text != "" && !tag_retirer.Contains(textBox_retirer.Text))
                tag_retirer.Add(textBox_retirer.Text);
            if (tag_recherches.Contains(textBox_retirer.Text))
                tag_recherches.Remove(textBox_retirer.Text);

            update_liste_recherche();
        }
    }
}
