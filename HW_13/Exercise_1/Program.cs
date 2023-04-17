using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise_1;


/*
                        Задание 1
Создайте приложение для работы с коллекцией стихов.
Необходимо хранить такую информацию:
* Название стиха
* ФИО автора
* Год написания
* Текст стиха
* Тема стиха
Приложение должно позволять:
* Добавлять стихи
* Удалять стихи
* Изменять информацию о стихах
* Искать стих по разным характеристикам
* Сохранять коллекцию стихов в файл
* Загружать коллекцию стихов из файла
                        Задание 2
Добавьте к приложению из первого задания возможность генерировать отчёты.
Отчёт может быть отображён на экран или сохранён в файл. Создайте такие отчёты:
* По названию стиха
* По ФИО автора
* По теме стиха
                       Задание 3
Добавьте к приложению из первого задания дополнительные отчёты:
* По слову в тексте стиха
* По году написания стиха
* По длине стиха
 */
struct Poem
{
    public string AuthorFullName { get; set; }
    public DateTimeOffset YearWritten { get; set; }
    public List<string> Text { get; set; }
    public string Theme { get; set; }
}
class Poems
{
    private Dictionary<string, Poem> poem;

    public Poems()
    {
        poem = new Dictionary<string, Poem>();
    }
    public void Add_Poems()
    {
        Console.WriteLine("Добавление стиха");
        while(true)
        {
            Console.Write
                (
                "\n1.Добавить стих" +
                "\n2.Выйти"
                );
            Console.Write("\n\nСделай выбор: ");
            short choice = short.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.Write("Введите название стиха: ");
                    string title = Console.ReadLine();

                    Console.Write("Введите ФИО автора: ");
                    string authorFullName = Console.ReadLine();

                    Console.Write("Введите год написания стиха (гггг-мм-дд): ");
                    DateTimeOffset yearWritten;
                    while (!DateTimeOffset.
                        TryParse(Console.ReadLine(), out yearWritten))
                    {
                        Console.WriteLine("Ошибка:" +
                            " некорректный формат даты. Повторите ввод: ");
                    }

                    List<string> text = new List<string>();

                    Console.WriteLine("Введите" +
                        " текст стиха (вводите строки" +
                        ", для завершения введите пустую строку): ");
                    string line;
                    while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                    {
                        text.Add(line);
                    }

                    Console.Write("Введите тему стиха: ");
                    string theme = Console.ReadLine();

                    Poem newPoem = new Poem
                    {
                        AuthorFullName = authorFullName,
                        YearWritten = yearWritten,
                        Text = text,
                        Theme = theme
                    };

                    poem.Add(title, newPoem);
                    Console.WriteLine("Стих успешно добавлен.");
                    break;
                case 2:
                    ConsoleColor color_ex = ConsoleColor.Green;
                    Console.ForegroundColor = color_ex;
                    Console.WriteLine("Выход");
                    Console.ResetColor();
                    return;
                default:
                    ConsoleColor color = ConsoleColor.Red;
                    Console.ForegroundColor = color;
                    Console.WriteLine("Error: ошибка выбора");
                    Console.ResetColor();
                    break;
            }
        }
    }   
    public void Del_Poems()       // * Удалять стихи
    {
        Console.Write("\nВведите название стиха:");
        string dell = Console.ReadLine();
        if (poem.ContainsKey(dell))
        {
            poem.Remove(dell);
            Console.WriteLine($"Стих: {dell} был удален");
        }
        else
            Console.WriteLine($"Cтиха с таким названием {dell} нет");
    }
    public void UpdatePoems()     // * Изменять информацию о стихах
    {
        Console.Write("\nВведите название стиха:");
        string title = Console.ReadLine();
        if (poem.ContainsKey(title))
        {
            Console.WriteLine($"Введите новые данные для стиха '{title}':");
            Console.Write("Автор: ");
            string authorFullName = Console.ReadLine();
            Console.Write("Год написания (yyyy-MM-dd): ");
            DateTimeOffset yearWritten;
            while (!DateTimeOffset.
                TryParseExact(Console.ReadLine(),
                "yyyy-MM-dd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out yearWritten))
            {
                Console.WriteLine("Ошибка ввода." +
                    " Введите дату в формате 'yyyy-MM-dd': ");
            }
            Console.WriteLine("Текст стиха" +
                " (введите пустую строку для завершения ввода): ");
            List<string> text = new List<string>();
            string line;
            do
            {
                line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    text.Add(line);
                }
            } while (!string.IsNullOrWhiteSpace(line));
            Console.Write("Тема: ");
            string theme = Console.ReadLine();

            // Обновляем данные стиха
            Poem updatedPoem = new Poem
            {
                AuthorFullName = authorFullName,
                YearWritten = yearWritten,
                Text = text,
                Theme = theme
            };
            poem[title] = updatedPoem;

            Console.WriteLine($"Данные стиха '{title}' успешно обновлены.");
        }
        else
        {
            Console.WriteLine($"Стих с названием '{title}' не найден.");
        }
    }  
    public void SearchPoems()     // * Искать стих по разным характеристикам
    {
        Console.WriteLine("Поиск стихов:");
        Console.WriteLine("1. По названию");
        Console.WriteLine("2. По автору");
        Console.WriteLine("3. По году написания");
        Console.WriteLine("4. По теме");
        Console.WriteLine("5. Отмена");
        Console.Write("Выберите опцию (1-5): ");
        string searchOption = Console.ReadLine();
        List<string> foundPoems = new List<string>();

        switch (searchOption)
        {
            case "1":
                Console.Write("Введите название стиха: ");
                string title = Console.ReadLine();
                if (poem.ContainsKey(title))
                {
                    foundPoems.Add(title);
                }
                break;
            case "2":
                Console.Write("Введите автора: ");
                string authorFullName = Console.ReadLine();
                foreach (var item in poem)
                {
                    if (item.Value.AuthorFullName.
                        Equals(authorFullName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        foundPoems.Add(item.Key);
                    }
                }
                break;
            case "3":
                Console.Write("Введите год написания (yyyy-MM-dd): ");
                DateTimeOffset yearWritten;
                while (!DateTimeOffset.
                    TryParseExact(Console.ReadLine(),
                    "yyyy-MM-dd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out yearWritten))
                {
                    Console.WriteLine("Ошибка ввода." +
                        " Введите дату в формате 'yyyy-MM-dd': ");
                }
                foreach (var item in poem)
                {
                    if (item.Value.YearWritten.Equals(yearWritten))
                    {
                        foundPoems.Add(item.Key);
                    }
                }
                break;
            case "4":
                Console.Write("Введите тему: ");
                string theme = Console.ReadLine();
                foreach (var item in poem)
                {
                    if (item.Value.Theme.Equals(theme,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        foundPoems.Add(item.Key);
                    }
                }
                break;
            case "5":
                Console.WriteLine("Отмена.");
                return;
            default:
                Console.WriteLine("Ошибка выбора.");
                return;
        }

        if (foundPoems.Count > 0)
        {
            Console.WriteLine("Найденные стихи:");
            foreach (var poemTitle in foundPoems)
            {
                Console.WriteLine($"- {poemTitle}");
            }
        }
        else
        {
            Console.WriteLine("Стихи по указанным характеристикам не найдены.");
        }
    }
    public void SaveToFile(string filePath)
    {
        string json = JsonSerializer.Serialize(poem);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Коллекция стихов успешно сохранена в файл.");
    }

    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            poem = JsonSerializer.Deserialize<Dictionary<string, Poem>>(json);
            Console.WriteLine("Коллекция стихов успешно загружена из файла.");
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }
    }
    public void PrintPoems()
    {
        Console.WriteLine("Список стихов:");
        if (poem == null)
        {
            Console.WriteLine("ПУСТО");
        }
        else
        {
            foreach (var item in poem)
            {
                Console.WriteLine($"Название: {item.Key}");
                Console.WriteLine($"Автор: {item.Value.AuthorFullName}");
                Console.WriteLine($"Год написания: {item.Value.YearWritten.ToString("yyyy-MM-dd")}");
                Console.WriteLine("Текст стиха:");
                foreach (var line in item.Value.Text)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine($"Тема: {item.Value.Theme}");
                Console.WriteLine();
            }
        }


    }

}
class Program
{
    static void Main(string[] args)
    {
        Poems _poems = new Poems();

        _poems.Add_Poems();
        _poems.PrintPoems();
        Console.Read();
    }
}

