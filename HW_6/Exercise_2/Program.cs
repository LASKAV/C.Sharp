using static System.Net.Mime.MediaTypeNames;

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
        do
        {
            short choices = 0;
            Console.WriteLine
                ("___Device menu___" +
                "\n1.Kerrle" +
                "\n2.Microwave" +
                "\n3.Car" +
                "\n4.Steamship" +
                "\n5.Exit"
                );
            Console.Write("choices: "); choices = short.Parse(Console.ReadLine());
            switch(choices)
            {
                case 1:
                    Device _kettle = new Kettle();
                    _kettle.Sound();
                    _kettle.Show();
                    _kettle.Desc();
                    break;
                case 2:
                    Device _microwave = new Microwave();
                    _microwave.Sound();
                    _microwave.Show();
                    _microwave.Desc();
                    break;
                case 3:
                    Device _Car = new Car();
                    _Car.Sound();
                    _Car.Show();
                    _Car.Desc();
                    break;
                case 4:
                    Device _Steamship =  new Steamship();
                    _Steamship.Sound();
                    _Steamship.Show();
                    _Steamship.Desc();
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    return;
                    break;
                default:
                    Console.WriteLine("ERROR : wrong choice!");
                    break;
            }
        } while (true);
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
class Microwave : Device
{
    public override void Sound()
    {
        Console.WriteLine("Hhhhhhhhh");
    }
    public override void Show()
    {
        Console.WriteLine("\nMicrowave");
    }
    public override void Desc()
    {
        Console.WriteLine(
            "\nMicrowave" +
            "\nModel: X-Microwave" +
            "\nColor: black" +
            "\nMaterial: steel");
    }
}
class Car : Device
{
    public override void Sound()
    {
        Console.WriteLine("Gggggggg");
    }
    public override void Show()
    {
        Console.WriteLine("\nCar");
    }
    public override void Desc()
    {
        Console.WriteLine(
            "\nCar" +
            "\nModel: X-Car" +
            "\nColor: black" +
            "\nMaterial: steel");
    }
}
class Steamship : Device
{
    public override void Sound()
    {
        Console.WriteLine("Tyty");
    }
    public override void Show()
    {
        Console.WriteLine("\nSteamship");
    }
    public override void Desc()
    {
        Console.WriteLine(
            "\nSteamship" +
            "\nModel: X-Steamship" +
            "\nColor: Red" +
            "\nMaterial: steel");
    }
}