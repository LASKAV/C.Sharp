namespace Exercise_1;

/*
                            Задание 1
Ранее в одном из практических заданий вы создавали класс «Журнал».
Добавьте к уже созданному классу информацию о количестве сотрудников.
Выполните перегрузку :
+ (для увеличения количества сотрудников на указанную величину),
— (для уменьшения количества сотрудников на указанную величину),
== (проверка на равенство количества сотрудников),
< и > (проверка на меньше или больше количества сотрудников),
!= и Equals. Используйте механизм свойств для полей класса.
 */

class Program
{
    static void Main(string[] args)
    {
        Magazine _magazine_one = new Magazine();
        Magazine _magazine_two = new Magazine();
        _magazine_one += 10;
        _magazine_one -= 2;
        Console.WriteLine(_magazine_one);
        Console.WriteLine(_magazine_one);
        _magazine_two += 8;
        if (_magazine_one == _magazine_two) Console.WriteLine("Количество сотрудников совпадает");
        else Console.WriteLine("Количество не совпадает");
        if (_magazine_one > _magazine_two) Console.WriteLine("_magazine_one > _magazine_two - True");
        else Console.WriteLine("_magazine_one > _magazine_two - Folse");
        if (_magazine_one < _magazine_two) Console.WriteLine("_magazine_one < _magazine_two - True");
        else Console.WriteLine("_magazine_one < _magazine_two - Folse");
        if (_magazine_one > _magazine_two) Console.WriteLine("_magazine_one > _magazine_two - True");
        else Console.WriteLine("_magazine_one > _magazine_two - Folse");
        if (_magazine_one < _magazine_two) Console.WriteLine("_magazine_one < _magazine_two - True");
        else Console.WriteLine("_magazine_one > _magazine_two - Folse");
        if (_magazine_one != _magazine_two) Console.WriteLine("_magazine_one != _magazine_two - True");
        else Console.WriteLine("_magazine_one > _magazine_two - Folse");
        Console.Read();
    }
}
class Magazine
{
    private int employee { get; set; }
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
        employee = 0;
    }
    public Magazine(string name, string year,
        string tittle, string telephone,
        string email, int employee)
    {
        this.name = name;
        this.year = year;
        this.tittle = tittle;
        this.telephone = telephone;
        this.email = email;
        this.employee = employee;
    }
    public void Input_Web()
    {
        Console.WriteLine("New Website");
        Console.Write("Введите название: "); name = Console.ReadLine();
        Console.Write("Введите год основания: "); year = Console.ReadLine();
        Console.Write("Введите описание журнала: "); tittle = Console.ReadLine();
        Console.Write("Введите контактный телефон: "); telephone = Console.ReadLine();
        Console.Write("Введите e-mail: "); telephone = Console.ReadLine();
        Console.Write("Введите количество сотрудников: "); employee = int.Parse(Console.ReadLine());
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
            $"\nYear: {year}" +
            $"\nTittle: {tittle}" +
            $"\nTelephone: {telephone}" +
            $"\nE-mail: {email}" +
            $"\nEmployee: {employee}");
    }
    public static Magazine operator +(Magazine rezalt, int employee)
    {
        rezalt.employee += employee;
        return rezalt;
    }
    public static Magazine operator -(Magazine rezalt, int employee)
    {
        rezalt.employee -= employee;
        return rezalt;
    }
    public static bool operator ==(Magazine left, Magazine right)
    {
        if (left.employee == right.employee)
            return true;
        else
            return false;
    }
    public static bool operator !=(Magazine left, Magazine right)
    {
        if (left.employee != right.employee)
            return true;
        else
            return false;
    }
    public static bool operator >(Magazine left, Magazine right)
    {
        if (left.employee > right.employee)
            return true;
        else
            return false;
    }
    public static bool operator <(Magazine left, Magazine right)
    {
        if (left.employee < right.employee)
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
        Magazine other = (Magazine)obj;
        return employee == other.employee;
    }
}

