using System.Drawing;

namespace Untangle
{
    public abstract class Element
    {
        public Design Body;
        public Point Location;
        public abstract void Draw(Graphics graphics);
    }
}
