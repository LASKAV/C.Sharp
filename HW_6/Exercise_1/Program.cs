using System.Diagnostics;

namespace Exercise_1;

/*
                    Задание 1
Запрограммируйте класс Money
(объект класса оперирует одной валютой) для работы с деньгами.
В классе должны быть предусмотрены поле для хранения целой
части денег (доллары, евро, гривны и т.д.)
и поле для хранения копеек (центы, евроценты, копейки и т.д.).
Реализовать методы для вывода суммы на экран, задания значений для частей.
На базе класса Money создать класс Product для работы
с продуктом или товаром. Реализовать
метод, позволяющий уменьшить цену на заданное число.
Для каждого из классов реализовать необходимые методы и поля.
 */

class Program
{
    static void Main(string[] args)
    {
        Money _money = new Money(15, 40);
        Console.WriteLine(_money);
        Product _product = new Product("Apple", _money);
        _product.Show_Product(ref _product);
        _product.Buying(5, 15);
        _product.Show_Product(ref _product);
        Console.Read();
    }
}

class Money
{
    private int UAH;
    private int Penny;
    public Money()
    {
        UAH = 0;
        Penny = 0;
    }
    public Money(int UAH , int Penny)
    {
        this.UAH = UAH;
        this.Penny = Penny;
    }
    public int _UAH
    {
        get { return UAH; }
        set { UAH = value; }
    }
    public int _Penny
    {
        get { return Penny; }
        set { Penny = value; }
    }
    public override string ToString()
    {
        return string.Format
            (
            $"{UAH}.{Penny}"
            );
    }
}
class Product : Money
{
    private string Name;
    private Money Price;
    public Product(string Name, Money Price)
    {
        this.Name = Name;
        this.Price = Price;
    }
    public string _Name
    {
        get { return Name; }
        set { Name = value; }
    }
    public Money _Price
    {
        get { return Price; }
        set { Price = value; }
    }
    public void Buying(int UAH, int Penny)
    {
        Price._UAH -= UAH;
        Price._Penny -= Penny;
    }
    public void Show_Product(ref Product _product)
        {
            Console.WriteLine($"Product: {_product._Name}," +
            $" Price: {_product._Price._UAH}.{_product._Price._Penny}");
        }
}