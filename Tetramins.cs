using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFramework_4_7_2
{
    public class Tetramins
    {
        public Ts[,][,] tetramins { get; } = new Ts[,][,]
        {
            // Pieces at 0 degrees
            {
                // O
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // I
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.I,Ts.I,Ts.I,Ts.I},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // T
                new Ts[,]
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.T,Ts.NULL,Ts.NULL},
                    {Ts.T,Ts.T,Ts.T,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // L
                new Ts[,]  
                {
                    {Ts.NULL,Ts.L,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.L,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.L,Ts.L,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // J
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // S
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.S,Ts.S},
                    {Ts.NULL,Ts.S,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // Z
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.Z,Ts.Z,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
            },
            // Pieces at 90 degrees
            {
                // O
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // I ruotata di 90° orario
                new Ts[,] 
                {
                    {Ts.NULL,Ts.I,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.I,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.I,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.I,Ts.NULL,Ts.NULL},
                },
                // T ruotata di 90°
                new Ts[,]  
                {
                    {Ts.NULL,Ts.T,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.T,Ts.T,Ts.NULL},
                    {Ts.NULL,Ts.T,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // L ruotata di 90°
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.L,Ts.L,Ts.L},
                    {Ts.NULL,Ts.L,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // J ruotata di 90°
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.J,Ts.J},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // S ruotata di 90°
                new Ts[,]  
                {
                    {Ts.NULL,Ts.S,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.S,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                // Z ruotata di 90°
                new Ts[,]  
                {
                    {Ts.NULL,Ts.NULL,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
            },
            // Pieces at 180 degrees
            {
                new Ts[,]  // O
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // I ruotata di 180°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.I,Ts.I,Ts.I,Ts.I},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // T ruotata di 180°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.T,Ts.T,Ts.T},
                    {Ts.NULL,Ts.NULL,Ts.T,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // L ruotata di 180°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.L,Ts.L,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.L,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.L,Ts.NULL},
                },
                new Ts[,]  // J ruotata di 180°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.J,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // S ruotata di 180° (uguale a S)
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.S,Ts.S},
                    {Ts.NULL,Ts.S,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // Z ruotata di 180° (uguale a Z)
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.Z,Ts.Z,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
            },
            // Pieces at 270 degrees
            {
                new Ts[,]  // O
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.O,Ts.O,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,] // I ruotata di 270° orario
                {
                    {Ts.NULL,Ts.NULL,Ts.I,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.I,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.I,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.I,Ts.NULL},
                },
                new Ts[,]  // T ruotata di 270°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.T,Ts.NULL},
                    {Ts.NULL,Ts.T,Ts.T,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.T,Ts.NULL},
                },
                new Ts[,]  // L ruotata di 270°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.L,Ts.NULL},
                    {Ts.L,Ts.L,Ts.L,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // J ruotata di 270°
                {
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                    {Ts.J,Ts.J,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.J,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // S ruotata di 270° (uguale a 90°)
                {
                    {Ts.NULL,Ts.S,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.S,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.S,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
                new Ts[,]  // Z ruotata di 270° (uguale a 90°) index = 27
                {
                    {Ts.NULL,Ts.NULL,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.Z,Ts.NULL},
                    {Ts.NULL,Ts.Z,Ts.NULL,Ts.NULL},
                    {Ts.NULL,Ts.NULL,Ts.NULL,Ts.NULL},
                },
            },
        };
    }
}
