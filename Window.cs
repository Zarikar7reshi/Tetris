using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisFramework_4_7_2
{
    public partial class Window : Form
    {
        public static CampoData campo;
        public static Tetramin tetramino;     //attuale

        public static readonly Timer timer = new Timer();

        public Window()
        {
            InitializeComponent();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Game.New();
            campo = new CampoData();
            tetramino = new Tetramin();
            Inizializza();
            CenterToScreen();
        }

        //sistema il design e fa partire il timer
        private void Inizializza()
        {
            Controls.Add(campo.campo);
            Controls.Add(campo.next);
            Controls.Add(Game.lblLevel);
            Controls.Add(Game.lblLines);
            Controls.Add(Game.lblScore);
            Controls.Add(Game.lblAnimazione);
            Controls.Add(Game.label1);
            Controls.Add(Game.lblPause);
            Game.lblPause.Click += LblPause_Click;


            foreach (var img in tetramino.quadrettiAttivi)
            {
                if (img != null)
                {
                    campo.campo.Controls.Add(img);
                }
            }
            foreach (var img in tetramino.quadrettiNext)
            {
                if (img != null)
                {
                    campo.next.Controls.Add(img);
                }
            }
            timer.Interval = (int)Game.interval;

            KeyDown += Tetramino_KeyDown;
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        //corpo principale che aggiorna il gioco
        private void Timer_Tick(object sender, EventArgs e)
        {
            Game.MuoviTetramino();

            if (Game.end)
            {
                GameOver();
            }
            else
            {
                Game.Aggiorna();
            }
        }

        //quando si preme un tasto
        private void Tetramino_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Game.paused)
            {
                Keys key = e.KeyCode;

                if (key == Keys.Space)
                {
                    while (tetramino.Check(campo, 0, 1))
                    {
                        tetramino.currentY++;
                        tetramino.MuoviImmagine();
                    }
                }

                if (key == Keys.Up && tetramino.Check(campo, 0, 0))
                {
                    tetramino.RotateClockWise();
                    if (tetramino.Check(campo, 0, 0))
                    {
                        foreach (var img in tetramino.quadrettiAttivi)
                        {
                            img?.Dispose();
                        }
                        tetramino.ImageCurrent();
                    }
                    foreach (var img in tetramino.quadrettiAttivi)
                    {
                        if (img != null)
                        {
                            campo.campo.Controls.Add(img);
                        }
                    }
                }
                if (key == Keys.Left && tetramino.Check(campo, -1, 0))
                {
                    tetramino.currentX--;
                }
                if (key == Keys.Down && tetramino.Check(campo, 0, 1))
                {
                    tetramino.currentY++;
                }
                if (key == Keys.Right && tetramino.Check(campo, 1, 0))
                {
                    tetramino.currentX++;
                }
                tetramino.MuoviImmagine();
            }
        }

        //quando perdi compare statistiche, restart e quit
        private void GameOver()
        {
            campo.campo.Controls.Clear();
            campo.next.Controls.Clear();
            Controls.Clear();
            timer.Tick -= Timer_Tick;
            KeyDown -= Tetramino_KeyDown;

            Label lblStats = new Label()
            {
                Location = new Point(150, 50),
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Text = $"Level: {Game.level}\nScore: {Game.score}\nThanks for playing!",
                Font = new Font("Verdana", 13),
                Width = 300,
                Height = 80,
            };
            Controls.Add(lblStats);

            Button btnRestart = new Button()
            {
                Location = new Point(200, 200),
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Text = "Restart",
                Font = new Font("Verdana", 13),
                Width = 100,
                Height = 40,
            };
            Controls.Add(btnRestart);
            btnRestart.Click += BtnRestart_Click;

            Button btnQuit = new Button()
            {
                Location = new Point(200, 250),
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Text = "Quit",
                Font = new Font("Verdana", 13),
                Width = 70,
                Height = 40,

            };
            Controls.Add(btnQuit);
            btnQuit.Click += BtnQuit_Click;
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            OnLoad(e);
        }

        private void LblPause_Click(object sender, EventArgs e)
        {
            Game.paused = !Game.paused;
            if (Game.paused)
            {
                timer.Stop();
                Game.lblPause.Text += "D";
                Game.lblPause.ForeColor = Color.Red;
            }
            else
            {
                timer.Start();
                Game.lblPause.Text = "PAUSE";
                Game.lblPause.ForeColor = Color.LightGreen;
            }
        }
    }
}

