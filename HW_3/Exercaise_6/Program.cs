namespace Exercaise_6;
/*
            Задание 6
Создайте класс «Магазин».
Необходимо хранить в полях класса:
1.название магазина,
2.адрес,
3.описание профиля магазина,
4.контактный телефон,
5.контактный e-mail.
Реализуйте методы класса для ввода данных,
вывода данных, реализуйте доступ к отдельным полям через методы класса.
 */
class Program
{
    static void Main(string[] args)
    {
        Store _store = new Store();
        Console.WriteLine(_store);
        _store.Input_Web();
        Console.WriteLine(_store);
        _store.upp_address("NEW ADDRESS");
        Console.WriteLine(_store);
        Console.Read();
    }
}

class Store
{
    private string name { get; set; }
    private string address { get; set; }
    private string tittle { get; set; }
    private string telephone { get; set; }
    private string email { get; set; }

    public Store()
    {
        name = "Home_Store";
        address = "New_Odessa";
        tittle = $"{name}" + "\nописание журнала";
        telephone = "+455322322";
        email = $"Store{"@gmail.com"}";
    }
    public Store(string name, string address, string tittle, string telephone, string email)
    {
        this.name = name;
        this.address = address;
        this.tittle = tittle;
        this.telephone = telephone;
        this.email = email;
    }
    public void Input_Web()
    {
        Console.WriteLine("New Website");
        Console.Write("Введите название магазина: "); name = Console.ReadLine();
        Console.Write("Введите адрес: "); address = Console.ReadLine();
        Console.Write("Введите описание профиля магазина: "); tittle = Console.ReadLine();
        Console.Write("Введите контактный телефон: "); telephone = Console.ReadLine();
        Console.Write("Введите e-mail: "); telephone = Console.ReadLine();
    }
    public void upp_address(string year)
    {
        this.address = year;
    }
    public void upp_name(string name)
    {
        this.name = name;
    }
    public override string ToString()
    {
        return string.Format
            (
            $"\nStore" +
            $"\nName: {name}" +
            $"\naddress: {address}" +
            $"\nTittle: {tittle}" +
            $"\ntelephone: {telephone}" +
            $"\ne-mail: {email}"
            );
    }
}