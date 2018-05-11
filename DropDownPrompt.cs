using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppliPhoto
{
    public static class DropDownPrompt
    {
        public static Tuple<string, string> ShowDialog(List<string> source, string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 200, Top = 50, Width = 250 };
            ComboBox comboBox = new ComboBox() { DataSource = source, Left = 50, Top = 50, Width = 145, DropDownStyle = ComboBoxStyle.DropDownList };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(comboBox);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? new Tuple<string, string>(comboBox.SelectedItem.ToString(), textBox.Text) : new Tuple<string, string>("", "");
        }
    }
}
