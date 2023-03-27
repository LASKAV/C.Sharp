namespace Exercise_2;

/*
                    Задание 2
Создать базовый класс «Устройство» и производные классы
«Чайник», «Микроволновка», «Автомобиль», «Пароход».
С помощью конструктора установить имя каждого устройства и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук устройства (пишем текстом в консоль);
■ Show — отображает название устройства;
■ Desc — отображает описание устройства.
 */

class Program
{
    static void Main(string[] args)
    {
        Kettle _kettle = new Kettle();
        _kettle.Sound();
        _kettle.Show();
        _kettle.Desc();

        Console.Read();
    }
}

class Device
{
    public virtual void Sound(){}
    public virtual void Show(){}
    public virtual void Desc(){}
}
class Kettle : Device
{
    public override void Sound()
    {
        Console.WriteLine("Peeeeee");
    }
    public override void Show()
    {
        Console.WriteLine("\nKettle");
    }
    public override void Desc()
    {
        Console.WriteLine(
            "\nKettle" +
            "\nModel: X-Kettle" +
            "\nColor: black" +
            "\nMaterial: steel");
    }
}