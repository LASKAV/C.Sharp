

namespace Exercise_1;

/*
                    Задание 1
Создайте набор методов для работы с массивами:
■ Метод для получения всех четных чисел в массиве;
■ Метод для получения всех нечетных чисел в массиве;
■ Метод для получения всех простых чисел в массиве;
■ Метод для получения всех чисел Фибоначчив массиве.
Используйте механизмы делегатов.
 
 */
// набор методов для работы с массивами
public delegate bool Filter_Arr(int num);

class Program
{
    static void Main(string[] args)
    {
        int[] _arr = {1,2,3,4,5,6,7,8,9,10};
        Console.Write($"Standard: "); Show_arr(_arr);

        Filter_Arr[] filter_arr = new Filter_Arr[10];
        filter_arr[0] += Even_numbers;
        filter_arr[1] += Odd_numbers;
        filter_arr[2] += Prime_numbers;
        filter_arr[3] += Fibonacci_numbers;

        int[] even_arr = FilterArray(_arr, filter_arr[0]);
        Console.Write($"Even: "); Show_arr(even_arr);

        int[] odd_arr = FilterArray(_arr, filter_arr[1]);
        Console.Write($"Odd: "); Show_arr(odd_arr);

        int[] prime_arr = FilterArray(_arr, filter_arr[2]);
        Console.Write($"Prime: "); Show_arr(prime_arr);

        int[] fibonacci_arr = FilterArray(_arr, filter_arr[3]);
        Console.Write($"Fibonacci: "); Show_arr(fibonacci_arr);

        Console.Read();
    }
    static void Show_arr(int[] _arr)
    {
        Console.Write("ARR: ");
        foreach (int item in _arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    // ■ Метод для получения всех четных чисел в массиве
    static bool Even_numbers(int num)
    {
        return num % 2 == 0;
    }
    // ■ Метод для получения всех нечетных чисел в массиве
    static bool Odd_numbers(int num)
    {
        return num % 2 != 0;
    }
    // ■ Метод для получения всех простых чисел в массиве
    static bool Prime_numbers(int num)
    {
        if (num <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;

    }
    // ■ Метод для получения всех чисел Фибоначчи в массиве
    static bool Fibonacci_numbers(int num)
    {
        int a = 0;
        int b = 1;

        while (b < num)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }

        return b == num;
    }
    static int[] FilterArray(int[] numbers, Filter_Arr filter)
    {
        int[] result = new int[numbers.Length];
        int index = 0;

        foreach (int number in numbers)
        {
            if (filter(number))
            {
                result[index] = number;
                index++;
            }
        }

        Array.Resize(ref result, index);

        return result;
    }
}

