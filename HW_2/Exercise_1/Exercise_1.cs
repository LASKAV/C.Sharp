namespace HW_2;
using System.Xml.Linq;


/*
                                    Задание 1
Объявить одномерный (5 элементов) массив с именем A и двумерный массив
(3 строки, 4 столбца) дробных чисел с именем B. Заполнить одномерный
массив А числами, введенными с клавиатуры пользователем, а двумерный
массив В случайными числами с помощью циклов. Вывести на экран значения
массивов: массива А в одну строку, массива В — в виде матрицы.
Найти в данных массивах общий максимальный элемент, минимальный элемент, общую
сумму всех элементов, общее произведение всех элементов, сумму четных
элементов массива А, сумму нечетных столбцов массива В.
 */

class Program
{
    static void Main(string[] args)
    {
        int[] _A = new int[5];
        double[,] _B = new double[3,4];

        _arr_one(_A);   // Заполнить одномерный
        _arr_two(_B);   // Заполнить двумерный
        _arrays_elements(_A, _B);


        Console.Read();
    }

    static void _arr_one(int[] _arr)
    {
        Random random = new Random();

        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] += random.Next(1,10);
        }
        Console.Write("_A = ");
        for (int i = 0; i < _arr.Length; i++)
        {
            Console.Write(_arr[i] + " ");
        }
        Console.WriteLine("");
    }
    static void _arr_two(double[,] _arr)
    {
        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _arr[i, j] = random.NextDouble() * (10 - 1) + 1;
            }
        }
        Console.Write("_B = ");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("\n\t");
            for (int j = 0; j < 4; j++)
            {
                    
                    Console.Write((float)_arr[i, j] + " ");
            }
        }
        Console.WriteLine("");
    }
    static void _arrays_elements(int[] _A, double[,] _B)
    {
        // 1. Найти в данных массивах общий максимальный элемент
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщий MAX элемент в данных массивах\n");
        int max_A = _A.Max();
        double max_B = _B.Cast<double>().Max();
        if ((int)max_A == (int)max_B)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine
                (
                $"\nMax element _A = {max_A}" +
                $"\nMax element _B = {(int)max_B}"
                );
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nОбщий элемент нет\n");
            Console.WriteLine
                (
                $"\nMax element _A = {max_A}" +
                $"\nMax element _B = {(int)max_B}"
                );
        }
        // 2. Найти в данных массивах общий минимальный элемент
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщий MIN элемент в данных массивах\n");
        int min_A = _A.Min();
        double min_B = _B.Cast<double>().Min();
        if ((int)min_A == (int)min_B)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine
                (
                $"\nMax element _A = {min_A}" +
                $"\nMax element _B = {(int)min_B}"
                );
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nОбщий элемент нет\n");
            Console.WriteLine
                (
                $"\nMax element _A = {min_A}" +
                $"\nMax element _B = {(int)min_B}"
                );
        }
        // 3. Найти в данных массивах общую сумму всех элементов
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщая сумму всех элементов\n");
        int sum_A = _A.Sum();
        double sum_B = _B.Cast<double>().Sum();
        int rezalt_sum = sum_A + (int)sum_B;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine
                (
                $"\nSum element _A = {sum_A}" +
                $"\nSum element _B = {(int)sum_B}" +
                $"\nОбщая сумму всех элементов = {rezalt_sum}");
        // 4. Найти в данных массивах общее произведение всех элементов
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщее произведение всех элементов\n");
        int product_A = 1;
        double product_B = 1;
        foreach (var item in _A)
        {
            product_A *= item;
        }
        foreach (var item in _B)
        {
            product_B *= item;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            $"\nПроизведение _A = {product_A}" +
            $"\nПроизведение _B = {(int)product_B}");
        // 5. Найти cумму четных элементов массива А
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщая cумму четных элементов массива _А\n\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Четные элементы _А = ");
        int even_A = 0;
        foreach (var item in _A)
        {
            if ((item % 2) == 0)
            {
                even_A += item;
                Console.Write(item + " ");
            }
        }
        Console.WriteLine($"\nОбщая cумма _А = {even_A}");
        // 6. Найти сумму нечетных столбцов массива В
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\nОбщая cумму нечетных столбцов массива _B\n\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Нечетные столбцы _B = ");
        double odd_sum_B = 0;
        for (int i = 0; i < _B.GetLength(0); i++)
        {
            Console.Write("\n\t");
            for (int j = 1; j < _B.GetLength(1); j += 2)
            {
                Console.Write(_B[i, j] + " ");
                odd_sum_B += _B[i, j];
            }
        }
        Console.WriteLine($"\nОбщая cумма _B = {(int)odd_sum_B}");
    }
}

