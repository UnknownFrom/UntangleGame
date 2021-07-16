using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLibrary
{
    public partial class GameTimer : UserControl
    {
        int seconds, minutes, hours;
        public GameTimer()
        {
            InitializeComponent();
        }
        public void Start()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
            display.Text = "00:00:00";
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        public string Time => display.Text;

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            minutes += seconds / 60;
            hours += minutes / 60;
            minutes = minutes % 60;
            seconds = seconds % 60;
            if (seconds < 10)
            {
                if (minutes < 10)
                {
                    if (hours < 10)
                    {
                        display.Text = "0" + hours + ":0" + minutes + ":0" + seconds;
                    }
                    else
                    {
                        display.Text = hours + ":0" + minutes + ":0" + seconds;
                    }
                }
                else
                {
                    if (hours < 10)
                    {
                        display.Text = "0" + hours + ":" + minutes + ":0" + seconds;
                    }
                    else
                    {
                        display.Text = hours + ":" + minutes + ":0" + seconds;
                    }
                }

            }
            else
            {
                if (minutes < 10)
                {
                    if (hours < 10)
                    {
                        display.Text = "0" + hours + ":0" + minutes + ":" + seconds;
                    }
                    else
                    {
                        display.Text = hours + ":0" + minutes + ":" + seconds;
                    }
                }
                else
                {
                    if (hours < 10)
                    {
                        display.Text = "0" + hours + ":" + minutes + ":" + seconds;
                    }
                    else
                    {
                        display.Text = hours + ":" + minutes + ":" + seconds;
                    }
                }
            }
        }

    }
}
