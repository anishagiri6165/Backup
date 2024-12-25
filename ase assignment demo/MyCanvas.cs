using System;
using System.Drawing; // Required for GDI+ drawing
using BOOSE;

namespace ase_assignment_demo
{
    class MyCanvas : ICanvas
    {
        private int xpos;
        private int ypos;
        private Color penColour;
        private Bitmap bitmap;

        public MyCanvas(int width, int height)
        {
            Set(width, height); // Initialize canvas dimensions
            penColour = Color.Black; // Default pen color
        }

        public int Xpos
        {
            get => xpos;
            set => xpos = value;
        }

        public int Ypos
        {
            get => ypos;
            set => ypos = value;
        }

        public object PenColour
        {
            get => penColour;
            set => penColour = (Color)value;
        }

        public void Circle(int radius, bool filled)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Brush brush = new SolidBrush(penColour))
                using (Pen pen = new Pen(penColour))
                {
                    if (filled)
                        g.FillEllipse(brush, Xpos - radius, Ypos - radius, radius * 2, radius * 2);
                    else
                        g.DrawEllipse(pen, Xpos - radius, Ypos - radius, radius * 2, radius * 2);
                }
            }
        }

        public void Clear()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Clear canvas to white
            }
        }

        public void DrawTo(int x, int y)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(penColour))
                {
                    g.DrawLine(pen, Xpos, Ypos, x, y);
                }
            }
            MoveTo(x, y); // Update the cursor position
        }

        public object getBitmap()
        {
            return bitmap;
        }

        public void MoveTo(int x, int y)
        {
            Xpos = x;
            Ypos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Brush brush = new SolidBrush(penColour))
                using (Pen pen = new Pen(penColour))
                {
                    if (filled)
                        g.FillRectangle(brush, Xpos, Ypos, width, height);
                    else
                        g.DrawRectangle(pen, Xpos, Ypos, width, height);
                }
            }
        }

        public void Reset()
        {
            Clear();
            MoveTo(0, 0);
            penColour = Color.Black;
        }

        public void Set(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            Clear(); // Clear the canvas initially
        }

        public void SetColour(int red, int green, int blue)
        {
            penColour = Color.FromArgb(red, green, blue);
        }

        public void Tri(int width, int height)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(penColour))
                {
                    Point[] points =
                    {
                        new Point(Xpos, Ypos),
                        new Point(Xpos + width / 2, Ypos - height),
                        new Point(Xpos + width, Ypos)
                    };
                    g.DrawPolygon(pen, points);
                }
            }
        }

        public void WriteText(string text)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Brush brush = new SolidBrush(penColour))
                {
                    Font font = new Font("Arial", 12);
                    g.DrawString(text, font, brush, Xpos, Ypos);
                }
            }
        }
    }
}
