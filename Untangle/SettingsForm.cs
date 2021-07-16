using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Untangle
{
    public partial class SettingsForm : Form
    {
        Settings settings;
        Graphics graphicsVertex;
        Graphics graphicsEdge;
        Bitmap btmVertex;
        Bitmap btmEdge;
        Vertex vertex;
        Edge edge;
        int language;
        public SettingsForm(Settings settings, int _language)
        {
            InitializeComponent();
            language = _language;
            if(language==1)
            {
                this.Text = "Settings";
                SettingsLabel.Text = "Settings";
                VertexSizeLabel.Text = "Vertex size";
                EdgeSizeLabel.Text = "Edge thickness";
                GameFieldColorLabel.Text = "Color of the game field";
                VertexColorLabel.Text = "Vertex color";
                ActiveVertexColorLabel.Text = "Color of the active vertex";
                RightEdgeColorLabel.Text = "Color of the uncrossing edge";
                CrossEdgeColorLabel.Text = "Color of the crossing edge";
                OpacityLabel.Text = "Opacity app";
            }
            else if(language==2)
            {
                this.Text = "Настройки";
                SettingsLabel.Text = "Настройки";
                VertexSizeLabel.Text = "Размер вершины";
                EdgeSizeLabel.Text = "Толщина ребра";
                GameFieldColorLabel.Text = "Цвет игрового поля";
                VertexColorLabel.Text = "Цвет вершины";
                ActiveVertexColorLabel.Text = "Цвет активной вершины";
                RightEdgeColorLabel.Text = "Цвет непересекающегося ребра";
                CrossEdgeColorLabel.Text = "Цвет пересекающегося ребра";
                OpacityLabel.Text = "Прозрачность приложения";

            }
            this.settings = settings;
            btmVertex = new Bitmap(VertexSizePictureBox.Width, VertexSizePictureBox.Height);
            graphicsVertex = Graphics.FromImage(btmVertex);
            vertex = new Vertex(DesignVertex, new Point(VertexSizePictureBox.Width / 2, VertexSizePictureBox.Height / 2));
            btmEdge = new Bitmap(EdgeSizePictureBox.Width, EdgeSizePictureBox.Height);
            graphicsEdge = Graphics.FromImage(btmEdge);
            edge = new Edge(DesignEdgesRight);
        }

        public Settings GetSettings => settings;

        /// <summary>
        /// Отображение текущих параметров
        /// </summary>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            VertexSizeTextBox.Text = settings.VertexSize.ToString();
            EdgeSizeTextBox.Text = settings.EdgeSize.ToString();
            GameFieldColorTextBox.Text = settings.GameFieldColor.R.ToString()+"," + settings.GameFieldColor.G.ToString() + "," + settings.GameFieldColor.B.ToString();
            VertexColorTextBox.Text = settings.VertexColor.R.ToString() + "," + settings.VertexColor.G.ToString() + "," + settings.VertexColor.B.ToString();
            ActiveVertexColorTextBox.Text = settings.ActiveVertexColor.R.ToString() + "," + settings.ActiveVertexColor.G.ToString() + "," + settings.ActiveVertexColor.B.ToString();
            RightEdgeColorTextBox.Text = settings.RightEdgeColor.R.ToString() + "," + settings.RightEdgeColor.G.ToString() + "," + settings.RightEdgeColor.B.ToString();
            CrossEdgeColorTextBox.Text = settings.CrossEdgeColor.R.ToString() + "," + settings.CrossEdgeColor.G.ToString() + "," + settings.CrossEdgeColor.B.ToString();
            OpacityFormTextBox.Text = (settings.OpacityForm*100).ToString();
            Opacity = settings.OpacityForm;
            DrawAll();

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
        /// Рисует все ребра и вершины
        /// </summary>
        private void DrawAll()
        {
            UpdateDesign();
            vertex.Draw(graphicsVertex);
            graphicsEdge.DrawLine(new Pen(edge.Body.Color, edge.Body.Size), new Point(0, EdgeSizePictureBox.Height / 2), new Point(EdgeSizePictureBox.Width, EdgeSizePictureBox.Height / 2));
            VertexSizePictureBox.Image = btmVertex;
            EdgeSizePictureBox.Image = btmEdge;
            GameFieldColorPictureBox.BackColor = settings.GameFieldColor;
            VertexColorPictureBox.BackColor = settings.VertexColor;
            ActiveVertexColorPictureBox.BackColor = settings.ActiveVertexColor;
            RightEdgeColorPictureBox.BackColor = settings.RightEdgeColor;
            CrossEdgeColorPictureBox.BackColor = settings.CrossEdgeColor;
            Opacity = settings.OpacityForm;
        }

        /// <summary>
        /// Обновление дизайна (цвета вершин, ребер, заднего плана)
        /// </summary>
        private void UpdateDesign()
        {
            graphicsVertex.Clear(settings.GameFieldColor);/*очищаем поле*/
            graphicsEdge.Clear(settings.GameFieldColor);/*очищаем поле*/
            edge.Body = DesignEdgesRight;/*красим в соответствующий цвет рёбра*/
            vertex.Body = DesignVertex;
        }
        private void VertexSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (VertexSizeTextBox.TextLength != 0&& int.Parse(VertexSizeTextBox.Text)<50)
                {
                    VertexSizeTextBox.BackColor = Color.White;
                    settings.VertexSize = int.Parse(VertexSizeTextBox.Text);
                    DrawAll();
                }
                else
                {
                    VertexSizeTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                VertexSizeTextBox.BackColor = Color.Red;
            }
            
        }

        private void EdgeSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (EdgeSizeTextBox.TextLength != 0 && double.Parse(EdgeSizeTextBox.Text) >0 && double.Parse(EdgeSizeTextBox.Text) < 25)
                {
                    EdgeSizeTextBox.BackColor = Color.White;
                    settings.EdgeSize = int.Parse(EdgeSizeTextBox.Text);
                    DrawAll();
                }
                else
                {
                    EdgeSizeTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                EdgeSizeTextBox.BackColor = Color.Red;
            }
        }

        private void GameFieldColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] color = GameFieldColorTextBox.Text.Split(new char[] { ',' });
                if (GameFieldColorTextBox.TextLength != 0 && int.Parse(color[0]) >= 0 && int.Parse(color[0]) <= 255 && int.Parse(color[1]) >= 0 && int.Parse(color[1]) <= 255 && int.Parse(color[2]) >= 0 && int.Parse(color[2]) <= 255)
                {
                    GameFieldColorTextBox.BackColor = Color.White;
                    settings.GameFieldColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
                    DrawAll();
                }
                else
                {
                    GameFieldColorTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                GameFieldColorTextBox.BackColor = Color.Red;
            }
        }

        private void VertexColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] color = VertexColorTextBox.Text.Split(new char[] { ',' });
                if (VertexColorTextBox.TextLength != 0 && int.Parse(color[0]) >= 0 && int.Parse(color[0]) <= 255 && int.Parse(color[1]) >= 0 && int.Parse(color[1]) <= 255 && int.Parse(color[2]) >= 0 && int.Parse(color[2]) <= 255)
                {
                    VertexColorTextBox.BackColor = Color.White;
                    settings.VertexColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
                    DrawAll();
                }
                else
                {
                    VertexColorTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                VertexColorTextBox.BackColor = Color.Red;
            }
        }

        private void ActiveVertexColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] color = ActiveVertexColorTextBox.Text.Split(new char[] { ',' });
                if (ActiveVertexColorTextBox.TextLength != 0 && int.Parse(color[0]) >= 0 && int.Parse(color[0]) <= 255 && int.Parse(color[1]) >= 0 && int.Parse(color[1]) <= 255 && int.Parse(color[2]) >= 0 && int.Parse(color[2]) <= 255)
                {
                    ActiveVertexColorTextBox.BackColor = Color.White;
                    settings.ActiveVertexColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
                    DrawAll();
                }
                else
                {
                    ActiveVertexColorTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                ActiveVertexColorTextBox.BackColor = Color.Red;
            }
        }

        private void RightEdgeColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] color = RightEdgeColorTextBox.Text.Split(new char[] { ',' });
                if (RightEdgeColorTextBox.TextLength != 0 && int.Parse(color[0]) >= 0 && int.Parse(color[0]) <= 255 && int.Parse(color[1]) >= 0 && int.Parse(color[1]) <= 255 && int.Parse(color[2]) >= 0 && int.Parse(color[2]) <= 255)
                {
                    RightEdgeColorTextBox.BackColor = Color.White;
                    settings.RightEdgeColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
                    DrawAll();
                }
                else
                {
                    RightEdgeColorTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                RightEdgeColorTextBox.BackColor = Color.Red;
            }
        }

        private void CrossEdgeColorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string[] color = CrossEdgeColorTextBox.Text.Split(new char[] { ',' });
                if (CrossEdgeColorTextBox.TextLength != 0 && int.Parse(color[0]) >= 0 && int.Parse(color[0]) <= 255 && int.Parse(color[1]) >= 0 && int.Parse(color[1]) <= 255 && int.Parse(color[2]) >= 0 && int.Parse(color[2]) <= 255)
                {
                    CrossEdgeColorTextBox.BackColor = Color.White;
                    settings.CrossEdgeColor = Color.FromArgb(int.Parse(color[0]), int.Parse(color[1]), int.Parse(color[2]));
                    DrawAll();
                }
                else
                {
                    CrossEdgeColorTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                CrossEdgeColorTextBox.BackColor = Color.Red;
            }
        }

        private void OpacityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (OpacityFormTextBox.TextLength != 0 && int.Parse(OpacityFormTextBox.Text) <=100&& int.Parse(OpacityFormTextBox.Text) >=60)
                {
                    OpacityFormTextBox.BackColor = Color.White;
                    settings.OpacityForm = (double.Parse(OpacityFormTextBox.Text)/100.0);
                    DrawAll();
                }
                else
                {
                    OpacityFormTextBox.BackColor = Color.Red;
                }
            }
            catch
            {
                OpacityFormTextBox.BackColor = Color.Red;
            }
        }
    }
}
