using System.Globalization;

namespace HW_C_1;

/*                              Задание 5
Пользователь вводит с клавиатуры дату. Приложение должно отобразить название
сезона и дня недели. Например, если введено 22.12.2021, приложение должно
отобразить Winter Wednesday.
*/

public class Exercise_5
{
    static void Main(string[] args)
    {
        // Просим пользователя ввести дату в формате dd.MM.yyyy
        Console.Write("Введите дату в формате dd.MM.yyyy: ");
        string input = Console.ReadLine();

        // Преобразуем строку в дату
        DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy", null);

        // Определяем название сезона
        string season = "";
        if (date.Month == 12 || date.Month <= 2)
        {
            season = "Winter";
        }
        else if (date.Month >= 3 && date.Month <= 5)
        {
            season = "Spring";
        }
        else if (date.Month >= 6 && date.Month <= 8)
        {
            season = "Summer";
        }
        else if (date.Month >= 9 && date.Month <= 11)
        {
            season = "Autumn";
        }

        // Определяем название дня недели
        string dayOfWeek = date.ToString("dddd");
        Console.WriteLine($"{season} {dayOfWeek}");
        Console.Read();
    }
}


