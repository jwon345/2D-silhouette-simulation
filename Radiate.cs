using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Radiate
{
    class Radiate
    {
        public static List<int> intList = new();

            public static void drawthis(int x,int y, Color color)
            {
                int length = 500;
                for (int i = 0; i < 360; i++)
                {
                Raylib.DrawLine(x, y, x + (int)(length * Math.Sin(i * (Math.PI/180))), y + (int)(length * Math.Cos(i * (Math.PI/180))), color);

                }
                return;
            }
    }
}
