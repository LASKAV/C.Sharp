using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
    public Poems() => poem = new Dictionary<string, Poem>();
    // * Добавлять стихи
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
    // * Удалять стихи
    public void Del_Poems()
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
    // * Изменять информацию о стихах
    public void UpdatePoems()
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
    // * Искать стих по разным характеристикам
    public void SearchPoems()
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
    // * Сохранять коллекцию стихов в файл
    public void SaveToFile(string filePath)
    {
        string json = JsonSerializer.Serialize(poem);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Коллекция стихов успешно сохранена в файл.");
    }
    // * Загружать коллекцию стихов из файла
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
    // * Вывод стихов
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
    private void PrintPoemList(List<Poem> poems)
    {
        foreach (var poem in poems)
        {
            Console.WriteLine($"Название: {poem}");
            Console.WriteLine($"Автор: {poem.AuthorFullName}");
            Console.WriteLine($"Год написания:" +
                $" {poem.YearWritten.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Текст стиха: {string.Join("\n", poem.Text)}");
            Console.WriteLine($"Тема: {poem.Theme}");
            Console.WriteLine();
        }
    }
    private void SaveOrPrintReport(List<Poem> poems)
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Отобразить отчет на экране");
        Console.WriteLine("2. Сохранить отчет в файл");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Отчет:");
                PrintPoemList(poems);
                break;
            case "2":
                Console.WriteLine("Введите имя файла для сохранения отчета:");
                string fileName = Console.ReadLine();
                string json = JsonSerializer.Serialize(poems);
                File.WriteAllText(fileName, json);
                Console.WriteLine($"Отчет сохранен в файл '{fileName}'.");
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }
    }
    // * По названию стиха
    public void GenerateReportByTitle()
    {
        Console.WriteLine("Введите название стиха для генерации отчета:");
        string title = Console.ReadLine();

        List<Poem> poemsWithTitle = new List<Poem>();

        foreach (var item in poem)
        {
            if (item.Key.Contains(title))
            {
                poemsWithTitle.Add(item.Value);
            }
        }

        if (poemsWithTitle.Count > 0)
        {
            Console.WriteLine($"Отчет по названию стиха '{title}':");
            PrintPoemList(poemsWithTitle);
            SaveOrPrintReport(poemsWithTitle);
        }
        else
        {
            Console.WriteLine($"Стихи с названием '{title}' не найдены.");
        }
    }
    // * По ФИО автора
    public void GenerateReportByAuthorFullName()
    {
        Console.WriteLine("Введите ФИО автора для генерации отчета:");
        string authorFullName = Console.ReadLine();

        List<Poem> poemsWithAuthor = new List<Poem>();

        foreach (var item in poem)
        {
            if (item.Value.AuthorFullName.Contains(authorFullName))
            {
                poemsWithAuthor.Add(item.Value);
            }
        }

        if (poemsWithAuthor.Count > 0)
        {
            Console.WriteLine($"Отчет по ФИО автора '{authorFullName}':");
            PrintPoemList(poemsWithAuthor);
            SaveOrPrintReport(poemsWithAuthor);
        }
        else
        {
            Console.WriteLine($"Стихи автора '{authorFullName}' не найдены.");
        }
    }
    // * По теме стиха
    public void GenerateReportByTheme()
    {
        Console.WriteLine("Введите тему стиха для генерации отчета:");
        string theme = Console.ReadLine();

        List<Poem> poemsWithTheme = new List<Poem>();

        foreach (var item in poem)
        {
            if (item.Value.Theme.Contains(theme))
            {
                poemsWithTheme.Add(item.Value);
            }
        }

        if (poemsWithTheme.Count > 0)
        {
            Console.WriteLine($"Отчет по теме стиха '{theme}':");
            PrintPoemList(poemsWithTheme);
            SaveOrPrintReport(poemsWithTheme);
        }
        else
        {
            Console.WriteLine($"Стихи с темой '{theme}' не найдены.");
        }
    }
    // * По слову в тексте стиха
    public void GenerateReportByWord()
    {
        Console.WriteLine("Введите слово для поиска в тексте стиха:");
        string word = Console.ReadLine();

        List<Poem> poemsWithWord = new List<Poem>();

        foreach (var item in poem)
        {
            if (item.Value.Text.Exists(line => line.Contains(word)))
            {
                poemsWithWord.Add(item.Value);
            }
        }

        if (poemsWithWord.Count > 0)
        {
            Console.WriteLine($"Отчет по слову '{word}' в тексте стиха:");
            PrintPoemList(poemsWithWord);
            SaveOrPrintReport(poemsWithWord);
        }
        else
        {
            Console.WriteLine($"Стихи с словом '{word}' не найдены.");
        }
    }
    // * По году написания стиха
    public void GenerateReportByYear()
    {
        Console.WriteLine("Введите год написания стиха для генерации отчета:");
        int year;
        if (int.TryParse(Console.ReadLine(), out year))
        {
            List<Poem> poemsWithYear = new List<Poem>();

            foreach (var item in poem)
            {
                if (item.Value.YearWritten.Year == year)
                {
                    poemsWithYear.Add(item.Value);
                }
            }

            if (poemsWithYear.Count > 0)
            {
                Console.WriteLine($"Отчет по году написания стиха '{year}':");
                PrintPoemList(poemsWithYear);
                SaveOrPrintReport(poemsWithYear);
            }
            else
            {
                Console.WriteLine($"Стихи с годом написания '{year}' не найдены.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод года. Попробуйте еще раз.");
        }
    }
    // * По длине стиха
    public void GenerateReportByLength()
    {
        Console.WriteLine("Введите длину стиха для генерации отчета:");
        int length;
        if (int.TryParse(Console.ReadLine(), out length))
        {
            List<Poem> poemsWithLength = new List<Poem>();

            foreach (var item in poem)
            {
                if (item.Value.Text.Count == length)
                {
                    poemsWithLength.Add(item.Value);
                }
            }

            if (poemsWithLength.Count > 0)
            {
                Console.WriteLine($"Отчет по длине стиха '{length}':");
                PrintPoemList(poemsWithLength);
                SaveOrPrintReport(poemsWithLength);
            }
            else
            {
                Console.WriteLine($"Стихи с длиной '{length}' не найдены.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод длины. Попробуйте еще раз.");
        }
    }

}
class Program
{
    static void Main(string[] args)
    {
        Poems _poem = new Poems();

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==== Менеджер стихов ====");
            Console.ResetColor();
            Console.WriteLine("1. Добавить стих");
            Console.WriteLine("2. Удалить стих");
            Console.WriteLine("3. Обновить стих");
            Console.WriteLine("4. Поиск стиха");
            Console.WriteLine("5. Сохранить стихи в файл");
            Console.WriteLine("6. Загрузить стихи из файла");
            Console.WriteLine("7. Вывести список стихов");
            Console.WriteLine("8. Отчет по названию стиха");
            Console.WriteLine("9. Отчет по ФИО автора");
            Console.WriteLine("10. Отчет по теме стиха");
            Console.WriteLine("11. Отчет по слову в тексте стиха");
            Console.WriteLine("12. Отчет по году написания стиха");
            Console.WriteLine("13. Отчет по длине стиха");
            Console.WriteLine("0. Выход");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================");
            Console.ResetColor();
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _poem.Add_Poems();
                    break;
                case "2":
                    _poem.Del_Poems();
                    break;
                case "3":
                    _poem.UpdatePoems();
                    break;
                case "4":
                    _poem.SearchPoems();
                    break;
                case "5":
                    Console.WriteLine("Введите название файла: ");
                    string namefile = Console.ReadLine();
                    _poem.SaveToFile(namefile);
                    break;
                case "6":
                    Console.WriteLine("Введите название файла: ");
                    string namefile_new = Console.ReadLine();
                    _poem.LoadFromFile(namefile_new); 
                    break;
                case "7":
                    _poem.PrintPoems();
                    break;
                case "8":
                    _poem.GenerateReportByTitle();
                    break;
                case "9":
                    _poem.GenerateReportByAuthorFullName();
                    break;
                case "10":
                    _poem.GenerateReportByTheme();
                    break;
                case "11":
                    _poem.GenerateReportByWord();
                    break;
                case "12":
                    _poem.GenerateReportByYear();
                    break;
                case "13":
                    _poem.GenerateReportByLength();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный выбор. Попробуйте еще раз.");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}

