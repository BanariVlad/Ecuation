using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;

namespace EcuatieGradul2
{
    public class Ecuation
    {
        public Ecuation(short a, short b, short c)
        {
            A = a;
            B = b;
            C = c;
        }

        private int A;
        private int B;
        private static int C;

        private int IsValidEcuation()
        {
            return A == 0 || Delta() <= 0 ? 0 : Delta() == 0 ? 1 : 2;
        }

        private int Delta()
        {
            return (int) (Math.Pow(B, 2) - 4 * A * C);
        }

        public void CalculateResult(Form form)
        {
            var validEc = IsValidEcuation();
            double x1 = 0;
            double x2 = 0;
            if (validEc == 1 || validEc == 2)
            {
                x1 = Math.Round((-B - Math.Sqrt(Delta())) / 2 * A, 2);
                x2 = Math.Round((-B + Math.Sqrt(Delta())) / 2 * A, 2);
            }

            var valid = IsValidEcuation();
            var point = Results.Result.Length != 0 ? (Results.Result[Results.Result.Length - 1].Location.Y + 30) : 110;
            var res = new Label
            {
                Text = $@"{A} | {B} | {C} | {x1} | {x2} | {valid}", Size = new Size(150, 30),
                Location = new Point(20, point),
                Cursor = Cursors.Cross
            };
            res.Click += (sender, args) => GenerateGraphic(form);
            Array.Resize(ref Results.Result, Results.Result.Length + 1);
            Results.Result[Results.Result.Length - 1] = res;
        }

        private static void GenerateGraphic(Form form)
        {
            var pictureBox = new PictureBox {Location = new Point(350, 200), Size = new Size(800, 800)};
            var bmp = new Bitmap(3500, 3500);
            var graphic = Graphics.FromImage(bmp);
            var pen = new Pen(Color.Black, 2);
            graphic.DrawLine(pen, 0, 200, 400, 200);
            graphic.DrawLine(pen, 200, 0, 200, 400);
            pictureBox.Image = bmp;
            GeneratePoints(graphic);
            form.Controls.Add(pictureBox);
        }

        private static void GeneratePoints(Graphics graphic)
        {
            var pen = new Pen(Color.Black, 1);
            for (double i = -200; i <= 200; i += 0.2)
            {
                var point1 = new Point((int) i / 20 * 2, (int) -Fx(i) * 200);
                var point2 = new Point((int) -i * 200, (int) Fx(i) * 200);
                graphic.DrawLine(pen, point1, point2);
            }
        }

        private static double Fx(double x)
        {
            return Math.Pow(x, 2) + x + C;
        }
    }
}