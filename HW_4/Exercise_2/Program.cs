namespace Exercise_2;
using System.Collections;
using System.Collections.Generic;

/*
                        Задание 2
Пользователь вводит словами цифру от 0 до 9.
Приложение должно перевести слово в цифру.
Например, если пользователь ввёл five, приложение должно вывести на экран 5.
 */

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> _Dict = new Dictionary<string, int>
        {
            ["zero"] = 0,
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5,
            ["six"] = 6,
            ["seven"] = 7,
            ["eight"] = 8,
            ["nine"] = 9,
        };
        // Dictionary словарь key,val

        foreach (KeyValuePair<string, int> keyValue in _Dict)
        {
            Console.WriteLine(keyValue.Key + " = " + keyValue.Value);
        }


        Console.WriteLine("Введите словами цифру от 0 до 9");
        string num_str = Console.ReadLine();
        Console.WriteLine(_Dict[num_str]);
        Console.Read();
    }
}

