using System.Text.Json;

namespace Exercise_2;
/*
                        Задание 2:
Создайте программу для работы с информацией о журнале.
Нужно хранить такую информацию об журнале:

1. Название журнала
2. Название издательства
3. Дата выпуска
4. Количество страниц

У программы должна быть такая функциональность:

1. Ввод информации о журнале
2. Вывод информации о журнале
3. Сериализация журнала
4. Сохранение сериализованного журнала в файл
5. Загрузка сериализованного журнала из файла.

После загрузки нужно произвести десериализацию журнала.
Выбор конкретного формата сериализации необходимо сделать вам.
Обращаем ваше внимание, что выбор должен быть обоснованным.

 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        Console.WriteLine("Введите название журнала:");
        journal.Name = Console.ReadLine();

        Console.WriteLine("Введите название издательства:");
        journal.Publisher = Console.ReadLine();

        Console.WriteLine("Введите дату выпуска журнала (дд.мм.гггг):");
        journal.Date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество страниц в журнале:");
        journal.PageCount = int.Parse(Console.ReadLine());

        Console.WriteLine("Информация о журнале:");
        Console.WriteLine(journal.ToString());

        string Json = JsonSerializer.Serialize(journal);
        Console.WriteLine(Json);
        File.WriteAllText("Journal.json", Json);

        string JsonString = File.ReadAllText("Journal.json");

        // Десериализация массива дробей
        Journal loadedJournal =
        JsonSerializer.Deserialize<Journal>(JsonString);


        Console.WriteLine("\nСериализованный массив дробей:");
        Console.WriteLine(JsonString);
        Console.Read();
    }
}

