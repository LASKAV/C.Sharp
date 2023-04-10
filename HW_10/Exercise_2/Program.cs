using System.Collections.Generic;
using System.Text;

namespace Exercise_2;

/*
                            Задание 2
Создайте класс рюкзак.

Характеристики рюкзака:
■ Цвет рюкзака;
■ Фирма производитель;
■ Ткань рюкзака;
■ Вес рюкзака;
■ Объём рюкзака;
■ Содержимое рюкзака (список объектов, у каждого
объекта кроме названия нужно учитывать занимаемый объём).

Создайте методы для заполнения характеристик.
Создайте событие для добавления объекта в рюкзак.
Реализуйте анонимный метод в качестве обработчика события добавления объекта.
Если при попытке добавления может быть превышен объём рюкзака,
нужно генерировать исключение.
 */

class Program
{
    static void Main(string[] args)
    {
        Backpack pack = new Backpack();
        Console.WriteLine($"{pack}");
        Console.Read();
    }
}

class Backpack
{
    private string color { get; set; }    // ■ Цвет рюкзака;
    private string firms { get; set; }    // ■ Фирма производитель;
    private string textile { get; set; }  // ■ Ткань рюкзака;
    private short weight { get; set; }    // ■ Вес рюкзака;
    private short volume { get; set; }    // ■ Объём рюкзака;
    // ■ Содержимое рюкзака
    private Dictionary<string, short> content = new Dictionary<string, short>();
    public Backpack()
    {
        color = "black";
        firms = "adidas";
        textile = "leather";
        weight = 1100;
        volume = 26;
        content.Add("Бутылки", 12);
    }
    public string GetContent()
    {
        StringBuilder sb = new StringBuilder();
        Console.Write("Содержимое рюкзака:");
        foreach (var iter in content)
        {
            sb.AppendLine($"\n{iter.Key}: {iter.Value}г");
        }
        return sb.ToString();
    }
    public override string ToString()
    {
        if (1000 > weight)
        {
            return $"___Рюкзак___" +
            $"\n■ Цвет рюкзака: {color}" +
            $"\n■ Фирма производитель: {firms} " +
            $"\n■ Ткань рюкзака: {textile}" +
            $"\n■ Вес рюкзака: {weight}г" +
            $"\n■ Объём рюкзака: {volume}" +
            $"\n■ Содержимое рюкзака: {GetContent()}";
        }
        else
        {
            return $"___Рюкзак___" +
            $"\n■ Цвет рюкзака: {color}" +
            $"\n■ Фирма производитель: {firms} " +
            $"\n■ Ткань рюкзака: {textile}" +
            $"\n■ Вес рюкзака: {weight}кг" +
            $"\n■ Объём рюкзака: {volume}" +
            $"\n■ Содержимое рюкзака: {GetContent()}";
        }

    }

}
