using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisFramework_4_7_2
{
    public class Tetramin : Tetramins
    {

        //TODO: coordinate in Point
        public int currentX = 3;
        public int currentY = 0;
        public PictureBox[,] quadrettiAttivi = new PictureBox[4, 4];
        public PictureBox[,] quadrettiNext = new PictureBox[4, 4];

        public int rotateIndex;
        public int index;
        public int nextRotateIndex;
        public int nextIndex;

        //inizializza il tetramino
        public Tetramin()
        {
            Generate();     
            Next();
            ImageCurrent();    // Crea le immagini da visualizzare nel campo
            Generate();     // Genera il tetramino successivo
            ImageNext();     // Crea le immagini da vedere nell'angolo del successivo
            MuoviImmagine();
        }

        public void ImageNext()
        {
            quadrettiNext = new PictureBox[4, 4];

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (tetramins[nextRotateIndex, nextIndex][y, x] != Ts.NULL)
                    {
                        quadrettiNext[y, x] = new PictureBox()
                        {
                            Width = 16,
                            Height = 16,
                            BackgroundImage = Game.images[nextIndex],
                            Location = new Point(x * Game.quadretto, y * Game.quadretto),
                            Visible = true,
                        };
                    }
                }
            }
        }

        //ruota in senso orario controllando eventuali collisioni
        public void RotateClockWise()
        {
            try
            {
                rotateIndex++;
                _ = tetramins[rotateIndex, index][0, 0];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.StackTrace);
                rotateIndex %= 4;
            }
        }
        //ruota in senso antiorario controllando eventuali collisioni
        public void RotateAntiClockWise()
        {
            RotateClockWise();
            RotateClockWise();
            RotateClockWise();
        }

        //genera random un tetramino con gli indici (per selezionare il tetramino senza ricopiarlo tanto è readonly)
        public void Generate()
        {
            nextIndex = new Random().Next(0, 7);
            nextRotateIndex = new Random().Next(0, 4);
        }

        //il successivo diventa attuale
        public void Next()
        {
            index = nextIndex;
            rotateIndex = nextRotateIndex;
        }
        //crea le immagini da visualizzare, che si muovono
        public void ImageCurrent()
        {
            quadrettiAttivi = new PictureBox[4, 4];
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (tetramins[rotateIndex, index][y, x] != Ts.NULL)
                    {
                        quadrettiAttivi[y, x] = new PictureBox()
                        {
                            Width = 16,
                            Height = 16,
                            BackgroundImage = Game.images[index],
                            Location = new Point((x + currentX) * Game.quadretto, (y + currentY) * Game.quadretto),
                            Visible = true,
                        };
                    }
                }
            }
        }

        //controlla se il tetramino si sovrappone ad un altro o esce dai bordi della mappa, se no lo muove
        public bool Check(CampoData campo, int nX, int nY)
        {
            for (int mY = currentY, pY = 0; mY < currentY + 4; mY++, pY++)    //mX = x sulla mappa, pX = x sul pezzo
            {
                for (int mX = currentX, pX = 0; mX < currentX + 4; mX++, pX++)    //mY = y sulla mappa, pY = y sul pezzo
                {
                    if (quadrettiAttivi[pY, pX] != null)
                    {
                        int x = quadrettiAttivi[pY, pX].Location.X;
                        int y = quadrettiAttivi[pY, pX].Location.Y;

                        if (x % 16 < 0 || x % 16 > campo.Width - 1 || y % 16 > campo.Height - 1)
                            return false;
                        if (mY + nY > campo.Height - 1 || mX + nX > campo.Width - 1 || mX + nX < 0)
                            return false;
                        if (campo.griglia[mY + nY, mX + nX] != Ts.NULL)
                            return false;
                    }
                }
            }
            return true;
        }

        //muove la griglia di picturebox associata a griglia
        public void MuoviImmagine()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (quadrettiAttivi[y, x] != null)
                    {
                        quadrettiAttivi[y, x].Location = new Point(
                            (currentX + x) * Game.quadretto,
                            (currentY + y) * Game.quadretto
                            );
                    }
                }
            }
        }

        //sposta il tetramino
        public void Muovi()
        {
            currentY++;                   //sposta il tetramino
            foreach (var img in quadrettiAttivi)      //riallinea le immagini
            {
                if (img != null)
                {
                    img.Top += Game.quadretto;
                }
            }
        }
    }
}
