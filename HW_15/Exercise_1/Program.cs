namespace Exercise_1;
using static Exercise_1.Phone;
using static Exercise_1.ListPhone;

/*
                             Задание 1
Создайте пользовательский тип Телефон. Необходимо хранить такую информацию:
 Название телефона
 Производитель
 Цена
 Дата выпуска
Для массива телефонов выполните следующие задания, используя
агрегатные операции из LINQ:
 Посчитайте количество телефонов
 Посчитайте количество телефонов с ценой больше 100
 Посчитайте количество телефонов с ценой в диапазоне от 400 до 700
 Посчитайте количество телефонов конкретного производителя
 Найдите телефон с минимальной ценой
 Найдите телефон с максимальной ценой
 Отобразите информацию о самом старом телефоне
 Отобразите информацию о самом свежем телефоне
 Найдите среднюю цену телефона
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
        listPhone.AddPhone(CreatePhoneSamsung());
        listPhone.AddPhone(CreatePhoneApple());
        listPhone.AddPhone(CreatePhoneGoogle());
        listPhone.AddPhone(CreatePhoneOnePlus());
        listPhone.AddPhone(CreatePhoneXiaomi());
        listPhone.AddPhone(CreatePhoneSony());

        return listPhone;
    }
    static Phone CreatePhoneSamsung()
    {
        Phone samsung =
            new Phone
            ("Samsung Galaxy S21 Ultra",
            "Samsung",
            1199,
            new DateTime(2021, 1, 29));

        return samsung;
    }
    static Phone CreatePhoneApple()
    {
        Phone iphone =
            new Phone
            ("Apple iPhone 13 Pro",
            "Apple",
            999,
            new DateTime(2021, 9, 14));

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
    }
}

