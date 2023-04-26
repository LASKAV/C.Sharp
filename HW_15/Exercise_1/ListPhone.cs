using System;

/*
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

namespace Exercise_1
{
    public class ListPhone : Phone
    {
        List<Phone> phones = new List<Phone>();

        public ListPhone() { }
        public void AddPhone(Phone phone)
        {
            this.phones.Add(phone);
        }
        public void ShowPhoneList()
        {
            foreach (Phone item in phones)
            {
                item.ShowPhone();
            }
        }
        //  Посчитайте количество телефонов
        public void FilterByNumberPhones()
        {
            int count_phone = phones.Count();
            Console.WriteLine($"Количество телефонов: {count_phone}");

        }
        //  Посчитайте количество телефонов с ценой больше 100
        public void FilterByNumberOverPrice()
        {
            var Filter = phones.Count(phon => phon.price > 100);
            Console.WriteLine($"Количество телефонов: {Filter}");
        }
        //  Посчитайте количество телефонов с ценой в диапазоне от 400 до 700
        public void FilterByNumberRangePrice()
        {
            var Filter = phones.Count(pho => pho.price >= 400 && pho.price <= 700);
            Console.WriteLine($"Количество телефонов: {Filter}");
        }
        //  Посчитайте количество телефонов конкретного производителя
        public void FilterByManufacturer(string Type)
        {
            var Filter = phones.Count(pho => pho.manufacturer == Type);
            Console.WriteLine($"Количество телефонов: {Filter}");
        }
        //  Найдите телефон с минимальной ценой
        public void FilterByMinPrice()
        {
            var Filter = phones
                .Min(pho => pho.price);
            var Min = phones.First(phe => phe.price == Filter);

            Console.WriteLine($"Телефон {Min.title} с" +
                $" минимальной ценой: {Filter}");
        }
        //  Найдите телефон с максимальной ценой
        public void FilterByMaxPrice()
        {
            var Filter = phones.Max(phe => phe.price);
            var Max = phones.First(phe => phe.price == Filter);

            Console.WriteLine($"Телефон {Max.title} с" +
                $" максимальной ценой: {Filter}");
        }
        //  Отобразите информацию о самом старом телефоне
        public void FilterByOldPhone()
        {
            var Filter = phones
                .Min(phoe => phoe.release_date);
            var tel = phones.First(phe => phe.release_date == Filter);

            tel.ShowPhone();
            
        }
        //  Отобразите информацию о самом свежем телефоне
        public void FilterByNewPhone()
        {
            var Fileter = phones.Max(phon => phon.release_date);
            var tel = phones.First(phe => phe.release_date == Fileter);

            tel.ShowPhone();
        }
        //  Найдите среднюю цену телефона
        public void FilterByMidPrice()
        {
            var Filter = phones.Average(pric => pric.price);
            Console.WriteLine($"Средняя цена телефона: {Filter:C}");
        }
    }
}

