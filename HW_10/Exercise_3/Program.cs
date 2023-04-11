namespace Exercise_3;

/*
                    Задание 3
Создайте лямбда-выражение для подсчёта количества чисел в массиве,
кратных семи. Напишите код для тестирования работы лямбды.

                    Задание 4
Создайте лямбда-выражение для подсчёта количства положительных чисел в массиве.
Напишите код для тестирования работы лямбды.

                    Задание 5
Создайте лямбда-выражение для отображения уникальных отрицательных
чисел в массиве. Напишите код для тестирования работы лямбды.

                    Задание 6
Создайте лямбда-выражение для проверки есть ли в тексте
заданное слово. Напишите код для тестирования работы лямбды.
 */

class Program
{
    // Лямбда-выражение для подсчета количества чисел, кратных 7
    public static Func<int, bool> MultipleSeven = num => num % 7 == 0;
    public static Func<int, bool> MultiplePositiv = num => num > 0;
    static void Main(string[] args)
    {
        int[] _arr = new int[10];
        Rand_arr_positive(_arr);
        Show_arr(_arr);
        int count = Multiples_seven(_arr, MultipleSeven);
        Rand_arr_positive_and_negative(_arr);
        Show_arr(_arr);
        int positiv = Multiples_positive(_arr, MultiplePositiv);
        var Numbers = _arr.Where(num => num < 0).Distinct();
        foreach (var num in Numbers)
        {
            Console.Write($"Уникальных отрицательных: {num}" + " ");
        }
        string[] str = { "Hello", "sada", "word", "hell" };
        var select_str = str.Where(x => x == "word");
        foreach (var item in select_str)
        {
            Console.WriteLine($"\nYou string: {item} ");
        }
        Console.Read();
    }
    public static void Rand_arr_positive(int[] _arr)
    {
        Random random = new Random();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] += random.Next(1, 100);
        }
    }
    public static void Rand_arr_positive_and_negative(int[] _arr)
    {
        Random random = new Random();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] += random.Next(-100, 100);
        }
    }
    public static void Show_arr(int[] _arr)
    {
        Console.Write("\nArr = ");
        foreach (int item in _arr)
        {
            Console.Write($"{item}" + " ");
        }
        Console.WriteLine();
    }
    public static int Multiples_seven(int[] _arr, Func<int, bool> multipleSeven)
    {
        int count = 0;
        foreach (int num in _arr)
        {
            if (multipleSeven(num))
            {
                count++;
            }
        }
        Console.WriteLine("Количество чисел в массиве, кратных 7: " + count);
        return count;
    }
    public static int Multiples_positive(int[] _arr, Func<int, bool> MultiplePositiv)
    {
        int count = 0;
        foreach (int num in _arr)
        {
            if (MultiplePositiv(num))
            {
                count++;
            }
        }
        Console.WriteLine("Количество положительных в массиве : " + count);
        return count;
    }
}

