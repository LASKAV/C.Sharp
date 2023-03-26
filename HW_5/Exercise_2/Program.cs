namespace Exercise_2;

/*
                        Задание 2
Ранее в одном из практических заданий вы создавали класс «Магазин».
Добавьте к уже созданному классу информацию о площади магазина.
Выполните перегрузку
+ (для увеличения площади магазина на указанную величину),
— (для уменьшения площади магазина на указанную величину),
== (проверка на равенство площа- дей магазинов),
< и > (проверка на меньше или больше площади магазина),
!= и Equals. Используйте механизм свойств для полей класса.
 */
class Program
{
    static void Main(string[] args)
    {
        Store _store_one = new Store();
        Store _store_two = new Store();
        _store_one += 10;
        _store_one -= 2;
        Console.WriteLine(_store_one);
        Console.WriteLine(_store_two);
        _store_two += 8;
        if (_store_one == _store_two) Console.WriteLine("Площади совпадают");
        else Console.WriteLine("Площади не совпадают");
        if (_store_one > _store_two) Console.WriteLine("_store_one > _store_two - True");
        else Console.WriteLine("_store_one > _store_two - Folse");
        if (_store_one < _store_two) Console.WriteLine("_store_one < _store_two - True");
        else Console.WriteLine("_store_one < _store_two - Folse");
        if (_store_one > _store_two) Console.WriteLine("_store_one > _store_two - True");
        else Console.WriteLine("_store_one > _store_two - Folse");
        if (_store_one < _store_two) Console.WriteLine("_store_one < _store_two - True");
        else Console.WriteLine("_store_one > _store_two - Folse");
        if (_store_one != _store_two) Console.WriteLine("_store_one != _store_two - True");
        else Console.WriteLine("_store_one > _store_two - Folse");
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
    private double area { get; set; }

    public Store()
    {
        name = "Home_Store";
        address = "New_Odessa";
        tittle = $"{name}" + "\nописание журнала";
        telephone = "+455322322";
        email = $"Store{"@gmail.com"}";
        area = 10;
    }
    public Store(string name, string address,
        string tittle, string telephone,
        string email, double area)
    {
        this.name = name;
        this.address = address;
        this.tittle = tittle;
        this.telephone = telephone;
        this.email = email;
        this.area = area;
    }
    public void Input_Web()
    {
        Console.WriteLine("New Website");
        Console.Write("Введите название магазина: "); name = Console.ReadLine();
        Console.Write("Введите адрес: "); address = Console.ReadLine();
        Console.Write("Введите описание профиля магазина: "); tittle = Console.ReadLine();
        Console.Write("Введите контактный телефон: "); telephone = Console.ReadLine();
        Console.Write("Введите e-mail: "); telephone = Console.ReadLine();
        Console.Write("Введите площадь: "); area = double.Parse(Console.ReadLine());
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
            $"\nAddress: {address}" +
            $"\nTittle: {tittle}" +
            $"\nTelephone: {telephone}" +
            $"\nE-mail: {email}" +
            $"\nArea: {area}"
            );
    }
    public static Store operator +(Store rezalt, int area)
    {
        rezalt.area += area;
        return rezalt;
    }
    public static Store operator -(Store rezalt, int area)
    {
        rezalt.area -= area;
        return rezalt;
    }
    public static bool operator ==(Store left, Store right)
    {
        if (left.area == right.area)
            return true;
        else
            return false;
    }
    public static bool operator !=(Store left, Store right)
    {
        if (left.area != right.area)
            return true;
        else
            return false;
    }
    public static bool operator >(Store left, Store right)
    {
        if (left.area > right.area)
            return true;
        else
            return false;
    }
    public static bool operator <(Store left, Store right)
    {
        if (left.area < right.area)
            return true;
        else
            return false;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        Store other = (Store)obj;
        return area == other.area;
    }
}
