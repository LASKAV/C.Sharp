using System.Linq.Expressions;

namespace Exercise_5;
/*
                            Задание 5
Пользователь с клавиатуры вводит в строку арифметическое выражение.
Приложение должно посчитать его результат.
Необходимо поддерживать только две операции: + и –.
 */
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите арифметическое выражение: ");
        string expression = Console.ReadLine();
        int result = Calculate(expression);
        Console.WriteLine($"Результат: {result}");
        Console.Read();
    }
    static int Calculate(string expression)
    {
        int result = 0;
        int currentNumber = 0;
        char currentOperation = '+';

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (Char.IsDigit(c))
            {
                currentNumber = currentNumber * 10 + (c - '0');
            }

            if (!Char.IsDigit(c) || i == expression.Length - 1)
            {
                if (currentOperation == '+')
                {
                    result += currentNumber;
                }
                else if (currentOperation == '-')
                {
                    result -= currentNumber;
                }

                currentNumber = 0;
                currentOperation = c;
            }
        }

        return result;
    }
}

