namespace Exercise_1;

/*
                        Задание 1
Создайте приложение калькулятор для перевода числа из одной системы
исчисления в другую. Пользователь с помощью меню выбирает
направление перевода. Например, из десятичной в двоичную.
После выбора направления, пользователь вводит число в
исходной системе исчисления. Приложение должно перевести
число в требуемую систему. Предусмотреть случай выхода
за границы диапазона, определяемого типом int, неправильный ввод.
 */

class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("Выберите направление перевода:");
            Console.WriteLine("1 - Из десятичной в двоичную");
            Console.WriteLine("2 - Из двоичной в десятичную");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Введите число в десятичной системе исчисления:");
                int decimalNumber = int.Parse(Console.ReadLine());
                string binaryNumber = DecimalToBinary(decimalNumber);
                Console.WriteLine($"Число {decimalNumber} в двоичной системе исчисления: {binaryNumber}");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Введите число в двоичной системе исчисления:");
                string binaryNumber = Console.ReadLine();
                int decimalNumber = BinaryToDecimal(binaryNumber);
                Console.WriteLine($"Число {binaryNumber} в десятичной системе исчисления: {decimalNumber}");
            }
            else
            {
                Console.WriteLine("Ошибка! Неверный выбор.");
            }
        } while (true);
    }

    static string DecimalToBinary(int decimalNumber)
    {
        return Convert.ToString(decimalNumber, 2);
    }

    static int BinaryToDecimal(string binaryNumber)
    {
        try
        {
            return Convert.ToInt32(binaryNumber, 2);
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка! Неправильный ввод.");
            return 0;
        }
    }
}

