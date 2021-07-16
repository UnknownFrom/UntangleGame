using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Untangle
{
    public partial class RecordsForm : Form
    {
        List<Player> players;
        int language;
        public RecordsForm(List<Player> _players,int _language)
        {
            InitializeComponent();
            language = _language;
            if (language == 1) 
            {
                RecordsLabel.Text = "Records";
                this.Text = "Records";
            }
            else if (language==2)
            {
                RecordsLabel.Text = "Рекорды";
                this.Text = "Рекорды";
            }
            players = _players;
            FillRecords();
        }

        private void FillRecords()
        {
            RecordsTextBox.Text = "";
            if (language == 1)
            {
                foreach (Player player in players)
                {
                    RecordsTextBox.Text += "Name: " + player.name + Environment.NewLine;
                    RecordsTextBox.Text += "\nLevel: " + player.level.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nTotal moves: " + player.countAllMove.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nAutomatic solutions: " + player.autoSolves.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nTotal time: " + ToRightTime(player.time) + Environment.NewLine + Environment.NewLine;
                }
            }
            else if (language == 2)
            {
                foreach (Player player in players)
                {
                    RecordsTextBox.Text += "Имя: " + player.name + Environment.NewLine;
                    RecordsTextBox.Text += "\nУровень: " + player.level.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nВсего ходов: " + player.countAllMove.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nАвтоматических решений: " + player.autoSolves.ToString() + Environment.NewLine;
                    RecordsTextBox.Text += "\nОбщее время: " + ToRightTime(player.time) + Environment.NewLine + Environment.NewLine;
                }
            }
        }

        private string ToRightTime(int time)
        {
            int seconds = 0, minutes = 0, hours = 0;
            hours = time / 3600;
            time %= 3600;
            minutes = time / 60;
            time %= 60;
            seconds = time;
            string timeRightView = "";
            if (seconds < 10)
            {
                if (minutes < 10)
                {
                    if (hours < 10)
                    {
                        timeRightView = "0" + hours + ":0" + minutes + ":0" + seconds;
                    }
                    else
                    {
                        timeRightView = hours + ":0" + minutes + ":0" + seconds;
                    }
                }
                else
                {
                    if (hours < 10)
                    {
                        timeRightView = "0" + hours + ":" + minutes + ":0" + seconds;
                    }
                    else
                    {
                        timeRightView = hours + ":" + minutes + ":0" + seconds;
                    }
                }

            }
            else
            {
                if (minutes < 10)
                {
                    if (hours < 10)
                    {
                        timeRightView = "0" + hours + ":0" + minutes + ":" + seconds;
                    }
                    else
                    {
                        timeRightView = hours + ":0" + minutes + ":" + seconds;
                    }
                }
                else
                {
                    if (hours < 10)
                    {
                        timeRightView = "0" + hours + ":" + minutes + ":" + seconds;
                    }
                    else
                    {
                        timeRightView = hours + ":" + minutes + ":" + seconds;
                    }
                }
            }
            return timeRightView;
        }
    }
}
