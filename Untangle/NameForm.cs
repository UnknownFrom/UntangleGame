using System;
using System.Drawing;
using System.Windows.Forms;

namespace Untangle
{
    public partial class NameForm : Form
    {
        public string playerName;
        int language;
        public NameForm(int _language)
        {
            InitializeComponent();
            language = _language;
            if (language == 1)
            {
                PlayerNameLabel.Text = "Player name";
                this.Text= "Player name";
                NameTextBox.Text = "Player";
                StartButton.Text = "Play";
            }
            else if (language == 2)
            {
                PlayerNameLabel.Text = "Имя игрока";
                this.Text = "Имя игрока";
                NameTextBox.Text = "Игрок";
                StartButton.Text = "Играть";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text!=null&&NameTextBox.Text.Length!=0&& NameTextBox.Text.Length < 12)
            {
                NameTextBox.BackColor = Color.White;
                playerName = NameTextBox.Text;
                Close();
            }
            else
            {
                if(language==2)
                {
                    MessageBox.Show("Имя должно содержать от 1 до 11 символов", "Неверный ввод имени");
                }
                else if(language == 1)
                {
                    MessageBox.Show("The name must contain from 1 to 11 characters", "Invalid name entry");
                }
                NameTextBox.Text = "";
            }
        }
    }
}
