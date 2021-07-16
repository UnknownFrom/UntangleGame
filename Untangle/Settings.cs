using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untangle
{
    public class Settings
    {
        public Settings()
        {
            VertexSize = 25;    // размер вершины
            EdgeSize = 2;       // толщина ребра
            GameFieldColor = Color.FromArgb(105, 105, 105);       // поле игры
            VertexColor = Color.FromArgb(255, 248, 220);          // вершина
            ActiveVertexColor = Color.FromArgb(255, 160, 122);    // активная вершина
            RightEdgeColor = Color.FromArgb(127, 176, 105);       // непересекающееся ребро
            CrossEdgeColor = Color.FromArgb(211, 97, 53);         // пересекающееся ребро
            OpacityForm = 1;
        }
        public Settings(Settings settings)
        {
            this.VertexSize = settings.VertexSize;
            this.EdgeSize = settings.EdgeSize;
            this.GameFieldColor = settings.GameFieldColor;
            this.VertexColor = settings.VertexColor;
            this.ActiveVertexColor = settings.ActiveVertexColor;
            this.RightEdgeColor = settings.RightEdgeColor;
            this.CrossEdgeColor = settings.CrossEdgeColor;
            this.OpacityForm = settings.OpacityForm;
        }
        #region Установка новых параметров
        public int VertexSize
        {
            get;
            set;
        }

        public int EdgeSize
        {
            get;
            set;
        }
        public Color GameFieldColor
        {
            get;
            set;
        }

        public Color VertexColor
        {
            get;
            set;
        }

        public Color ActiveVertexColor
        {
            get;
            set;
        }

        public Color RightEdgeColor
        {
            get;
            set;
        }

        public Color CrossEdgeColor
        {
            get;
            set;
        }

        public double OpacityForm
        {
            get;
            set;
        }
        #endregion
    }
}
