namespace HW_C_1;

/*
                                Задание 7
Пользователь вводит с клавиатуры два числа. Нужно показать все четные числа
в указанном диапазоне. Если границы диапазона указаны неправильно требуется
произвести нормализацию границ. Например, пользователь ввел 20 и 11, требуется
нормализация, после которой начало диапазона станет равно 11, а конец 20.
 */

public class Exercise_7
{
    static void Main(string[] args)
    {
        Console.Write("Введите первое число :");
        int number_one = int.Parse(Console.ReadLine());
        Console.Write("\nВведите второе число :");
        int number_two = int.Parse(Console.ReadLine());

        if (number_one > number_two)
        {
            int temp = number_one;
            number_one = number_two;
            number_two = temp;
        }
        for (int i = number_one; i <= number_two; i++)
        {
            Console.Write(i + " ");
        }

        Console.Read();
    }
}

