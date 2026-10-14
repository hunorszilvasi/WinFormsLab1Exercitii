using System.Drawing;
using System.Collections.Generic;
namespace WinFormsLab1Exercitii
{
    public partial class Form1 : Form
    {
        private readonly Random veletlen = new Random();
        private readonly List<Rectangle> alakzatok = new List<Rectangle>();
        private readonly System.Windows.Forms.Timer ido =
            new System.Windows.Forms.Timer();
        private bool fut = false;
        public Form1()
        {
            InitializeComponent();
            button1.MouseEnter += Elem_MouseEnter;
            button2.MouseEnter += Elem_MouseEnter;
            button3.MouseEnter += Elem_MouseEnter;
            button4.MouseEnter += Elem_MouseEnter;
            label1.MouseEnter += Elem_MouseEnter;

            this.Paint += Form1_Paint;

            ido.Interval = 700;
            ido.Tick += Ido_Tick;
            ido.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Left = Math.Max(0, label1.Left - 20);
            //button2.Text = "Megváltozott!";
            //fut = !fut;
            //button2.BackColor = fut ? Color.Green : Color.Red;
            label1.Location = new Point(
                20,
                ClientSize.Height - label1.Height - 20);
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
            label1.ForeColor = Color.Blue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Left = Math.Min(ClientSize.Width - label1.Width, label1.Left + 20);
            //button1.Text = "Megváltozott!";
            //fut = !fut;
            //button1.BackColor = fut ? Color.Green : Color.Red;
            label1.Location = new Point(
                20,
                ClientSize.Height - label1.Height - 20);
            label1.Font = new Font("Arial", 14, FontStyle.Italic);
            label1.ForeColor = Color.Red;


        }


        private void button3_Click(object sender, EventArgs e)
        {
            //label1.Top = Math.Max(0, label1.Top - 20);
            //button4.Text = "Megváltozott!";
            //fut = !fut;
            //button4.BackColor = fut ? Color.Green : Color.Red;
            //label1.Location = new Point(20, 20);
            label1.Location = new Point(20, 20);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //label1.Top = Math.Min(ClientSize.Height - label1.Height, label1.Top + 20);
            //button3.Text = "Megváltozott!";
            //fut = !fut;
            //button3.BackColor = fut ? Color.Green : Color.Red;
            //label1.Location = new Point(
            //    20,
            //    ClientSize.Height - label1.Height - 20);
            label1.Location = new Point(
                20,
                ClientSize.Height - label1.Height - 20);
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (label1.Left < ClientSize.Width / 2)
            {
                label1.Location = new Point(
                    ClientSize.Width - label1.Width - 20,
                    ClientSize.Height - label1.Height - 20);
            }
            else
            {
                label1.Location = new Point(20, 20);
            }
        }
        private void Elem_MouseEnter(object sender, EventArgs e)
        {
            //Location = new Point(Left + 30, Top + 30);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int szelesseg = 250;
            int magassag = 150;
            int x = (ClientSize.Width - szelesseg) / 2;
            int y = (ClientSize.Height - magassag) / 2;

            using (Pen toll = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(toll, x, y, szelesseg, magassag);

                e.Graphics.DrawLine(toll, x, y, x + szelesseg, y + magassag);
                e.Graphics.DrawLine(toll, x + szelesseg, y, x, y + magassag);
            }

            Color[] szinek = { Color.Red, Color.Blue, Color.Green, Color.Purple };

            for (int i = 0; i < alakzatok.Count; i++)
            {
                using (Pen toll = new Pen(szinek[i % szinek.Length], 2))
                {
                    if (i % 2 == 0)
                        e.Graphics.DrawEllipse(toll, alakzatok[i]);
                    else
                        e.Graphics.DrawRectangle(toll, alakzatok[i]);
                }
            }
        }
        private void Ido_Tick(object sender, EventArgs e)
        {
            int szelesseg = veletlen.Next(20, 70);
            int magassag = veletlen.Next(20, 70);

            int x = veletlen.Next(Math.Max(1, ClientSize.Width - szelesseg));
            int y = veletlen.Next(Math.Max(1, ClientSize.Height - magassag));

            alakzatok.Add(new Rectangle(x, y, szelesseg, magassag));
            Invalidate();
        }
    }
}
