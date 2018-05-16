using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AppliPhoto
{
    public class TagViewRecherche : TagView
    {
        //1 = tag recherche; 0 = tag retirer
        public int type;

        public TagViewRecherche(string iTag, Main iMain,int t) : base(iTag, iMain)
        {
            type = t;
            mTextBox.Enabled = false;
        }

        public override void DeleteButtonClick(object sender, EventArgs e)
        {
            mMain.DeleteTagRecherche(mTextBox.Text,type);
            Dispose();
            mMain.update_mosaic_recherche();
        }

        public override void TagModification(object sender, KeyEventArgs e)
        {

        }

        public override void TextValidating(object sender, CancelEventArgs e)
        {

        }
    }
}
