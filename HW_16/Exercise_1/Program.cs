using System.Text.Json;

namespace Exercise_1;

/*
                        Задание 1:
Создайте программу для работы с массивом дробей (числитель и знаменатель).

Она должна иметь такую функциональность:
1. Ввод массива дробей с клавиатуры
2. Сериализация массива дробей
3. Сохранение сериализованного массива в файл
4. Загрузка сериализованного массива из файла.

После загрузки нужно произвести десериализацию
Выбор конкретного формата сериализации необходимо
сделать вам. Обращаем ваше внимание, что выбор должен быть обоснованным.
 */

class Program
{
    static void Main(string[] args)
    {
        Fraction[] _fraction = new Fraction[3];

        Console.WriteLine("Введите 3 дроби в формате 'числитель/знаменатель':");

        for (int i = 0; i < 3; i++)
        {
            string[] input = Console.ReadLine().Split('/');
            int numerator = int.Parse(input[0]);
            int denominator = int.Parse(input[1]);
            _fraction[i] = new Fraction(numerator, denominator);
        }
        Console.Clear();
        Console.WriteLine("Получили :");
        foreach (var item in _fraction)
        {
            Console.WriteLine(item);
        }

        string Json = JsonSerializer.Serialize(_fraction);

        Console.WriteLine($"\nПреобразовали в Json: {Json}");

        // Сохранение сериализованного массива в файл
        File.WriteAllText("fractions.json", Json);

        string JsonString = File.ReadAllText("fractions.json");

        // Десериализация массива дробей
        Fraction[] loadedFractions = JsonSerializer.Deserialize<Fraction[]>(JsonString);

        Console.WriteLine("\nСериализованный массив дробей:");
        Console.WriteLine(JsonString);
        Console.Read();
    }
}

