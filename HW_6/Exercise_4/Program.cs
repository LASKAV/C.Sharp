namespace Exercise_4;

/*
                            Задание 4
Создать абстрактный базовый класс Worker (работника) с методом Print().
Создайте четыре производных класса:
President,
Security,
Manager,
Engineer.
Переопределите метод
Print() для вывода информации, соответствующей каждому типу работника.
 */

class Program
{
    static void Main(string[] args)
    {
        Worker worker_1 = new President();
        Worker worker_2 = new Security();
        Worker worker_3 = new Manager();
        Worker worker_4 = new Engineer();
        worker_1.Print();
        worker_2.Print();
        worker_3.Print();
        worker_4.Print();
        Console.Read();
    }
}

abstract class Worker
{
    public abstract void Print();
}
class President : Worker
{
    public override void Print()
    {
        Console.WriteLine("President");
    }
}
class Security : Worker
{
    public override void Print()
    {
        Console.WriteLine("Security");
    }
}
class Manager : Worker
{
    public override void Print()
    {
        Console.WriteLine("Manager");
    }
}
class Engineer : Worker
{
    public override void Print()
    {
        Console.WriteLine("Engineer");
    }
}