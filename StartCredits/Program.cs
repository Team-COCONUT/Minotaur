using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;

namespace ConsoleImage
{
    class Program
    {
        static void Main()
        {
            Image Picture = Image.FromFile("pictures/Minotaur.jpg"); //Here we may put anything, this is just for testing purposes. :)
            Console.SetBufferSize((Picture.Width * 0x2), (Picture.Height * 0x2));
            Console.WindowWidth = 150;
            Console.WindowHeight = 61;

            FrameDimension Dimension = new FrameDimension(Picture.FrameDimensionsList[0x0]);
            int FrameCount = Picture.GetFrameCount(Dimension);
            int Left = Console.WindowLeft, Top = Console.WindowTop;
            char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
            Picture.SelectActiveFrame(Dimension, 0x0);
            for (int i = 0x0; i < Picture.Height; i++)
            {
                for (int x = 0x0; x < Picture.Width; x++)
                {
                    Color Color = ((Bitmap)Picture).GetPixel(x, i);
                    int Gray = (Color.R + Color.G + Color.B) / 0x3;
                    int Index = (Gray * (Chars.Length - 0x1)) / 0xFF;
                    Console.Write(Chars[Index]);
                }
                Console.Write('\n');
                Thread.Sleep(100);
            }
            Console.SetCursorPosition(Left, Top);
            Console.Read();
        }
    }
}