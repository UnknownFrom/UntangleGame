using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Untangle
{
    public partial class GameForm : Form
    {
        Settings settings;
        int verticesCount,          /*количество вершин*/
            activeVertexIndex,      /*индекс активной вершины*/
            generationsCount = 3,   /*количество итераций для генерации рёбер, задаётся в коде*/
            level = 4,              /*уровень сложности (начинается с 4 вершин)*/
            autoSolves = 0,
            countMove = 0,
            countAllMove=0,
            maxSteps=3,
            step=0,
            time=0,                 /*Общее время игры*/
            language; //Язык интерфейса

        Bitmap bitmap;     /*Картинка, для сохранения результата и отображения*/
        Graphics graphics; /*Для графики*/
        bool isMoveVertex = false, CrossEdgeOn=true; /*Булевы переменные*/
        public static string playerName; /*Никнейм*/
        public List<Player> players= new List<Player>(); /*Список игроков*/
        string gameInform=""; /*информация об уровне и времени*/
        string timeRightView = "00:00:00"; /*Время в нормальном виде*/

        /*Списки ребер и вершин*/
        static List<Edge> Edges = new List<Edge>();
        public static List<Vertex> Vertices = new List<Vertex>();
        static List<Vertex> SolvedVertices = new List<Vertex>();
        private int seconds, minutes, hours;

        public GameForm(List<Player> _player,string _playerName,int _language)
        {
            InitializeComponent();
            settings = new Settings();
            for (int i = 0; i < _player.Count; i++)
            {
                players.Add(new Player(_player[i]));
            }
            playerName = _playerName;
            language = _language;
            if(language==1)
            {
                SolutionToolStripMenuItem.Text = "Solution";
                SettingsToolStripMenuItem.Text = "Settings";
                MainSettingsToolStripMenuItem.Text = "Main settings";
                CrossingEdgesToolStripMenuItem.Text = "Crossing Edges";
                SmoothingToolStripMenuItem1.Text = "Smoothing";
                OnToolStripMenuItem1.Text = "On";
                OnToolStripMenuItem2.Text = "On";
                OffToolStripMenuItem1.Text = "Off";
                OffToolStripMenuItem2.Text = "Off";
                NewGameToolStripMenuItem.Text = "New game";
            }
            else if(language==2)
            {
                SolutionToolStripMenuItem.Text = "Решение";
                SettingsToolStripMenuItem.Text = "Настройки";
                MainSettingsToolStripMenuItem.Text = "Основные настройки";
                CrossingEdgesToolStripMenuItem.Text = "Пересечение рёбер";
                SmoothingToolStripMenuItem1.Text = "Сглаживание";
                OnToolStripMenuItem1.Text = "Включить";
                OnToolStripMenuItem2.Text = "Включить";
                OffToolStripMenuItem1.Text = "Выключить";
                OffToolStripMenuItem2.Text = "Выключить";
                NewGameToolStripMenuItem.Text = "Новая игра";
            }
            Field.Location = new Point(0, menuStrip1.Size.Height);
            Field.Width = this.Size.Width - 16;
            Field.Height = this.Size.Height - menuStrip1.Size.Height - 38;
            menuStrip1.BackColor = settings.GameFieldColor;
        }
        private void GameForm_Shown(object sender, EventArgs e)
        {
            bitmap = new Bitmap(Field.Width, Field.Height);/*буфер для изображения*/
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.HighQuality;/*сглаживание*/
            settings = new Settings();
            DrawAll();
            StartLevel();
        }
        private void Field_MouseDown(object sender, MouseEventArgs e)
        {
            int i = 0;
            while (i < Vertices.Count && !isMoveVertex)
            {
                if (IsVertex(e, i))
                {
                    isMoveVertex = true;
                    activeVertexIndex = i;
                    Vertices[i].Body = DesignActiveVertex;
                    ++countMove;
                    DrawAll();
                }
                ++i;
            }
        }

        /// <summary>
        /// Попадает ли курсор в i-ую вершину 
        /// </summary>
        private bool IsVertex(MouseEventArgs e, int i) => e.X >= Vertices[i].Location.X - settings.VertexSize / 2 && e.X <= Vertices[i].Location.X + settings.VertexSize / 2 && e.Y >= Vertices[i].Location.Y - settings.VertexSize / 2 && e.Y <= Vertices[i].Location.Y + settings.VertexSize / 2;

        private void Field_MouseUp(object sender, MouseEventArgs e)
        {
            Vertices[activeVertexIndex].Body = DesignVertex;
            isMoveVertex = false;
            DrawAll();
            if (IsWin())
            {
                countAllMove += countMove;
                timer1.Enabled=false;
                if (language == 1)
                {
                    if (MessageBox.Show("Congratulations, you have found the solution to the puzzle!\nThis required:\nMoves: " + countMove + "\nTime: " + timeRightView + "\nDo you want to continue?", "Victory", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ++level;
                        StartLevel();
                    }
                    else
                    {
                        Close();
                    }
                }
                else if (language == 2)
                {
                    if (MessageBox.Show("Поздравляю, вы нашли решение головоломки!\nНа это потребовалось:\nХодов: " + countMove + "\nВремени: " + timeRightView + "\nХотите продолжить?", "Победа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ++level;
                        StartLevel();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        /// <summary>
        /// Проверка, все ли вершины расставлены верно
        /// </summary>
        private bool IsWin()
        {
            foreach (Edge edge in Edges)
            {
                if (!isRightEdge(edge))
                    return false;
            }
            return true;
        }

        private void GameForm_Resize(object sender, EventArgs e)
        {
            Field.Width = this.Size.Width - 16;
            Field.Height = this.Size.Height - menuStrip1.Size.Height - 38;
            bitmap = new Bitmap(Field.Width, Field.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.HighQuality;/*сглаживание*/
            DrawAll();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flagSame = false;
            int i = 0;
            if (players.Count != 0)
            {
                foreach (Player pl in players)
                {
                    if (pl.name == playerName)
                    {
                        flagSame = true;
                        if ((pl.level - pl.autoSolves < level - 3 - autoSolves) || (pl.level - pl.autoSolves == level - 3 && pl.countAllMove > countAllMove))
                        {
                            pl.level = level - 3;
                            pl.countAllMove = countAllMove;
                            pl.autoSolves = autoSolves;
                            pl.time = time;
                        }
                    }
                    i++;
                }
            }
            if(!flagSame)
            {
                players.Add(new Player(playerName, level-3,countAllMove, autoSolves, time));
            }
        }

        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            ++step;
            if (step>maxSteps && isMoveVertex && e.X <= Field.Width && e.X >= 0 && e.Y <= Field.Height && e.Y >= 0)/*в пределах игрового поля присваиваем активной вершине координаты курсора*/
            {
                step = 0;
                Vertices[activeVertexIndex].Location.X = e.X;
                Vertices[activeVertexIndex].Location.Y = e.Y;
                DrawAll();
            }
        }

        /// <summary>
        /// Старт уровня: 
        /// Инициализация вершин,
        /// Инициализация рёбер,
        /// Рандомизация расположения вершин,
        /// Отрисовка всего
        /// </summary>
        private void StartLevel()
        {
            InitializeVertex();             /*создаём вершины*/
            InitializeEdges();              /*связывем рёбрами*/
            InitializeExtraEdges();         /*соединяем дополнительными рёбрами*/
            RandomLocationVertex();         /*рандомно располагаем вершины*/
            DrawAll();                      /*отрисовываем всё*/
            seconds = 0;
            minutes = 0;
            hours = 0;
            countMove = 0;                  /*обнуляем количество ходов*/
            timer1.Enabled=true;
            timeRightView = "00:00:00";
            if(language ==1)
            {
                gameInform = "Level: " + (level - 3) + " Time: " + timeRightView;
            }
            else if(language==2)
            {
                gameInform = "Уровень: " + (level - 3) + " Время: " + timeRightView;
            }
            this.Text = gameInform;/*выводим номер уровня*/
        }

        /// <summary>
        /// Старт новой игры: 
        /// Инициализация вершин,
        /// Инициализация рёбер,
        /// Рандомизация расположения вершин,
        /// Отрисовка всего
        /// </summary>
        private void StartNewGame()
        {
            level = 4;
            countAllMove = 0;
            autoSolves = 0;
            StartLevel();
        }

        /// <summary>
        /// Инициализация вершин(по кругу)
        /// </summary>
        private void InitializeVertex()
        {
            Vertices.Clear();
            SolvedVertices.Clear();
            if (level >= 40)/*ограничение на количество вершин*/
            {
                verticesCount = 40;
            }
            else
            {
                verticesCount = level;
            }
            double point = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                Vertices.Add(new Vertex(DesignVertex, new Point(Field.Width / 2 + (int)((Field.Width / 2 - 20) * Math.Cos(point)), Field.Height / 2 + (int)((Field.Height / 2 - 20) * (Math.Sin(point))))));/*добавляем вершину на окружности*/
                SolvedVertices.Add(new Vertex(Vertices[i]));/*добавляем в список вершин решённой головоломки*/
                point += 2 * Math.PI / verticesCount;/*следующая точка на окружности*/
            }
        }

        private void SolveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i] = SolvedVertices[i];
            }
            DrawAll();
            autoSolves++;
            timer1.Enabled = false;
            if(language==1)
            {
                if (MessageBox.Show("You have used the automatic puzzle solution.\nTotal automatic solutions: " + autoSolves + "\nDo you want to continue?", "Automatic solution", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ++level;
                    StartLevel();
                }
                else
                {
                    Close();
                }
            }
            else if(language==2)
            {
                if (MessageBox.Show("Вы воспользовались автоматическим решением головоломки.\nВсего автоматических решений у вас было: " + autoSolves + "\nХотите продолжить?", "Автоматическое решение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ++level;
                    StartLevel();
                }
                else
                {
                    Close();
                }
            }
            
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(settings,language);
            form.ShowDialog();
            settings = form.GetSettings;
            form.Close();
            DrawAll();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void OffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrossEdgeOn = false;
            DrawAll();
        }

        private void OnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrossEdgeOn = true;
            DrawAll();
        }

        /// <summary>
        /// Включение сглаживания
        /// </summary>
        private void SmoothingOn(object sender, EventArgs e)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawAll();
        }

        /// <summary>
        /// Выключение сглаживания
        /// </summary>
        private void SmoothingOff(object sender, EventArgs e)
        {
            graphics.SmoothingMode = SmoothingMode.None;
            DrawAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
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
            if(language==1)
            {
                gameInform = "Level: " + (level - 3) + " Time: " + timeRightView;
            }
            else if(language==2)
            {
                gameInform = "Уровень: " + (level - 3) + " Время: " + timeRightView;
            }
            this.Text = gameInform;
        }

        /// <summary>
        /// Рандомное расположение вершин
        /// </summary>
        private void RandomLocationVertex()
        {
            Random rand = new Random();
            int x, y,count;
            for(int i=0;i<verticesCount;i++)
            {
                count = 0;
                x = rand.Next(settings.VertexSize / 2, Field.Width - settings.VertexSize);
                y = rand.Next(settings.VertexSize / 2, Field.Height - settings.VertexSize);
                for (int k=0;k<verticesCount;k++)/*проверка, чтобы вершины не накладывались*/
                {
                    if (i != k && x <= Vertices[k].Location.X+Vertices[k].Body.Size && x >= Vertices[k].Location.X - Vertices[k].Body.Size && y <= Vertices[k].Location.Y + Vertices[k].Body.Size && y >= Vertices[k].Location.Y - Vertices[k].Body.Size)
                    {
                        i--;
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if(count==verticesCount)/*если наложения нет*/
                {
                    Vertices[i].Location.X = x;
                    Vertices[i].Location.Y = y;
                }
            }
            if (IsWin())/*если сразу получилось верное решение*/
            {
                RandomLocationVertex();
            }
        }

        /// <summary>
        /// Дизайн для вершин
        /// </summary>
        private Design DesignVertex
        {
            get
            {
                return new Design(settings.VertexColor, settings.VertexSize);
            }
            set
            {
                Design design = value;
                settings.VertexColor = design.Color;
                settings.VertexSize = design.Size;
            }
        }

        /// <summary>
        /// Дизайн для активной вершины
        /// </summary>
        private Design DesignActiveVertex
        {
            get
            {
                return new Design(settings.ActiveVertexColor, settings.VertexSize);
            }
            set
            {
                Design design = value;
                settings.ActiveVertexColor = design.Color;
                settings.VertexSize = design.Size;
            }
        }

        /// <summary>
        /// Инициализация рёбер(соединение с вершинами)
        /// </summary>
        private void InitializeEdges()
        {
            Edges.Clear();
            for (int i = 0; i < verticesCount - 1; i++)/*по очереди соединяем вершины рёбрами*/
            {
                Edges.Add(new Edge(DesignEdgesRight, new Point(i, i + 1)));
            }
            Edges.Add(new Edge(DesignEdgesRight, new Point(verticesCount - 1, 0)));/*соединяем последнюю вершину с первой*/
        }

        /// <summary>
        /// Инициализация дополнительных рёбер
        /// </summary>
        private void InitializeExtraEdges()
        {
            int count = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                count = 0;
                for (int k = verticesCount - 1; k >= 0; k--)
                {
                    if (count < generationsCount && i != k)
                    {
                        Edge edge = new Edge(DesignEdgesRight, new Point(i, k));/*создаём ребро*/
                        if (isRightEdge(edge))/*если ребро не пересекается с другими*/
                        {
                            Edges.Add(edge);
                            ++count;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Дизайн для непересекающегося ребра 
        /// </summary>
        private Design DesignEdgesRight
        {
            get
            {
                return new Design(settings.RightEdgeColor, settings.EdgeSize);
            }
            set
            {
                Design design = value;
                settings.EdgeSize = value.Size;
                settings.RightEdgeColor = value.Color;
            }
        }

        /// <summary>
        /// Дизайн для пересекающегося ребра 
        /// </summary>
        private Design DesignEdgesCrossed
        {
            get
            {
                if (CrossEdgeOn)
                {
                    return new Design(settings.CrossEdgeColor, settings.EdgeSize);
                }
                else
                {
                    return new Design(settings.RightEdgeColor, settings.EdgeSize);
                }
            }
            set
            {
                Design design = value;
                settings.EdgeSize = value.Size;
                settings.CrossEdgeColor = value.Color;
            }
        }

        /// <summary>
        /// Определяет, есть ли у этого ребра пересечения с другими рёбрами
        /// </summary>
        private bool isRightEdge(Edge edge)
        {
            if (edge.Location.X != edge.Location.Y)
            {
                foreach (Edge curEdge in Edges)
                {
                    /*если нашлось пересечение*/
                    if (curEdge != edge && Crossed(Vertices[edge.Location.X].Location, Vertices[edge.Location.Y].Location, Vertices[curEdge.Location.X].Location, Vertices[curEdge.Location.Y].Location))
                    {
                        return false;
                    }
                }
                return true;/*если нет пересечений*/
            }
            return false;
        }

        /// <summary>
        /// Пересекаются ли рёбра с кординатами (v11;v12) и (v21,v22)
        /// </summary>
        private bool Crossed(Point V1, Point V2, Point V3, Point V4)/*с помощью векторного произведения проверяется,
                                                                     * лежат ли две точки (вершины одного отрезка) по разные стороны от другого вектора (отрезка).
                                                                     * Это делается для каждого из двух векторов*/
        {
            double v1, v2, v3, v4;
            v1 = VectorMult(V4.X - V3.X, (V4.Y - V3.Y), V1.X - V3.X, (V1.Y - V3.Y));/*определяется, с какой стороны от вектора (V3 - V4)
                                                                                     * лежит точка V1 с помощью векторного произведения (V3 - V4) на (V3 - V1)*/
            v2 = VectorMult(V4.X - V3.X, (V4.Y - V3.Y), V2.X - V3.X, (V2.Y - V3.Y));/*определяется, с какой стороны от вектора (V3 - V4)
                                                                                     * лежит точка V2 с помощью векторного произведения (V3 - V4) на (V3 - V2)*/
            v3 = VectorMult(V2.X - V1.X, (V2.Y - V1.Y), V3.X - V1.X, (V3.Y - V1.Y));/*определяется, с какой стороны от вектора (V1 - V2)
                                                                                     * лежит точка V3 с помощью векторного произведения (V1 - V2) на (V1 - V3)*/
            v4 = VectorMult(V2.X - V1.X, (V2.Y - V1.Y), V4.X - V1.X, (V4.Y - V1.Y));/*определяется, с какой стороны от вектора (V1 - V2)
                                                                                     * лежит точка V4 с помощью векторного произведения (V1 - V2) на (V1 - V4)*/
            /*если получается, что векторные произведения разных знаков (их произведение < 0),
             * то есть вершины одного отрезка находятся по разные стороны относительно другого отрезка
             * (для второго выполняется это же), то они пересекаются*/
            if (v1 * v2 < 0.00000000 && v3 * v4 < 0.00000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Произведение векторов
        /// </summary>
        /// <param name="Ax">координата x точки А</param>
        /// <param name="Ay">координата y точки А</param>
        /// <param name="Bx">координата x точки B</param>
        /// <param name="By">координата y точки B</param>
        private double VectorMult(double Ax, double Ay, double Bx, double By) => Ax * By - Bx * Ay;

        /// <summary>
        /// Рисует все ребра и вершины
        /// </summary>
        private void DrawAll()
        {
            UpdateDesign();
            foreach (Vertex vertex in Vertices)
            {
                vertex.Draw(graphics);
            }
            foreach (Edge edge in Edges)
            {
                edge.Draw(graphics);
            }
            Field.Image = bitmap;
        }

        /// <summary>
        /// Обновление дизайна (цвета вершин, ребер, заднего плана)
        /// </summary>
        private void UpdateDesign()
        {
            graphics.Clear(settings.GameFieldColor);/*очищаем поле*/
            menuStrip1.BackColor = settings.GameFieldColor;
            foreach (Edge edge in Edges)/*красим в соответствующий цвет рёбра*/
            {
                if (isRightEdge(edge))
                {
                    edge.Body = DesignEdgesRight;
                }
                else
                {
                    edge.Body = DesignEdgesCrossed;
                }
            }
            foreach (Vertex vertex in Vertices)
            {
                vertex.Body = DesignVertex;
            }
            if (isMoveVertex)
            {
                Vertices[activeVertexIndex].Body = DesignActiveVertex;
            }
        }
    }
}
