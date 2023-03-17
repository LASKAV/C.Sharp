namespace HW_C_1;

/*
                        Задание 3
Пользователь вводит с клавиатуры четыре цифры.
Необходимо создать число, содержащее эти цифры. На- пример,
если с клавиатуры введено 1, 5, 7, 8 тогда нужно сформировать число 1578.
*/

public class Exercise_3
{
   static void Main(string[] args)
   {
        // int[] numbers = new int[4]
        int[] numbers = new int[4];

        for (int i = 0; i < 4; i++)
        {
            Console.Write("\nВведите " + i + " число: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Число :");
        for (int i = 0; i < 4; i++)
        {
            Console.Write(numbers[i]);
        }
        Console.Read();
   }
}

