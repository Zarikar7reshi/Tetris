using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TetrisFramework_4_7_2
{
    public static class Game
    {
        private static readonly int baseinterval = 700;

        public static int lines;    //linee completate
        public static int score;    //punteggio attuale
        public static int level;    //livello attuale (=linee/10)
        public static Label lblLines;
        public static Label lblScore;
        public static Label lblLevel;
        public static Label lblAnimazione;
        public static Label label1;
        public static Label lblPause;

        public static bool end = false;     //se il gioco è finito o no
        public static bool paused = false;     //se il gioco è in pausa o no

        public static readonly int quadretto = 16;
        public static double interval = baseinterval;

        public const string location = "./Assets/";
        public static readonly string[] immaginiQuadretti = { "Giallo.png", "Azzurro.png", "Viola.png", "Arancio.png", "Blu.png", "Verde.png", "Rosso.png" };
        public static readonly Image[] images = new Image[immaginiQuadretti.Length];

        //costruttore statico per creare il vettore dei quadretti colorati
        //se no dovrebbe leggere ogni volta dal disco e quindi aumentare troppo la ram occupata
        static Game()
        {
            for (int i = 0; i < immaginiQuadretti.Length; i++)
            {
                images[i] = Image.FromFile(location + immaginiQuadretti[i]);
            }
        }

        //nuova partita
        public static void New()
        {
            lines = 0;
            score = 0;
            level = 0;
            end = false;
            paused = false;

            label1 = new Label()
            {
                Text = "NEXT:",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Font = new Font("Verdana", 13),
                Location = new Point(260, 9),
                AutoSize = true
            };
            lblPause = new Label()
            {
                Text = "PAUSE",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Location = new Point(12,9),
                Font = new Font("Verdana", 13),
                Width = 66,
                Height = 20,
                AutoSize = true
            };
            lblLevel = new Label()
            {
                Text = $"Level: {level}",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Location = new Point(300, 200),
                Font = new Font("Verdana", 13),
                Width = 150,
                Height = 30,
            };
            lblScore = new Label()
            {
                Text = $"Score: {score}",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Location = new Point(300, 250),
                Font = new Font("Verdana", 13),
                Width = 150,
                Height = 30,
            };
            lblLines = new Label()
            {
                Text = $"Lines: {lines}",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Location = new Point(300, 300),
                Font = new Font("Verdana", 13),
                Width = 150,
                Height = 30,
            };
            lblAnimazione = new Label()
            {
                Text = "",
                BackColor = Color.Black,
                ForeColor = Color.LightGreen,
                Location = new Point(300, 150),
                Font = new Font("Verdana", 13),
                Width = 150,
                Height = 30,
            };
        }

        //controlla se ci sono righe complete, se sì le cancella
        //calcola le righe a partire dalla y del tetramino per risparmiare potenza
        //(è impossibile che il tetramino sia passato attraverso una linea già completata)
        public static int DeleteCompletedLines(CampoData campo, int yTetramino)
        {
            int completedLines = 0;
            for (int y = yTetramino; y < campo.Height; y++)
            {
                int x = 0;
                while (x < campo.Width)
                {
                    if (campo.griglia[y, x] == Ts.NULL)
                        break;
                    x++;
                }

                if (x == campo.Width)
                {
                    DeleteOneLine(campo, y);
                    completedLines++;
                }
            }
            score += 5 * campo.Width * completedLines;
            return completedLines;
        }

        //cancella la riga in posizione row
        public static void DeleteOneLine(CampoData campo, int row)
        {

            Ts[,] tmp = campo.griglia;
            DeleteOneMatrixRow(ref tmp, row);
            campo.griglia = tmp;

            PictureBox[,] temp = campo.quadretti;

            for (int x = 0; x < campo.Width; x++)
                temp[row, x]?.Dispose();

            DeleteOneMatrixRow(ref temp, row);

            for (int y = row; y >= 0; y--)
                for (int x = 0; x < campo.Width; x++)
                    if (campo.quadretti[y, x] != null)
                        campo.quadretti[y, x].Top += quadretto;

            campo.quadretti = temp;

            lines++;
            if (lines % 10 == 0)
            {
                level++;
                interval *= 0.95;
            }
        }

        //sposta verso il basso tutte le righe di una matrice a partire da row
        public static void DeleteOneMatrixRow<T>(ref T[,] matrix, int row)
        {
            for (int y = row; y > 0; y--)
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    matrix[y, x] = matrix[y - 1, x];
                }
        }

        //visualizza i valori aggiornati
        public static void Aggiorna()
        {
            lblLevel.Text = $"Level: {level}";
            lblLines.Text = $"Lines: {lines}";
            lblScore.Text = $"Score: {score}";
            Window.timer.Interval = (int)interval;
        }

        //muove il tetramino se possibile
        public static void MuoviTetramino()
        {
            lblAnimazione.Text = "";
            if (!Window.tetramino.Check(Window.campo, 0, 0))
            {
                if (Window.tetramino.currentX < 0)
                {
                    Window.tetramino.currentX++;
                }
                else if (Window.tetramino.currentY < 0)
                {
                    Window.tetramino.currentY++;
                }
                else
                {
                    Window.tetramino.currentX--;
                }
                Window.tetramino.MuoviImmagine();
                return;
            }

            //il tetramino si può ancora muovere verso il basso
            if (Window.tetramino.Check(Window.campo, 0, 1))
            {
                Window.tetramino.Muovi();
                return;
            }

            else        //non si può andare più giù
            {
                CopiaNelCampo(Window.tetramino, in Window.campo);
                int linesDeleted = DeleteCompletedLines(Window.campo, Window.tetramino.currentY);
                Animation(linesDeleted);
                //il tetramino tocca la parte superiore dello schermo
                if (Window.tetramino.currentY <= 0)
                {
                    end = true;
                }
                else
                {
                    //cancella le immagini presenti nell'angolo next
                    foreach (var img in Window.tetramino.quadrettiNext)
                    {
                        if (img != null)
                        {
                            Window.campo.next.Controls.Remove(img);
                        }
                    }

                    //linea critica: disallinea il tetramino corrente da quello successivo
                    //Window.tetramino = new Tetramin();
                    Window.tetramino.currentX = 3;
                    Window.tetramino.currentY = 0;
                    Window.tetramino.rotateIndex = 0;
                    Window.tetramino.Next();
                    Window.tetramino.ImageCurrent();
                    Window.tetramino.Generate();
                    Window.tetramino.ImageNext();


                    foreach (var img in Window.tetramino.quadrettiAttivi)
                    {
                        if (img != null)
                        {
                            Window.campo.campo.Controls.Add(img);
                        }
                    }

                    foreach (var img in Window.tetramino.quadrettiNext)
                    {
                        if (img != null)
                        {
                            Window.campo.next.Controls.Add(img);
                        }
                    }
                }
            }
        }

        private static void Animation(int linesDeleted)
        {
            switch (linesDeleted)
            {
                case 2:
                    lblAnimazione.Text = "DOUBLE";
                    return;
                case 3:
                    lblAnimazione.Text = "TRIPLE";
                    return;
                case 4:
                    lblAnimazione.Text = "TETRIS!";
                    return;
                default: return;
            }
        }

        //copia matrice e immagine associata nelle griglie del campo
        private static void CopiaNelCampo(Tetramin tetramino, in CampoData campo)
        {
            for (int pY = 0; pY < 4; pY++)
            {
                for (int pX = 0; pX < 4; pX++)
                {
                    if (tetramino.tetramins[tetramino.rotateIndex, tetramino.index][pY, pX] != Ts.NULL)
                    {
                        campo.griglia[tetramino.currentY + pY, tetramino.currentX + pX] = tetramino.tetramins[tetramino.rotateIndex, tetramino.index][pY, pX];
                        campo.quadretti[tetramino.currentY + pY, tetramino.currentX + pX] = tetramino.quadrettiAttivi[pY, pX];
                    }
                }
            }
        }
    }
}