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
        pack.ItemAdded += (item) => Console.WriteLine($"Добавлен объект: {item}"); // Анонимный метод в качестве обработчика события
        pack.AddItem("Книга", 500, 1); // Добавляем объект в рюкзак
        Console.WriteLine($"{pack}");
        Console.Read();
    }
}

class Backpack
{
    private string color { get; set; }    // ■ Цвет рюкзака
    private string firm { get; set; }     // ■ Фирма производитель
    private string textile { get; set; }  // ■ Ткань рюкзака
    private int weight { get; set; }      // ■ Вес рюкзака
    private int volume { get; set; }      // ■ Объём рюкзака
    private Dictionary<string, int>      // ■ Содержимое рюкзака
        content = new Dictionary<string, int>();

    public event Action<string> ItemAdded;   // событие для добавления
                                             // объекта в рюкзак.

    public Backpack()
    {
        color = "black";
        firm = "adidas";
        textile = "leather";
        weight = 1100;
        volume = 26;
        content.Add("Бутылки", 12);
    }

    public void AddItem(string itemName, int itemWeight, int itemVolume)
    {
        if (content.Count >= volume) // Проверяем, не превышен ли объем рюкзака
        {
            throw new Exception("Ошибка: рюкзак уже заполнен!");
        }
        if (itemVolume > volume - content.Count) // Проверяем, достаточно ли места для добавления объекта в рюкзак
        {
            throw new Exception("Ошибка: недостаточно места в рюкзаке!");
        }
        content.Add(itemName, itemWeight);
        ItemAdded?.Invoke(itemName); // Вызываем событие добавления объекта
    }

    public string GetContent()
    {
        StringBuilder str = new StringBuilder();
        Console.WriteLine("Содержимое рюкзака:");
        foreach (var iter in content)
        {
            str.AppendLine($"{iter.Key}: {iter.Value}г");
        }
        return str.ToString();
    }

    public override string ToString()
    {
        if (1000 > weight)
        {
            return $"___Рюкзак___" +
            $"\n■ Цвет рюкзака: {color}" +
            $"\n■ Фирма производитель: {firm} " +
            $"\n■ Ткань рюкзака: {textile}" +
            $"\n■ Вес рюкзака: {weight}г" +
            $"\n■ Объём рюкзака: {volume}" +
            $"\n■ Содержимое рюкзака: {GetContent()}";
        }
        else
        {
            return $"___Рюкзак___" +
            $"\n■ Цвет рюкзака: {color}" +
            $"\n■ Фирма производитель: {firm} " +
            $"\n■ Ткань рюкзака: {textile}" +
            $"\n■ Вес рюкзака: {weight}кг" +
            $"\n■ Объём рюкзака: {volume}" +
            $"\n■ Содержимое рюкзака: {GetContent()}";
        }

    }

}
