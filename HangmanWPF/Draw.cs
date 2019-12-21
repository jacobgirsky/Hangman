using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HangmanWPF
{
    class Draw
    {
        private Canvas canvas;

        public Draw(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void DrawLine(int x1, int y1, int x2, int y2, int stroke)
        {
            Line myLine = new Line();
            myLine.Stroke = Brushes.Black;
            myLine.X1 = x1;
            myLine.Y1 = y1;
            myLine.X2 = x2;
            myLine.Y2 = y2;
            myLine.StrokeThickness = stroke;
            canvas.Children.Add(myLine);
        }

        private void DrawCircle(int height, int width, int top, int right)
        {
            Ellipse head = new Ellipse();
            head.Height = height;
            head.Width = width;
            head.Fill = Brushes.White;
            head.Stroke = Brushes.Black;
            head.StrokeThickness = 2;
            Canvas.SetTop(head, top);
            Canvas.SetRight(head, right);
            canvas.Children.Add(head);
        }

        public void DrawBody(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }

        public void DrawLeftArm(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }

        public void DrawRightArm(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }

        public void DrawLeftLeg(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }

        public void DrawRightLeg(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }

        public void DrawHead(int height, int width, int top, int right)
        {
            DrawCircle(height, width, top, right);
        }

        public void DrawLeftEye(int height, int width, int top, int right)
        {
            DrawCircle(height, width, top, right);
        }

        public void DrawRightEye(int height, int width, int top, int right)
        {
            DrawCircle(height, width, top, right);
        }

        public void DrawMouth(int x1, int y1, int x2, int y2, int stroke)
        {
            DrawLine(x1, y1, x2, y2, stroke);
        }
    }


}
