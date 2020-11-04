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

        private int A { get; set; }
        private int B { get; set; }
        private int C { get; set; }

        public int IsValidEcuation()
        {
            return A == 0 ? 0 : Delta() == 0 ? 1 : 2;
        }

        private int Delta()
        {
            return (int) (Math.Pow(B, 2) - 4 * A * C);
        }

        public void CalculateResult()
        {
            double x1 = 0;
            double x2 = 0;
            if (Delta() >= 0)
            {
                x1 = Math.Round((-B - Math.Sqrt(Delta())) / 2 * A, 2);
                x2 = Math.Round((-B + Math.Sqrt(Delta())) / 2 * A, 2);
            }
            var valid = IsValidEcuation();
            var point = Results.Result.Length != 0 ? (Results.Result[Results.Result.Length - 1].Location.Y + 30) : 110;
            var res = new Label
            {
                Text = $@"{A} | {B} | {C} | {x1} | {x2} | {valid}", Size = new Size(150, 30),
                Location = new Point(20, point)
            };
            Array.Resize(ref Results.Result, Results.Result.Length + 1);
            Results.Result[Results.Result.Length - 1] = res;
        }
    }
}