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
    public int R;
    public int G;
    public int B;

    public RGBColor(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public string ToHex()
    {
        string hexR = R.ToString("X2");
        string hexG = G.ToString("X2");
        string hexB = B.ToString("X2");
        return $"#{hexR}{hexG}{hexB}";
    }
    public string ToHSL()
    {
        // Нормализуем значения цветов в пределах [0, 1]
        float r = R / 255f;
        float g = G / 255f;
        float b = B / 255f;

        // Находим максимальное и минимальное значение из трех цветов
        float max = Math.Max(r, Math.Max(g, b));
        float min = Math.Min(r, Math.Min(g, b));

        // Находим разницу между максимальным и минимальным значением
        float delta = max - min;

        // Вычисляем яркость
        float lightness = (max + min) / 2f;

        // Если цвет оттенковый, то насыщенность равна 0
        if (delta == 0f)
        {
            return $"HSL(0, 0%, {(int)(lightness * 100)}%)";
        }

        // Вычисляем насыщенность
        float saturation = delta / (lightness < 0.5f ? (2f * lightness) : (2f - 2f * lightness));

        // Вычисляем оттенок
        float hue = 0f;
        if (r == max)
        {
            hue = (g - b) / delta;
        }
        else if (g == max)
        {
            hue = 2f + (b - r) / delta;
        }
        else if (b == max)
        {
            hue = 4f + (r - g) / delta;
        }
        hue *= 60f;
        if (hue < 0f)
        {
            hue += 360f;
        }

        return $"HSL({(int)hue}, {(int)(saturation * 100)}%, {(int)(lightness * 100)}%)";
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
        Console.WriteLine($"HSL format: {rGB.ToHSL()}");
        Console.WriteLine($"CMYK format: {rGB.ToCmyk()}");

        Console.Read();
    }
}

