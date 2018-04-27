using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppliPhoto
{
    public class Tag : UserControl
    {
        private Main mMain;
        private Button mButton;
        private TextBox mTextBox;

        public Tag(Button button, string tag, Main main)
        {
            mMain = main;
            mTextBox = new TextBox
            {
                Font = new Font("Times", 12, FontStyle.Italic),
                BackColor = Label.DefaultBackColor,
                Text = tag,
                BorderStyle = BorderStyle.None
            };

            mTextBox.Validating += MTextBox_Validating;

            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mTextBox.Height = size.Height;
            mTextBox.KeyDown += tagModification;
            Controls.Add(mTextBox);

            mButton = button;
            Height = Math.Max(mButton.Height, mTextBox.Height);
            Width = mButton.Width + mTextBox.Width + 10;
            
            Controls.Add(mButton);
            mButton.Location = new Point(mTextBox.Width, 0);
            AutoSize = true;
            mButton.Click += buttonClicked;
            mButton.Width = mTextBox.Height;
            mButton.Height = mTextBox.Height;
        }

        private void MTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show(mTextBox.Text);
        }

        private void tagModification(object sender, KeyEventArgs e)
        {
            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mButton.Location = new Point(mTextBox.Width, 0);
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            mMain.DeleteTag(mTextBox.Text);
            Dispose();
        }
    }
}
