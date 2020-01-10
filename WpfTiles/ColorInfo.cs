using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Media;

namespace WpfTiles
{
    class ColorInfo
    {
        public string Name { get; }
        public Color Color { get; }
        public string HexValue => Color.ToString();
        public Brush Brush => new SolidColorBrush(Color);

        public ColorInfo(string name, Color color)
        {
            Name = GetTitleName(name);
            Color = color;
        }

        public override string ToString() => $"{Name}";

        string GetTitleName(string name)
        {
            var sb = new StringBuilder(name.Length + 3);
            foreach(var ch in name)
            {
                if (char.IsUpper(ch) && sb.Length > 0)
                    sb.Append(' ');
                sb.Append(ch);
            }
            return sb.ToString();
        }

        public static IEnumerable<ColorInfo> EnumerateAllColors()
        {
            foreach (var property in typeof(Colors).GetProperties())
            {
                var color = (Color) property.GetValue(null, null);
                yield return new ColorInfo(property.Name, color);
            }
        }
    }
}
