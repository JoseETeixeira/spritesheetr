using System.Drawing;
using System.Drawing.Imaging;

namespace spritesheetr
{
    public class SheetBuilder
    {
        public Bitmap CreateSheet(int spriteWidth, int spriteHeight, int numX, int numY, ImageSettings settings, GridSettings grid)
        {
            var totalWidth = ((spriteWidth + grid.Size)*numX)+grid.Size;
            var totalHeight = ((spriteHeight + grid.Size) * numY)+grid.Size;

            var image = new Bitmap(totalWidth, totalHeight, PixelFormat.Format32bppArgb);

            using (var graphics = Graphics.FromImage(image))
            {
                graphics.FillRectangle(new SolidBrush(settings.Background), 0, 0, totalWidth, totalHeight);
                
                var xoff = 0;
                for (var x = 0; x < numX; ++x)
                {
                    var yoff = 0;

                    for (var y = 0; y < numY; ++y)
                    {
                        graphics.DrawRectangle(new Pen(grid.Color),
                            new Rectangle(xoff, yoff, spriteWidth + grid.Size, spriteHeight + grid.Size));

                        yoff += (spriteHeight + grid.Size);
                    }

                    xoff += (spriteWidth + grid.Size);
                }

            }
            return image;
        }
    }
}