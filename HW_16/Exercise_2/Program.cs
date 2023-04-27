using System.Text.Json;

namespace Exercise_2;
/*

                            Задание 3:
Добавьте к предыдущему заданию список статей из журнала.
Нужно хранить такую информацию о каждой статье:

1. Название статьи
2. Количество символов
3. Анонс статьи

Измените функциональность из предыдущего задания таким образом,
чтобы она учитывала список статей.
Выбор конкретного формат сериализации необходимо
сделать вам. Обращаем ваше внимание, что выбор должен быть обоснованным.

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


        Console.WriteLine("\nСериализованный Journal:");
        Console.WriteLine(JsonString);
        Console.Read();
    }
}

