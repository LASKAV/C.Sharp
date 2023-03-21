namespace Exercaise_5;

/*
              Задание 5
Создайте класс «Журнал».
Необходимо хранить в полях класса:
название журнала,
год основания,
описание журнала,
контактный телефон,
контактный e-mail.
Реализуйте методы класса для ввода данных, вывода данных,
реализуйте доступ к отдельным полям через методы класса.
 */

class Program
{
    static void Main(string[] args)
    {
        Magazine _magazine = new Magazine();
        Console.WriteLine(_magazine);
        _magazine.upp_year("2024");
        Console.WriteLine(_magazine);
        Console.Read();
    }
}
class Magazine
{
    private string name { get; set; }
    private string year { get; set; }
    private string tittle { get; set; }
    private string telephone { get; set; }
    private string email { get; set; }

    public Magazine()
    {
        name = "Home_Magazine";
        year = "2023";
        tittle = $"{name}" + "\nописание журнала";
        telephone = "+455322322";
        email = $"Magazine{"@gmail.com"}";
    }
    public Magazine(string name, string year, string tittle, string telephone, string email)
    {
        this.name = name;
        this.year = year;
        this.tittle = tittle;
        this.telephone = telephone;
        this.email = email;
    }
    public void Input_Web()
    {
        Console.WriteLine("New Website");
        Console.Write("Введите название: "); name = Console.ReadLine();
        Console.Write("Введите год основания: "); year = Console.ReadLine();
        Console.Write("Введите описание журнала: "); tittle = Console.ReadLine();
        Console.Write("Введите контактный телефон: "); telephone = Console.ReadLine();
        Console.Write("Введите e-mail: "); telephone = Console.ReadLine();
    }
    public void upp_year(string year)
    {
        this.year = year;
    }
    public void upp_name(string name)
    {
        this.name = name;
    }
    public override string ToString()
    {
        return string.Format
            (
            $"\nMagazine" +
            $"\nName: {name}" +
            $"\nyear: {year}" +
            $"\nTittle: {tittle}" +
            $"\ntelephone: {telephone}" + 
            $"\ne-mail: {email}"
            ) ;
    }
}
