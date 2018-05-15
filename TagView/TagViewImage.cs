using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AppliPhoto
{
    public class TagViewImage : TagView
    {
        public TagViewImage(string iTag, Main iMain) : base(iTag, iMain)
        {
        }

        public override void DeleteButtonClick(object sender, EventArgs e)
        {
            mMain.DeleteTagImage(mTextBox.Text);
            Dispose();
        }

        public override void TagModification(object sender, KeyEventArgs e)
        {
            if (mTextBox.Font.Italic)
                mTextBox.Font = new Font("Arial", 12, FontStyle.Regular);
            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mButton.Location = new Point(mTextBox.Width, 0);
        }

        public override void TextValidating(object sender, CancelEventArgs e)
        {
            if (mTextBox.Text.Trim() == "")
                mTextBox.Text = mOldTag;

            mTextBox.Font = new Font("Arial", 12, FontStyle.Italic);
            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mButton.Location = new Point(mTextBox.Width, 0);

            mMain.ModifyTag(mTextBox.Text, mOldTag);
        }
    }
}
