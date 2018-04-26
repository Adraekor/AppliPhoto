using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliPhoto
{
    public class Tag : UserControl
    {
        private Button _button;
        private Label _label;
        private TextBox textBox;

        public Tag(Button button, Label label)
        {
            textBox = new TextBox();
            textBox.Hide();
            
            _button = button;
            
            _label = label;
            _label.LostFocus += transformToLabel;
            _label.AutoSize = true;
            Height = Math.Max(_button.Height, _label.Height);
            Width = _button.Width + _label.Width + 10;
            label.Font = new Font("Arial", 12, FontStyle.Italic);
            Controls.Add(_label);
            _label.Location = new Point(0, 0);
            Controls.Add(textBox); 
            Controls.Add(_button);
            _button.Location = new Point(_label.Width, 0);
            AutoSize = true;
            _label.AutoSize = true;
            _button.AutoSize = false;
            SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            _button.Click += buttonClicked;
            _label.Click += transformToTextBox;
            _button.Width = 20;
            _button.Height = 20;

            _label.Click += transformToTextBox;
        }

        private void buttonClicked(object sender, EventArgs e)
        {
            MessageBox.Show(_label.Text);
        }

        private void transformToTextBox(object sender, EventArgs e)
        {
            _label.Hide();
            textBox.Text = _label.Text;
            _button.Hide();

            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            textBox.Width = size.Width;
            textBox.Height = size.Height;

            textBox.Show();
        }

        private void transformToLabel( object sender, EventArgs e)
        {
            textBox.Hide();
            _label.Text = textBox.Text;


            _button.Show();
            _label.Show();
        }
    }
}
