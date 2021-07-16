using System.Drawing;

namespace Untangle
{
    class Edge : Element
    {
        public Edge (Design body, Point location)
        {
            Body = body;
            Location = location;
        }
        public Edge(Design body)
        {
            Body = body;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Body.Color, Body.Size), GameForm.Vertices[Location.X].Location.X, GameForm.Vertices[Location.X].Location.Y, GameForm.Vertices[Location.Y].Location.X, GameForm.Vertices[Location.Y].Location.Y);
        }
    }
}
