using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Untangle
{
    public partial class MenuForm : Form
    {
        int language = 1;/*1-английский, 2-русский*/
        public List<Player> players=new List<Player>();
        public SoundPlayer simpleSound;
        bool sound = false;
        public MenuForm()
        {
            InitializeComponent();
            CreateMenu();
            playSound();
            Russification();
            ResultRead();
        }
        
        private void playSound()
        {
            if (!sound)
            {
                simpleSound = new SoundPlayer(Properties.Resources.Music);
                soundButton.BackgroundImage = Properties.Resources.soundOn;
                simpleSound.PlayLooping();
                sound = true;
            }
            else
            {
                soundButton.BackgroundImage = Properties.Resources.soundOff;
                simpleSound.Stop();
                sound = false;
            }
        }

        /// <summary>
        /// Считывание списка рекордов
        /// </summary>
        private void ResultRead()
        {
            using (StreamReader result = new StreamReader("result.txt"))
            {
                while (!result.EndOfStream)
                {
                    players.Add(new Player(result.ReadLine(), int.Parse(result.ReadLine()), int.Parse(result.ReadLine()), int.Parse(result.ReadLine()), int.Parse(result.ReadLine())));
                }
            }

        }

        /// <summary>
        /// Запись в список рекордов
        /// </summary>
        private void ResultWrite()
        {
            StreamWriter result = new StreamWriter(File.Create(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "result.txt")));
            for (int i = 0; i < players.Count; i++)
            {
                result.WriteLine(players[i].name);
                result.WriteLine(players[i].level);
                result.WriteLine(players[i].countAllMove);
                result.WriteLine(players[i].autoSolves);
                result.WriteLine(players[i].time);
            }
            result.Close();
        }
        private void CreateMenu()
        {
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new Point(this.Size.Width / 2 - label1.Size.Width / 2, 20);
            label2.Location = new Point(this.Size.Width / 2 - label2.Size.Width / 2, label1.Location.Y + label1.Size.Height);
            StartButton.Location = new Point(this.Size.Width / 2 - StartButton.Size.Width, this.Size.Height - StartButton.Size.Height * 4);
            RulesButton.Location = new Point(this.Size.Width / 2 - RulesButton.Size.Width, this.Size.Height - RulesButton.Size.Height * 3);
            AboutButton.Location = new Point(this.Size.Width / 2, this.Size.Height - AboutButton.Size.Height * 4);
            ExitButton.Location = new Point(this.Size.Width / 2, this.Size.Height - ExitButton.Size.Height*3);
            this.BackgroundImage =Properties.Resources.GIMf;
            ImageAnimator.Animate(BackgroundImage, OnFrameChanged);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }
        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }
        private void CreateSimpleMenu()
        {
            this.BackgroundImage = default;
            this.BackgroundImageLayout = default;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateSimpleMenu();
            NameForm name = new NameForm(language);
            name.ShowDialog();
            if (name.playerName != ""&& name.playerName != null)
            {
                GameForm game = new GameForm(players, name.playerName,language);
                game.ShowDialog();
                players = game.players;
                ResultWrite();
                game.Close();
            }
            CreateMenu();
            this.Visible = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            if(language==1)
            {
                MessageBox.Show("Given several points connected by edges. It is necessary to arrange the points so that the edges do not intersect", "Game rules");
            }
            else
            {
                MessageBox.Show("Дано несколько точек, соединённых рёбрами. Нужно расположить точки таким образом, чтобы рёбра не пересекались", "Правила игры");
            }
            
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (language == 1)
            {
                MessageBox.Show("Create by: Vetlugaev Pavel\nGroup: FIb-2301-51-00", "Creator");
            }
            else
            {
                MessageBox.Show("Разработал: Ветлугаев Павел\nГруппа: ФИб-2301-51-00 ", "Разработчик");
            }
        }

        private void RusButton_Click(object sender, EventArgs e)
        {
            Russification();
        }
        private void Russification()
        {
            StartButton.Text = "Играть";
            RulesButton.Text = "Правила";
            AboutButton.Text = "Об игре";
            ExitButton.Text = "Выход";
            RecordsButton.Text = "Рекорды";
            language = 2;
        }
        private void EngButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "Play";
            RulesButton.Text = "Rules";
            AboutButton.Text = "About";
            ExitButton.Text = "Exit";
            RecordsButton.Text = "Records";
            language = 1;
        }

        private void RecordsButton_Click(object sender, EventArgs e)
        {
            RecordsForm form = new RecordsForm(players, language);
            this.Hide();
            form.ShowDialog();
            form.Close();
            this.Show();
        }

        private void soundButton_Click(object sender, EventArgs e)
        {
            playSound();
        }
    }
}
