using System.Diagnostics;

namespace HW_C_1;

/*
                        Задание 6
Пользователь вводит с клавиатуры показания температуры.
В зависимости от выбора пользователя программа переводит
температуру из Фаренгейта в Цельсий или наоборот.
 */

public class Exercise_6
{
    static void Main(string[] args)
    {
        do
        {
            Console.WriteLine("\nПоказания температуры");
            int ch = 0;
            int temp = 0;
            int rezalt = 0;
            Console.WriteLine(
                "\n1.Фаренгейта в Цельсий" +
                "\n2.Цельсий в  Фаренгейта" +
                "\n3.Exit");
            Console.Write("\n Выбор : ");
            ch = int.Parse(Console.ReadLine());
            if (ch == 0 && ch > 3)
            {
                Console.WriteLine("Error!");
                break;
            }    
            switch (ch)
            {
                case 1:
                    if (temp != 0 && rezalt != 0) { temp = 0; rezalt = 0; }
                    Console.Write("\nВведите температуру (°F): ");
                    temp = int.Parse(Console.ReadLine());
                    // Формула пример (100 °F − 32) × 5 / 9 = 37,778 °C
                    rezalt = (temp - 32) * 5 / 9;
                    Console.WriteLine("Температура = " + rezalt + " °C");
                    break;
                case 2:
                    if (temp != 0 && rezalt != 0) { temp = 0; rezalt = 0; }
                    Console.Write("\nВведите температуру (°C): ");
                    temp = int.Parse(Console.ReadLine());
                    // Формула (100 °C × 9 / 5) + 32 = 212 °F
                    rezalt = (temp * 9 / 5) + 32;
                    Console.WriteLine("Температура = " + rezalt + " °F");
                    break;
                case 3:
                    Console.Write("\nЗавершение программы");
                    Console.Read();
                    Environment.Exit(0);
                    break;
                default:
                    ch = 0;
                break;
            }
        } while (true);
    }
}

