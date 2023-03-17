using System;

namespace HW_C_1;
/*
                            Задание 4
Пользователь вводит шестизначное число. После чего пользователь вводит номера
разрядов для обмена цифр. Например, если пользователь ввёл один и шесть — это
значит, что надо обменять местами первую и шестую цифры.
Число 723895 должно превратиться в 523897.
Если пользователь ввел не шестизначное число тре- буется
вывести сообщение об ошибке.
 */

public class Exercise_4
{
    static void Main(string[] args)
    {
        int[] _arr = new int[6];
        Console.WriteLine("Введите шестизначное число");
        short iter = 0;
        for (int i = 0; i < _arr.Length; i++)
        {
            iter++;
            Console.Write("\nЧисло №" + iter + ": ");
            _arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Введите номера разрядов для обмена цифр");
        Console.Write("\nВведите 1 index : ");
        int index_one = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nВведите 2 index : ");
        int index_two = Convert.ToInt32(Console.ReadLine());

        int temp = _arr[index_one];          // Сохраняем значение первого элемента во временной переменной
        _arr[index_one] = _arr[index_two];   // Присваиваем первому элементу значение второго элемента
        _arr[index_two] = temp;              // Присваиваем второму элементу значение временной переменной

        Console.Write("\nВаше число = ");
        foreach (var item in _arr)
        {
            Console.Write(item + " ");
        }
        Console.Read();
    }
}
