namespace Exercise_4;

/*
                     Задание 4
Пользователь вводит в строку с клавиатуры логическое выражение.
Например, 3 > 2 или 7 < 3.
Программа должна посчитать результат введенного выражения
и дать результат true или false.
В строке могут быть только целые числа и операторы: <, >, <=, >=, ==, !=.
Для обработки ошибок ввода используйте механизм исключений.

 */
class Program
{
    static void Main()
    {
        Console.Write("Введите логическое выражение: ");
        string input = Console.ReadLine();

        try
        {
            bool result = EvaluateExpression(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный формат выражения");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.Read();
    }

    static bool EvaluateExpression(string input)
    {
        string[] parts = input.Split(' ');

        if (parts.Length != 3)
        {
            throw new FormatException();
        }

        int left, right;

        if (!int.TryParse(parts[0], out left) ||
            !int.TryParse(parts[2], out right))
        {
            throw new FormatException();
        }

        switch (parts[1])
        {
            case "<": return left < right;
            case ">": return left > right;
            case "<=": return left <= right;
            case ">=": return left >= right;
            case "==": return left == right;
            case "!=": return left != right;
            default: throw new ArgumentException("неверный оператор");
        }
    }
}


