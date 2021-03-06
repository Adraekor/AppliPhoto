﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace AppliPhoto
{
    public abstract class TagView : UserControl
    {
        public Main mMain;
        public Button mButton;
        public TextBox mTextBox;
        public string mOldTag;

        public TagView( string iTag, Main iMain )
        {
            mMain = iMain;
            mTextBox = new TextBox
            {
                Font = new Font("Arial", 12, FontStyle.Italic),
                BackColor = DefaultBackColor,
                Text = iTag,
                BorderStyle = BorderStyle.None,
            };

            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mTextBox.Height = size.Height;

            mTextBox.GotFocus += StoreOldTag;
            mTextBox.Validating += TextValidating;
            mTextBox.KeyDown += TagModification;
            
            Controls.Add(mTextBox);

            mButton = new Button
            {
                Text = "X",
            };

            Height = Math.Max(mButton.Height, mTextBox.Height);
            Width = mButton.Width + mTextBox.Width + 10;
            
            Controls.Add(mButton);
            mButton.Location = new Point(mTextBox.Width, 0);
            AutoSize = true;
            mButton.Click += DeleteButtonClick;
            mButton.Width = mTextBox.Height;
            mButton.Height = mTextBox.Height;
        }

        public void StoreOldTag(object sender, EventArgs e)
        {
            mOldTag = mTextBox.Text;
            mTextBox.Font = new Font("Arial", 12, FontStyle.Regular);
            Size size = TextRenderer.MeasureText(mTextBox.Text, mTextBox.Font);
            mTextBox.Width = size.Width;
            mButton.Location = new Point(mTextBox.Width, 0);
        }


        public abstract void TextValidating(object sender, System.ComponentModel.CancelEventArgs e);

        public abstract void TagModification(object sender, KeyEventArgs e);

        public abstract void DeleteButtonClick(object sender, EventArgs e);

    }
}
