namespace HW_C_1;

/*
                            Задание 2
Пользователь вводит с клавиатуры два числа.
Первое число — это значение, второе число процент, который необходимо посчитать.
Например, мы ввели с клавиатуры 90 и 10. Требуется вывести на экран 10 процентов
от 90. Результат: 9.
 */

class Exercise_2
{
    static void Main(string[] args)
    {
        int? number_one = null;
        int? number_two = null;
        int? rezalt = null;

        Console.Write("Введите первое число: ");
        number_one = (int?)Convert.ToInt64(Console.ReadLine());
        Console.Write("Введите первое число: ");
        number_two = (int?)Convert.ToInt64(Console.ReadLine());


        if (number_one != 0 && number_two != 0)
        {
            rezalt = (number_one * number_two) / 100;
            Console.WriteLine("Результат = " +  rezalt );
        }
        else
        {
            Console.WriteLine("Error: значение не может быть = 0 ");
        }

        Console.Read();
    }
}   


