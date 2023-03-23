using System;
using System.Xml.Linq;

namespace Exercise_3;

/*
                Задание 3
Создайте класс «Заграничный паспорт».
Вам необходимо хранить информацию о
1.номере паспорта,
2.ФИО владельца,
3.дате выдачи и т.д.
Предусмотреть механизмы:
для инициализации полей класса. Если значение для
инициализации неверное, генерируйте исключение.
 */

class Program
{
    static void Main(string[] args)
    {
        Foreign_passport _passport = new Foreign_passport();
        _passport.Input_Foreign();
        Console.Read();
    }
}

class Foreign_passport
{
    private string Num { get; set; }
    private string FIO { get; set; }
    private string Date { get; set; }

    public Foreign_passport()
    {
        Num = "0000";
        FIO = "None None None";
        Date = "00.00.0000";
    }
    public void Input_Foreign()
    {
        try
        {
         Console.Write("\nВведите номер паспорта: ");
         Num = Console.ReadLine();
            if (string.IsNullOrEmpty(Num))
            {
                throw new Exception("Номер паспорта не может быть пустым!");
            }
         Console.Write("\nВведите FIO: ");
         FIO = Console.ReadLine();
            if (string.IsNullOrEmpty(FIO))
            {
                throw new Exception("ФИО не может быть пустым!");
            }
         Console.Write("\nВведите дату выдачи: ");
         Date = Console.ReadLine();
            if (string.IsNullOrEmpty(Date))
            {
                throw new Exception("Дата не может быть пустой!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Input_Foreign();
        }
    }
    public override string ToString()
    {
        return string.Format
        (
            $"\nForeign passport" +
            $"\nNum: {Num}" +
            $"\nFIO: {FIO}" +
            $"\nDate: {Date}"
            );
    }
}
