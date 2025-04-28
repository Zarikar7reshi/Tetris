using System.Drawing;
using System.Windows.Forms;

namespace TetrisFramework_4_7_2
{
    public class CampoData
    {
        public Panel campo;
        public Panel next;

        public int Width;
        public int Height;

        public Ts[,] griglia;
        public PictureBox[,] quadretti;
        public CampoData()
        {
            griglia = new Ts[20, 10];
            quadretti = new PictureBox[20, 10];

            Width = griglia.GetLength(1);
            Height = griglia.GetLength(0);

            campo = new Panel()
            {
                Location = new Point(50, 50),
                BackColor = Color.FromArgb(100, 0, 0, 0),
                Height = 320,
                Width = 160,
                BorderStyle = BorderStyle.FixedSingle,
            };
            next = new Panel()
            {
                Location = new Point(300, 50),
                BackColor = Color.FromArgb(100, 0, 0, 0),
                Height = 64,
                Width = 64,
                BorderStyle = BorderStyle.None,
            };
        }
    }
}
