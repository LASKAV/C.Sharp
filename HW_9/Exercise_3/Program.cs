namespace Exercise_3;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Timers;

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
    // Событие для пополнения счета
    public event Action<string> AccountTopUp;

    // Событие для расхода денег со счета
    public event Action<string> MoneySpent;

    // Событие для использования кредитных денег
    public event Action<string> Creditlimit;

    // Событие для смены PIN
    public event Action<string> СhangePIN;


    public string? numCard { get; set; }
    public string? ownerFIO { get; set; }
    public DateTime? expiryDate { get; set; }
    public short? ownerPIN { get; set; }
    public int? creditLimit { get; set; }
    public int? balance { get; set; }
    
    public CreditCard(string numCard,string ownerFIO,
                      DateTime expiryData, short ownerPIN,
                      int creditLimit, int money)
    {
        this.numCard = numCard;
        this.ownerFIO = ownerFIO;
        this.expiryDate = expiryData;
        this.ownerPIN = ownerPIN;
        this.creditLimit = creditLimit;
        this.balance = money;
    }

    public void Show_user()
    {
        Console.WriteLine("Card Information:");
        Console.WriteLine("------------------------");
        Console.WriteLine("Card Number: " + numCard);
        Console.WriteLine("Card Owner: " + ownerFIO);
        Console.WriteLine("Expiry Date: " + expiryDate);
        Console.WriteLine("Owner PIN: " + ownerPIN);
        Console.WriteLine("Credit Limit: " + creditLimit + "$");
        Console.WriteLine("Money: " + balance + "$");
    }
    public void Top_up_card()
    {
        do
        {
            Console.WriteLine($"На счету: {balance}$");
            Console.Write("Введите сумму пополнения: ");
            int? temp_money = int.Parse(Console.ReadLine());
            Console.WriteLine("Обработка транзакции");
            if (temp_money != 0)
            {
                balance += temp_money;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Операция прошла успешно" +
                        $"\nБаланс: {balance}$");
                AccountTopUp?.Invoke($"{ownerFIO} успешно пополнил" +
                        $"\nБаланс: {balance}$");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " +
                    $" вы хотели поплнить счет: {temp_money}$");
                AccountTopUp?.Invoke("Ошибка: " +
                    $" {ownerFIO} пытался пополнить на " +
                    $"не допустимую сумму {balance}$");
                Console.ResetColor();
                continue;
            }
        } while (true);
        
    }
    public void Withdraw_card()
    {
        do
        {
            Console.WriteLine($"На счету: {balance}$");
            Console.Write("Введите сумму снятия: ");
            int? temp_money = int.Parse(Console.ReadLine());
            Console.WriteLine("Обработка транзакции");
            // Thread.Sleep(5000);
            if (temp_money < balance)
            {
                balance -= temp_money;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Операция прошла успешно" +
                        $"\nБаланс: {balance}$");
                MoneySpent?.Invoke($"{ownerFIO} успешно снял" +
                        $"\nБаланс: {balance}$");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " +
                    $" у вас не достаточно баланса на счету {balance}$");
                MoneySpent?.Invoke("Ошибка: " +
                    $" {ownerFIO} пытался снять не допустимую сумму {balance}$");
                Console.ResetColor();
                continue;
            }
        } while (true);
        
    }
    public void Use_credit_money()
    {
        do
        {
            Console.WriteLine($"Кредитный лимит: {creditLimit}$");

            Console.Write("Введите сумму снятия: ");
            int? temp_money = int.Parse(Console.ReadLine());
            Console.WriteLine("Обработка транзакции");
            // Thread.Sleep(5000);
            if (temp_money < balance)
            {
                balance -= temp_money;
                Console.ForegroundColor = ConsoleColor.Green;
                MoneySpent?.Invoke($"Операция прошла успешно" +
                        $"\nБаланс: {balance}$");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MoneySpent?.Invoke("Ошибка: " +
                    $" у вас не достаточно баланса на счету {balance}$");
                Console.ResetColor();
                continue;
            }
        } while (true);
    }
    public void Сategories_limit()
    {
        do
        {
            Console.ResetColor();
            Console.WriteLine("1 - Продукты");
            Console.WriteLine("2 - Транспорт");
            Console.WriteLine("3 - Коммунальные услуги");
            Console.WriteLine("4 - Развлечения");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Выберите категорию затрат:");
            int categoryChoice = int.Parse(Console.ReadLine());
            int? categories_spend;
            if (creditLimit != 0)
            {
                switch (categoryChoice)
                {
                    case 1:
                        // Продукты
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Введите сумму затраты: ");
                        categories_spend = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Кредитный лимит:" +
                            $" {creditLimit - categories_spend}");
                        Creditlimit?.Invoke($"{ownerFIO} совершил " +
                            "покупку за кредитные деньги");
                        break;
                    case 2:
                        // Транспорт
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Введите сумму затраты: ");
                        categories_spend = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Кредитный лимит:" +
                            $" {creditLimit - categories_spend}");
                        Creditlimit?.Invoke($"{ownerFIO} совершил " +
                            "покупку за кредитные деньги");
                        Console.WriteLine();
                        break;
                    case 3:
                        // Коммунальные услуги
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Введите сумму затраты: ");
                        categories_spend = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Кредитный лимит:" +
                            $" {creditLimit - categories_spend}");
                        Creditlimit?.Invoke($"{ownerFIO} совершил " +
                            "покупку за кредитные деньги");
                        Console.WriteLine();
                        break;
                    case 4:
                        // Развлечения
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Введите сумму затраты: ");
                        categories_spend = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Кредитный лимит:" +
                            $" {creditLimit - categories_spend}");
                        Creditlimit?.Invoke($"{ownerFIO} совершил " +
                            "покупку за кредитные деньги");
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Выход");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nОшибка: выберите категорию от 1 до 5 \n");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Ошибка {ownerFIO}" +
                $" ваш кредитный лимит: {creditLimit}");
                Creditlimit?.Invoke($"Ошибка {ownerFIO}" +
                $" использования кредитный денег : {creditLimit}");
            }

        } while (true);
    }
    public void Reset_PIN()
    {
        short? temp_pin = ownerPIN;
        Console.WriteLine($"Ваш PIN : {ownerPIN}");
        Console.Write($"Введите новый PIN: ");
        ownerPIN = short.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.Red;
        СhangePIN?.Invoke($"{ownerFIO} сделал замену PIN {temp_pin} на новый {ownerPIN} ");
        Console.WriteLine($"Операция прошла успешно" +
                        $"\nPIN new : {ownerPIN}$");
        Console.ResetColor();
    }
}


class Program
{
    static void Main(string[] args)
    {
        CreditCard _user =
            new CreditCard("1234 5678 9012 3456","Ivan Ivanov",
            new DateTime(2023, 12, 31),1234,50000,10000);
        // Подписка на ivents 
        _user.MoneySpent += IventMoney;
        _user.AccountTopUp += IventMoney;
        _user.Creditlimit += IventMoney;
        _user.СhangePIN += IventMoney;
        //_________________________________//
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Пополнение счёта");
            Console.WriteLine("2. Расход денег со счёта");
            Console.WriteLine("3. Использование кредитных денег");
            Console.WriteLine("4. Замена PIN");
            Console.WriteLine("5. Информация пользователя");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите категорию: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _user.Top_up_card();
                    break;
                case "2":
                    _user.Withdraw_card();
                    break;
                case "3":
                    _user.Сategories_limit();
                    break;
                case "4":
                    _user.Reset_PIN();
                    break;
                case "5":
                    _user.Show_user();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nОшибка: выберите от 1 до 6 \n");
                    break;
            }
        }
        //_________________________________//
        Console.Read();
    }
    public static void IventMoney(string message)
        => Console.WriteLine(message);

}

