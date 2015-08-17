using System.Drawing;

namespace spritesheetr
{
    public struct ImageSettings
    {
        private static readonly ImageSettings s_Transparent = new ImageSettings() {Background = Color.Transparent};
        public static ImageSettings Transparent { get { return s_Transparent; } }

        public Color Background { get; set; }
    }
}