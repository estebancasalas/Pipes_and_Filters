using System;
using System.Drawing;

namespace CompAndDel
{
    public class Convoluter
    {
        
        
        protected Color GetFilteredColor(Color[,] sample, int[,] kernel, int divider, int complement)
        {
            int redFinal = 0;
            int greenFinal = 0;
            int blueFinal = 0;

            for (int x = 0; x < sample.GetLength(0); x++)
            {
                for (int y = 0; y < sample.GetLength(1); y++)
                {
                    redFinal += sample[x, y].R * kernel[x, y];
                    greenFinal += sample[x, y].G * kernel[x, y];
                    blueFinal += sample[x, y].B * kernel[x, y];
                }
            }

            redFinal = Math.Abs((redFinal/divider) + complement);
            redFinal = Math.Min(255, redFinal);

            greenFinal = Math.Abs((greenFinal / divider) + complement);
            greenFinal = Math.Min(255, greenFinal);

            blueFinal = Math.Abs((blueFinal / divider) + complement);
            blueFinal = Math.Min(255, blueFinal);

            return Color.FromArgb(redFinal, greenFinal, blueFinal);
        }
         protected Color[,] CreateSample(IPicture image, int x, int y)
        {
            Color[,] sample = new Color[3,3];

            sample[0,0] = image.GetColor(Math.Max(x-1, 0), Math.Max(y-1,0));
            sample[1,0] = image.GetColor(x, Math.Max(y-1,0));
            sample[2,0] = image.GetColor(Math.Min(x+1, image.Width -1), Math.Max(y-1,0));
            sample[0,1] = image.GetColor(Math.Max(x-1, 0), y);
            sample[1,1] = image.GetColor(x, y);
            sample[2,1] = image.GetColor(Math.Min(x+1, image.Width - 1),y);
            sample[0,2] = image.GetColor(Math.Max(x-1, 0), Math.Min(y+1,image.Height - 1));
            sample[1,2] = image.GetColor(x, Math.Min(y+1,image.Height - 1));
            sample[2,2] = image.GetColor(Math.Min(x+1, image.Width - 1), Math.Min(y+1,image.Height - 1));

            return sample;
        }
    }
}