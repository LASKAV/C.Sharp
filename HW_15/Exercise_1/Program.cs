namespace Exercise_1;
using static Exercise_1.Phone;
using static Exercise_1.ListPhone;

/*
                    Задание 3:
Добавьте к первому заданию новую функциональность:
 Отобразите статистику по количеству
телефонов каждого производителя.
Например: Sony – 3, Samsung – 4, Apple – 5 и т. д.
 Отобразите статистику по количеству
моделей телефонов.
Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8
 Отобразите статистику телефонов по годам.
Например: 2021 – 10, 2022 – 5, 2019 – 3
 */

class Program
{
    static void Main(string[] args)
    {
        Exer_one();
        
        


        Console.Read();
    }


    static ListPhone CreateList()
    {
        ListPhone listPhone = new ListPhone();
        listPhone.AddPhone(CreatePhonesSamsungS21());
        listPhone.AddPhone(CreatePhonesSamsungS21());
        listPhone.AddPhone(CreatePhonesSamsungS20());
        listPhone.AddPhone(CreatePhonesSamsungZFlip());
        listPhone.AddPhone(CreatePhonesSamsungA52s5G());
        listPhone.AddPhone(CreatePhonesSamsungA52s5G());
        listPhone.AddPhone(CreatePhonesSamsungA52s5G());
        listPhone.AddPhone(CreatePhonesSamsungA71());
        listPhone.AddPhone(CreatePhoneApple());
        listPhone.AddPhone(CreatePhoneApple());
        listPhone.AddPhone(CreatePhoneApple());
        listPhone.AddPhone(CreatePhoneGoogle());
        listPhone.AddPhone(CreatePhoneOnePlus());
        listPhone.AddPhone(CreatePhoneOnePlus());
        listPhone.AddPhone(CreatePhoneOnePlus());
        listPhone.AddPhone(CreatePhoneXiaomi());
        listPhone.AddPhone(CreatePhoneSony());
        listPhone.AddPhone(CreatePhoneSony());

        return listPhone;
    }
    static Phone CreatePhonesSamsungS21()
    {

        Phone samsung1 = new Phone(
            "Samsung Galaxy S21 Ultra",
            "Samsung",
            1199,
            new DateTime(2021, 1, 29));
        return samsung1;
    }
    static Phone CreatePhonesSamsungS20()
    {
        Phone samsung2 = new Phone(
            "Samsung Galaxy Note 20 Ultra",
            "Samsung",
            1299,
            new DateTime(2020, 8, 21));
        return samsung2;
    }
    static Phone CreatePhonesSamsungZFlip()
    {
        Phone samsung3 = new Phone(
           "Samsung Galaxy Z Flip",
           "Samsung",
           1399,
           new DateTime(2020, 2, 11));
        return samsung3;
    }
    static Phone CreatePhonesSamsungA52s5G()
    {
        Phone samsung4 = new Phone(
            "Samsung Galaxy A52s 5G",
            "Samsung",
            499,
            new DateTime(2021, 9, 3));

        return samsung4;
    }
    static Phone CreatePhonesSamsungA71()
    {
        Phone samsung5 = new Phone(
            "Samsung Galaxy A71",
            "Samsung",
            499,
            new DateTime(2019, 12, 27));
        return samsung5;
    }
    static Phone CreatePhoneApple()
    {
        Phone iphone =
            new Phone
            ("Apple iPhone 13 Pro",
            "Apple",
            999,
            new DateTime(2021, 9, 14));

         iphone =
            new Phone
        ("iPhone 12 Pro Max",
         "Apple",
         1099,
         new DateTime(2020, 11, 6));
        
        return iphone;
    }
    static Phone CreatePhoneGoogle()
    {
        Phone pixel =
            new Phone
            ("Google Pixel 6 Pro",
            "Google",
            99,
            new DateTime(2021, 10, 28));

        return pixel;
    }
    static Phone CreatePhoneOnePlus()
    {
        Phone oneplus =
            new Phone
            ("OnePlus 10 Pro",
            "OnePlus",
            600,
            new DateTime(2022, 3, 25));

        return oneplus;
    }
    static Phone CreatePhoneXiaomi()
    {
        Phone xiaomi =
            new Phone
            ("Xiaomi Mi 12",
            "Xiaomi",
            400,
            new DateTime(2022, 2, 22));

        return xiaomi;
    }
    static Phone CreatePhoneSony()
    {
        Phone sony =
            new Phone
            ("Sony Xperia 1 III",
            "Sony",
            1299,
            new DateTime(2021, 8, 19));

        return sony;
    }
    static void Exer_one()
    {
        ListPhone listPhone = CreateList();
        // listPhone.ShowPhoneList();
        //  Посчитайте количество телефонов
        Console.WriteLine("Посчитайте количество телефонов:");
        listPhone.FilterByNumberPhones();

        //  Посчитайте количество телефонов с ценой больше 100
        Console.WriteLine("Посчитайте количество телефонов с ценой больше 100");
        listPhone.FilterByNumberOverPrice();

        //  Посчитайте количество телефонов с ценой в диапазоне от 400 до 700
        Console.WriteLine("Посчитайте количество" +
            " телефонов с ценой в диапазоне от 400 до 700");
        listPhone.FilterByNumberRangePrice();

        //  Посчитайте количество телефонов конкретного производителя
        Console.WriteLine("Посчитайте количество" +
            " телефонов конкретного производителя");
        listPhone.FilterByManufacturer("Samsung");

        //  Найдите телефон с минимальной ценой
        Console.WriteLine("Найдите телефон с минимальной ценой: ");
        listPhone.FilterByMinPrice();

        //  Найдите телефон с максимальной ценой
        Console.WriteLine("Найдите телефон с максимальной ценой: ");
        listPhone.FilterByMaxPrice();

        //  Отобразите информацию о самом старом телефоне
        Console.WriteLine("Отобразите информацию о самом старом телефоне: ");
        listPhone.FilterByOldPhone();

        //  Отобразите информацию о самом свежем телефоне
        Console.WriteLine("Отобразите информацию о самом свежем телефоне: ");
        listPhone.FilterByNewPhone();

        //  Найдите среднюю цену телефона
        Console.WriteLine("Найдите среднюю цену телефона: ");
        listPhone.FilterByMidPrice();

        //  Отобразите пять самых дорогих телефонов
        Console.WriteLine("Отобразите пять самых дорогих телефонов");
        listPhone.FilterByFiveExpensivePhones();

        //  Отобразите пять самых дешевых телефонов
        Console.WriteLine("Отобразите пять самых дешевых телефонов");
        listPhone.FilterByFiveCheapPhones();

        //  Отобразите три самых старых телефона
        Console.WriteLine("Отобразите три самых старых телефона");
        listPhone.FilterByFiveOldPhones();

        //  Отобразите три самых новых телефона
        Console.WriteLine("Отобразите три самых новых телефона");
        listPhone.FilterByFiveNewPhones();

        //  Отобразите статистику по количеству
        // телефонов каждого производителя.
        Console.WriteLine("Отобразите статистику" +
            " по количеству телефонов каждого производителя.");
        listPhone.FilterByStatsManufacturer();

        //  Отобразите статистику по количеству
        // моделей телефонов.
        Console.WriteLine("Отобразите статистику" +
            " по количеству моделей телефонов.");
        listPhone.FilterByStatsModel();

        //  Отобразите статистику телефонов по годам.
        Console.WriteLine("Отобразите статистику телефонов по годам");
        listPhone.FilterByStatsYear();
    }

}

