using System;
using System.Drawing.Imaging;
using NDesk.Options;

namespace spritesheetr
{
    class Program
    {
        static void Main(string[] args)
        {
            var showHelp = false;
            int spriteWidth = 64;
            int spriteHeight = 64;
            int numX = 12;
            int numY = 10;
            string output = null;

            var options = new OptionSet()
            {
                {"x|numX=", "number of sprites across", (int v) => numX = v},
                {"y|numY=", "number of sprites high", (int v) => numY = v},
                {"w|width=", "sprite width", (int v) => spriteWidth = v},
                {"h|height=", "sprite height", (int v) => spriteHeight = v},
                {"o|output=", "output file", v => output = v},
                {"?|help", "help", v => showHelp = v != null},
            };

            try
            {
                var extra = options.Parse(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Try 'spritesheetr' --help for more options");
                return;
            }

            if (showHelp)
            {
                ShowHelp(options);
                return;
            }

            if (string.IsNullOrEmpty(output))
            {
                Console.WriteLine("Output name is missing");
                Console.WriteLine("Try 'spritesheetr' --help for more options");
                return;
            }

            var builder = new SheetBuilder();
            var img = builder.CreateSheet(spriteWidth, spriteHeight, numX, numY, ImageSettings.Transparent, GridSettings.Default);
            img.Save(output, ImageFormat.Png);
        }

        static void ShowHelp(OptionSet options)
        {
            Console.WriteLine("Usage: spritesheetr -x=6 -y=4 -w=64 -h=64 -o=outputfile.png");
            Console.WriteLine();
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
