using System.Drawing;

namespace Untangle
{
    public class Vertex : Element
    {
        public Vertex(Design body, Point location)
        {
            Body = body;
            Location = location;
        }
        public Vertex(Vertex vertex)
        {
            Body = vertex.Body;
            Location = vertex.Location;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(Body.Color), Location.X - Body.Size / 2, Location.Y - Body.Size / 2, Body.Size, Body.Size);
        }
    }
}
