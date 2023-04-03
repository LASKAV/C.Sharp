using System.Drawing;
using System.Text;

namespace Exercise_3;

/*
                Задание 3
Создайте структуру «RGB цвет».
Определите внутри неё необходимые поля и методы.
Реализуйте следующую функциональность:
■ Перевод в HEX формат;
■ Перевод в HSL;
■ Перевод в CMYK.
 
 */

struct RGBColor
{
    public byte R;
    public byte G;
    public byte B;

    public RGBColor(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public string ToHex()
    {
        var sb = new StringBuilder();
        sb.Append(BitConverter.ToString(new byte[] { R }));
        sb.Append(BitConverter.ToString(new byte[] { G }));
        sb.Append(BitConverter.ToString(new byte[] { B }));
        return sb.ToString().Replace("-", "");
    }

    public string ToHsl()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h = 0, s = 0, l = (max + min) / 2;

        if (max == min)
        {
            h = s = 0;
        }
        else
        {
            double d = max - min;
            s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
            switch (max)
            {
                case var _ when Math.Abs(r - max) < double.Epsilon:
                    h = (g - b) / d + (g < b ? 6 : 0);
                    break;
                case var _ when Math.Abs(g - max) < double.Epsilon:
                    h = (b - r) / d + 2;
                    break;
                case var _ when Math.Abs(b - max) < double.Epsilon:
                    h = (r - g) / d + 4;
                    break;
            }
            h /= 6;
        }
        return $"H: {h * 360:0}, S: {s * 100:0}%, L: {l * 100:0}%";
    }


    public string ToCmyk()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double k = 1 - Math.Max(r, Math.Max(g, b));
        double c = (1 - r - k) / (1 - k);
        double m = (1 - g - k) / (1 - k);
        double y = (1 - b - k) / (1 - k);

        return $"C: {c * 100:0}%, M: {m * 100:0}%, Y: {y * 100:0}%, K: {k * 100:0}%";
    }
}
class Program
{ 
    static void Main(string[] args)
    {
        RGBColor rGB = new RGBColor(200, 100, 50);
        Console.WriteLine($"HEX format: {rGB.ToHex()}");
        Console.WriteLine($"HSL format: {rGB.ToHsl()}");
        Console.WriteLine($"CMYK format: {rGB.ToCmyk()}");

        Console.Read();
    }
}

