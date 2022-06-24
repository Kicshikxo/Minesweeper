using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сапёр
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 161, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseFormButton_MouseEnter(object sender, EventArgs e)
        {
            CloseFormButton.Image = Properties.Resources.close_button_hover;
        }

        private void CloseFormButton_MouseLeave(object sender, EventArgs e)
        {
            CloseFormButton.Image = Properties.Resources.close_button;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IncreaseButton1_Click(object sender, EventArgs e)
        {
            if (FieldWidthTextBox.Text.Length < 3 && FieldWidthTextBox.Text != "") FieldWidthTextBox.Text = $"{Convert.ToInt32(FieldWidthTextBox.Text)+1}";
        }

        private void ReduceButton1_Click(object sender, EventArgs e)
        {
            if (FieldWidthTextBox.Text != "8" && FieldWidthTextBox.Text != "") FieldWidthTextBox.Text = $"{Convert.ToInt32(FieldWidthTextBox.Text) - 1}";
        }

        private void IncreaseButton2_Click(object sender, EventArgs e)
        {
            if (FieldHeightTextBox.Text.Length < 3 && FieldHeightTextBox.Text != "") FieldHeightTextBox.Text = $"{Convert.ToInt32(FieldHeightTextBox.Text) + 1}";
        }

        private void ReduceButton2_Click(object sender, EventArgs e)
        {
            if (FieldHeightTextBox.Text != "8" && FieldHeightTextBox.Text != "") FieldHeightTextBox.Text = $"{Convert.ToInt32(FieldHeightTextBox.Text) - 1}";
        }

        private void IncreaseButton3_Click(object sender, EventArgs e)
        {
            if (BombsCountTextBox.Text.Length < 5 && BombsCountTextBox.Text != "") BombsCountTextBox.Text = $"{Convert.ToInt32(BombsCountTextBox.Text) + 1}";
        }

        private void ReduceButton3_Click(object sender, EventArgs e)
        {
            if (BombsCountTextBox.Text != "0" && BombsCountTextBox.Text != "") BombsCountTextBox.Text = $"{Convert.ToInt32(BombsCountTextBox.Text) - 1}";
        }

        private void FieldWidthTextBox_TextChanged(object sender, EventArgs e) {
            string digits = string.Join("", FieldWidthTextBox.Text.Where(c => char.IsDigit(c)));
            FieldWidthTextBox.Text = digits;
            if (FieldWidthTextBox.Text != "" && Convert.ToInt32(digits) < 8) FieldWidthTextBox.Text = "8";
        }

        private void FieldHeightTextBox_TextChanged(object sender, EventArgs e)
        {
            string digits = string.Join("", FieldHeightTextBox.Text.Where(c => char.IsDigit(c)));
            FieldHeightTextBox.Text = digits;
            if (FieldHeightTextBox.Text != "" && Convert.ToInt32(digits) < 8) FieldHeightTextBox.Text = "8";
        }

        private void BombsCountTextBox_TextChanged(object sender, EventArgs e)
        {
            BombsCountTextBox.Text = string.Join("", BombsCountTextBox.Text.Where(c => char.IsDigit(c)));
        }

        private void BegginerDifficultyButton_Click(object sender, EventArgs e)
        {
            FieldWidthTextBox.Text = "8";
            FieldHeightTextBox.Text = "8";
            BombsCountTextBox.Text = "10";
        }

        private void AmateurDifficultyButton_Click(object sender, EventArgs e)
        {
            FieldWidthTextBox.Text = "16";
            FieldHeightTextBox.Text = "16";
            BombsCountTextBox.Text = "40";
        }

        private void ProfessionalDifficultyButton_Click(object sender, EventArgs e)
        {
            FieldWidthTextBox.Text = "30";
            FieldHeightTextBox.Text = "16";
            BombsCountTextBox.Text = "99";
        }
    }
}
