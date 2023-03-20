namespace Exercaise_1;

/*
                                Задание 1
Напишите метод, который отображает квадрат из некоторого символа.
Метод принимает в качестве параметра: длину стороны квадрата, символ.
 */

class Program
{
    static void Main(string[] args)
    {
        int len = 5;
        char symbol = (char)66;
        square(len, symbol);
        Console.ReadLine();
    }
    static void square(int len, char symbol)
    {
        int[,] _arr = new int[len, len];

        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            Console.Write("\n\t");
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] += symbol;
                Console.Write((char)_arr[i, j] + " ");
            }
        }
    }
}

