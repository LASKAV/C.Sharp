namespace Exercise_2;

/*
                            Задание 2
Дан двумерный массив размерностью 5×5, заполненный случайными
числами из диапазона от –100 до 100.
Определить сумму элементов
массива, расположенных между минимальным и максимальным элементами.
 */

class Program
{
    static void Main(string[] args)
    {
        int[,] _arr = new int [4,4];
        arr_set(_arr);
        // arr_get(_arr);
        int min = -100;
        int max = 100;
        int rezalt = 0;
        foreach (var item in _arr)
        {
            if(item > min && item < max)
            {
                rezalt += item;
            }
        }
        Console.WriteLine($"Cумма elemets = {rezalt}");
        Console.Read();
    }
    static void arr_set(int[,] _arr)
    {
        Random random = new Random();
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] += random.Next(-100, 100);
            }
        }
    }
    static void arr_get(int[,] _arr)
    {
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            Console.Write("\n\t");
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                Console.Write(_arr[i, j] + " ");
            }
        }
    }
}

