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

        private List<Tag> mTagList;
        private TreeView mTagTree = new TreeView();

        private const string kmTempFileName = @"C:\monApplicationPhoto\Images\@@@temp@@@.jpg";
        private const string kmLocalImageDirectory = @"c:\monApplicationPhoto\Images\";
        private const string kmMetadataStore = @"c:\monApplicationPhoto\Images\metadata.json";
        private const string kmTagList = @"c:\monApplicationPhoto\Images\tagList.json";

        public Main()
        {
            Application.ApplicationExit += new EventHandler(SerializeToJSON);
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            mLastSelectedPicture = new PictureBox();

            LoadAllImportedImageMetadata();
            LoadTagHierarchy();
            AddTagsToTreeView();

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

            mTagTree.Dock = DockStyle.Fill;
            mTagTree.MouseClick += TagTree_Click;

            soloImageLayout.Controls.Add(leftArrow);
            soloImageLayout.Controls.Add(rightArrow);

            TagListSplit.Controls.Add(mTagTree);

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
        }

        private void LoadTagHierarchy()
        {
            if (File.Exists(kmTagList))
            {
                using (var file = File.OpenText(kmTagList))
                {
                    var serializer = new JsonSerializer();
                    mTagList = (List<Tag>)serializer.Deserialize(file, typeof(List<Tag>));
                }
            }
            if (mTagList == null)
                mTagList = new List<Tag>();
        }

        private void Test()
        {
            //var blaise = @"C:\monApplicationPhoto\Images\blaise_pascal.jpg";

        }

        private void AddTagsToTreeView()
        {
            mTagTree.Nodes.Clear();
            foreach( var currentTag in mTagList )
            {
                if (currentTag.tags.Count == 0)
                {
                    mTagTree.Nodes.Add(currentTag.name);
                }
                else
                {
                    List<TreeNode> subTagNames = new List<TreeNode>();
                    foreach ( var subTag in currentTag.tags)
                        subTagNames.Add(new TreeNode(subTag));

                    mTagTree.Nodes.Add(new TreeNode( currentTag.name, subTagNames.ToArray()));
                }
            }
        }

        public void ModifyTag( string newTag, string oldTag )
        {
            mMosaic[mIndexCloneInMosaic].ModifyTagList(newTag, oldTag);
        }

        public void DeleteTag(string tag)
        {
            if( mIndexCloneInMosaic != -1 )
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
                var c = new TagView(promptValue, this);
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
            contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void EraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErasePictureFromApplication();
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

        private List<ImageData> SeekTagThroughMosaic( List<string> tagsToFind, List<string> tagsToAvoid )
        {
            var res = new List<ImageData>();

            foreach ( var tagName in tagsToFind )
                res = mMosaic.Where( p => p.tags.Any( tag => tag.Equals( tagName ) ) ).ToList();

            foreach ( var r in res )
                foreach ( var tagName in tagsToAvoid )
                    if ( r.tags.Contains( tagName ) )
                        res.Remove( r );

            //foreach( var imageData in mosaic )
            //    foreach ( var acceptedTag in tagsToFind )
            //        foreach( var refusedTag in tagsToAvoid )
            //            if ( imageData.tags.Contains( acceptedTag ) && !imageData.tags.Contains( refusedTag ) )
            //                res.Add(imageData.fileName);

            return res;
        }

        private void CtrlMultiSelect( PictureBox picture )
        {
            mSelectedItems.Add( picture );
            mLastSelectedPicture = picture;
            tagPanel.Controls.Clear();
        }

        private void ChangeCurrentlySelectedImage( PictureBox picture )
        {
            var picturePath = picture.ImageLocation;

            mIndexCloneInMosaic = mMosaic.IndexOf(mMosaic.First(s => s.fileName.Equals(picturePath, StringComparison.OrdinalIgnoreCase)));

            foreach ( var i in mSelectedItems )
                i.BorderStyle = BorderStyle.None;

            mSelectedItems.Clear();
            mLastSelectedPicture.BorderStyle = BorderStyle.None;
            mLastSelectedPicture = picture;
            mSelectedItems.Add( picture );
            picture.BorderStyle = BorderStyle.FixedSingle;

            LoadPictureTags();
            UpdateClone( picturePath );
        }

        private void UpdateClone( string clonePath )
        {
            mClone.ImageLocation = clonePath;
            mClone.Width = soloImageLayout.Width / 2;
            mClone.Height = 3 * soloImageLayout.Height / 4;
            mClone.Location = new Point( ( soloImageLayout.Width - mClone.Width ) / 2, 0 );
        }

        private void PictureClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Left )
            {
                var currentPicture = ( ( PictureBox ) sender );
                currentPicture.BorderStyle = BorderStyle.FixedSingle;

                if ( mSelectedItems.Count == 1 )
                    UpdateTags();

                if (ModifierKeys == Keys.Control)
                    CtrlMultiSelect( currentPicture );
                else
                    ChangeCurrentlySelectedImage( currentPicture );
            }
            else if ( e.Button == MouseButtons.Right )
            {
                mImageToBeDeleted = ( PictureBox )sender;                
                ShowRightClickMenu();
            }
        }

        private void TagTree_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewMenu.Show(MousePosition.X, MousePosition.Y);
                var hit = mTagTree.HitTest(e.X, e.Y);
                if (hit.Node == null)
                {
                    mTagTree.SelectedNode = null;
                }
                else
                {
                    mTagTree.SelectedNode = hit.Node;
                }
            }
        }

        private void LoadPictureTags()
        {
            tagPanel.Controls.Clear();
            foreach ( var tag in mMosaic[ mIndexCloneInMosaic ].tags )
                tagPanel.Controls.Add( new TagView( tag, this ) );

            tagPanel.Controls.Add(mAddTagToPicture);
        }

        private void LoadAllImportedImageMetadata()
        {
            if ( File.Exists( kmMetadataStore ) )
            {
                using ( var file = File.OpenText( kmMetadataStore ) )
                {
                    var serializer = new JsonSerializer();
                    mMosaic = ( List< ImageData > ) serializer.Deserialize( file, typeof( List< ImageData > ) );
                }
            }
            if ( mMosaic == null )
                mMosaic = new List< ImageData >();
        }

        private void UpdateTags()
        {
            if ( mIndexCloneInMosaic != -1 )
            {
                mMosaic[ mIndexCloneInMosaic ].tags.Clear();
                for( var i = 0; i < tagPanel.Controls.Count - 1; ++i )
                {
                    var tag = ( TagView ) tagPanel.Controls[ i ];
                    if (!mMosaic[ mIndexCloneInMosaic ].tags.Contains( tag.mTextBox.Text.Trim() ) )
                        mMosaic[ mIndexCloneInMosaic ].tags.Add( tag.mTextBox.Text.Trim() );
                }
            }
        }

        private void LeftImageButton_Click( object sender, EventArgs e )
        {
            UpdateTags();

            if ( mIndexCloneInMosaic == -1 )
                return;
            if ( mIndexCloneInMosaic == 0 )
                mIndexCloneInMosaic = mMosaic.Count - 1;
            else
                mIndexCloneInMosaic -= 1;

            mClone.ImageLocation = mMosaic[ mIndexCloneInMosaic ].fileName;

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

            using (var file = File.CreateText(kmTagList))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mTagList);
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if(textBox_recherche.Text != "" && !tag_recherches.Contains(textBox_recherche.Text))
                tag_recherches.Add(textBox_recherche.Text);
            if (tag_retirer.Contains(textBox_recherche.Text))
                tag_retirer.Remove(textBox_recherche.Text);

            UpdateSearchList();
        }

        private void UpdateSearchList()
        {
            flowLayoutPanel_recherche.Controls.Clear();
            foreach (string tag in tag_recherches)
            {
                var lab = new TagView(tag, this);
       
                flowLayoutPanel_recherche.Controls.Add(lab);
            }
            textBox_recherche.Text = "";
            flowLayoutPanel_retirer.Controls.Clear();
            foreach (string tag in tag_retirer)
            {
                var lab = new TagView(tag, this);

                flowLayoutPanel_retirer.Controls.Add(lab);
            }
            textBox_retirer.Text = "";
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (textBox_retirer.Text != "" && !tag_retirer.Contains(textBox_retirer.Text))
                tag_retirer.Add(textBox_retirer.Text);
            if (tag_recherches.Contains(textBox_retirer.Text))
                tag_recherches.Remove(textBox_retirer.Text);

            UpdateSearchList();
        }

        private void DeleteTagFromTreeView_Click(object sender, EventArgs e)
        {
            for( var i = 0; i < mTagList.Count; ++i)
            {
                if(mTagList[ i ].name == mTagTree.SelectedNode.Text)
                {
                    mTagList.Remove(mTagList[ i ]);
                    break;
                }
            }
            AddTagsToTreeView();
        }

        private void AddSuperTag_Click(object sender, EventArgs e)
        {
            var promptValue = Prompt.ShowDialog("Veuillez entrer le nom du super tag à créer", "Ajout d'un super tag");
            if (promptValue.Trim() != "")
            {
                var i = mTagList.FirstOrDefault(s => s.name == promptValue);
                if( i == null )
                {
                    mTagList.Add(new Tag(promptValue));
                    mTagTree.Nodes.Add(new TreeNode(promptValue));
                }
                else
                {
                    MessageBox.Show("Ce super tag existe déjà");
                }
            }
        }

        private void AddSubtag_Click(object sender, EventArgs e)
        {
            var superTagList = new List<string>();
            foreach(var currentSuperTag in mTagList)
                superTagList.Add(currentSuperTag.name);

            var promptValue = DropDownPrompt.ShowDialog(superTagList, "Veuillez choisir le super tag puis entrer le nom du sous tag à créer", "Ajout d'un sous tag");
            if( promptValue.Item1 != "")
            { 
                var superTag = mTagList.First(s => s.name == promptValue.Item1);
                if ( !superTag.tags.Contains( promptValue.Item2 ))
                    superTag.tags.Add(promptValue.Item2);

                for( var i = 0; i < mTagTree.Nodes.Count; ++i)
                {
                    if (mTagTree.Nodes[ i ].Text == promptValue.Item1)
                    {
                        mTagTree.Nodes[i].Nodes.Add( promptValue.Item2);
                        break;
                    }
                }
            }
        }
    }
}
