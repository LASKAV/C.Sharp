namespace Exercaise_4;

/*
            Задание 4
Создайте класс «Веб-сайт».
Необходимо хранить в полях класса:
1.название сайта,
2.путь к сайту,
3.описание сайта,
4.ip адрес сайта.
Реализуйте методы класса для ввода данных, вывода данных,
реализуйте доступ к отдельным полям через методы класса.
 */

class Program
{
    static void Main(string[] args)
    {
        Website _website = new Website();
        Console.Write(_website);
        _website.Input_Web();
        Console.Write(_website);
        Console.Read();
    }
}

class Website
{
    private string name { get; set; }
    private string URL { get; set; }
    private string tittle { get; set; }
    private string ip { get; set; }
    public Website()
    {
        name = "Home_Web";
        URL = $"https:\\{name}.com";
        tittle = $"{name}" + "\nописание сайта";
        ip = "0088";
    }
    public Website(string name, string URL, string tittle, string ip)
    {
        this.name = name;
        this.URL = URL;
        this.tittle = tittle;
        this.ip = ip;
    }
    public void Input_Web()
    {
        Console.WriteLine("New Website");
        Console.Write("Введите название: "); name = Console.ReadLine();
        Console.Write("Введите URL: "); URL = Console.ReadLine();
        Console.Write("Введите tittle: "); tittle = Console.ReadLine();
        Console.Write("Введите ip: "); ip = Console.ReadLine();
    }
    public void upp_ip()
    {
        string ip = this.ip;
    }
    public void upp_name()
    {
        string name = this.name;
    }
    public override string ToString()
    {
        return string.Format
            (
            $"\nWebsite" +
            $"\nName: {name}" +
            $"\nURL: {URL}" +
            $"\nTittle: {tittle}" +
            $"\nIP: {ip}"
            );
    }
}

