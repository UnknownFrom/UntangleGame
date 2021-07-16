using System.Drawing;

namespace Untangle
{
    public class Design
    {
        public Design(Color color, int size)
        {
            Color = color;
            Size = size;
        }
        public Color Color
        {
            get; set;
        }
        public int Size
        {
            get; set;
        }
    }
}
