using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcuatieGradul2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var A = new TextBox{Location = new Point(10, 10), Size = new Size(25, 20)};
            var firstValue = new Label{ Text = @"x^2 +", Location = new Point(35, 10), Size = new Size(40, 20)};
            var B = new TextBox{Location = new Point(75, 10), Size = new Size(25, 20)};
            var secondValue = new Label{ Text = @"x +", Location = new Point(100, 10), Size = new Size(25, 20)};
            var C = new TextBox{Location = new Point(125, 10), Size = new Size(25, 20)};
            var zero = new Label{Text = @"=0", Location = new Point(150, 10), Size = new Size(25, 20)};
            var random = new Button{Text = @"Random", Size = new Size(60, 20), Location = new Point(10, 40)};
            random.Click += (sender, e) => RandomNumbers(A, B, C);
            var calc = new Button{Text = @"Calc", Size = new Size(60, 20), Location = new Point(75, 40)};
            calc.Click += (sender, e) => Calculate(A, B, C, this);
            Controls.Add(A);
            Controls.Add(firstValue);
            Controls.Add(B);
            Controls.Add(secondValue);
            Controls.Add(C);
            Controls.Add(zero);
            Controls.Add(random);
            Controls.Add(calc);
        }

        public void RandomNumbers(TextBox a, TextBox b, TextBox c)
        {
            var random = new Random();
            a.Text = random.Next(-9, 9).ToString();
            b.Text = random.Next(-9, 9).ToString();
            c.Text = random.Next(-9, 9).ToString();
        }

        public void Calculate(TextBox a, TextBox b, TextBox c, Form form)
        {
            var A = Convert.ToInt16(a.Text);
            var B = Convert.ToInt16(b.Text);
            var C = Convert.ToInt16(c.Text);
            var ec = new Ecuation(A, B, C);
            var label = new Label{Text = @"A | B | C |  X1  |  X2  |  S", Size = new Size(150, 20), Location = new Point(20, 80)};
            form.Controls.Add(label);
            ec.CalculateResult(form);
            Results.ShowResults(form);
        }
    }
}