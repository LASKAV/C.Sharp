namespace Exercise_1;

/*
                            Задание 1
Создайте класс Пьеса. Класс должен хранить такую информацию:
- Название пьесы
- ФИО автора
- Жанр
- Год выпуска
Реализуйте в классе метода и свойтва необходимые для
функциональности класса
Добвьвте в классе деструктор. Напишите код для тестирования функциональности
Напишите код для вызова деструктора 
 */
class Program
{
    static void Main(string[] args)
    {
        Play play = new Play("Я и час ночи", "Шекспир", "Трагедия", 1666);

        play.DisplayInfo();
        play = null;

        GC.Collect();
        Console.ReadKey();
    }
}

class Play
{
    // Поля класса
    private string title;
    private string authorFullName;
    private string genre;
    private int releaseYear;

    // Свойства класса
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string AuthorFullName
    {
        get { return authorFullName; }
        set { authorFullName = value; }
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public int ReleaseYear
    {
        get { return releaseYear; }
        set { releaseYear = value; }
    }

    public Play(string title, string authorFullName, string genre, int releaseYear)
    {
        this.title = title;
        this.authorFullName = authorFullName;
        this.genre = genre;
        this.releaseYear = releaseYear;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Название пьесы: " + title);
        Console.WriteLine("Автор: " + authorFullName);
        Console.WriteLine("Жанр: " + genre);
        Console.WriteLine("Год выпуска: " + releaseYear);
    }

    // Деструктор класса
    ~Play()
    {
        Console.WriteLine("Деструктор Play вызван.");
        // Освобождение ресурсов, если необходимо
    }
}
