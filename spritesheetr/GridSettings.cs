using System.Drawing;

namespace spritesheetr
{
    public struct GridSettings
    {
        private static readonly GridSettings s_Default = new GridSettings() {Color = Color.Black, Size = 1};

        public static GridSettings Default { get { return s_Default;}}

        public Color Color { get; set; }
        public int Size { get; set; }
    }
}