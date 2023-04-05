namespace Exercise_3;
using System.IO;
using System.Text.Json;

/*
                        Задание 3
Создайте класс «Кредитная карточка». Класс должен содержать:

■ Номер карты;
■ ФИО владельца;
■ Срок действия карты;
■ PIN;
■ Кредитный лимит;
■ Сумма денег.

Создайте необходимый набор методов класса.
Реализуйте события для следующих ситуаций:

■ Пополнение счёта;
■ Расход денег со счёта;
■ Старт использования кредитных денег;
■ Достижение заданной суммы денег;
■ Смена PIN.

 */

class CreditCard
{
    public string? numCard { get; set; }
    public string? ownerFIO { get; set; }
    public DateTime? expiryDate { get; set; }
    public short? ownerPIN { get; set; }
    public int? creditLimit { get; set; }
    public int? money { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        CreditCard card = new CreditCard
        {
            numCard = "1234 5678 9012 3456",
            ownerFIO = "Ivan Ivanov",
            expiryDate = new DateTime(2023, 12, 31),
            ownerPIN = 1234,
            creditLimit = 50000,
            money = 10000
        };

        // Преобразуем объект в JSON
        string usersToJson = JsonSerializer.Serialize(card);

        // Записываем JSON в файл
        const string file_name = "Users.json";
        File.WriteAllText(file_name, usersToJson);

        // Читаем JSON из файла
        string usersW = File.ReadAllText(file_name);
        
        // Десериализуем JSON в объект
        CreditCard users_card = JsonSerializer.Deserialize<CreditCard>(usersW);

        Console.WriteLine(usersW);
        Console.Read();
    }
}

