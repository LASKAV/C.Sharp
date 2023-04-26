using System;

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
        //  Отобразите пять самых дорогих телефонов
        public void FilterByFiveExpensivePhones()
        {
            var Filter = phones.OrderByDescending(pho => pho.price).Take(5);

            foreach (Phone item in Filter)
            {
                item.ShowPhone();
            }
        }
        //  Отобразите пять самых дешевых телефонов
        public void FilterByFiveCheapPhones()
        {
            var Filter = phones.OrderBy(pho => pho.price).Take(5);

            foreach (Phone item in Filter)
            {
                item.ShowPhone();
            }

        }
        //  Отобразите три самых старых телефона
        public void FilterByFiveOldPhones()
        {
            var Filter = phones.OrderBy(phe => phe.release_date).Take(3);

            foreach (Phone item in Filter)
            {
                item.ShowPhone();
            }
        }
        //  Отобразите три самых новых телефона
        public void FilterByFiveNewPhones()
        {
            var Filter = phones.OrderByDescending(phe => phe.release_date).Take(3);

            foreach (Phone item in Filter)
            {
                item.ShowPhone();
            }
        }
        //  Отобразите статистику по количеству
        // телефонов каждого производителя.
        // Например: Sony – 3, Samsung – 4, Apple – 5 и т. д.
        public void FilterByStatsManufacturer()
        {
            var Filter = phones.GroupBy(x => x.manufacturer).
                Select(y => new {Model = y.Key, Count = y.Count()});

            foreach (var item in Filter)
            {
                Console.WriteLine($"Производитель {item.Model}" +
                    $" - {item.Count} шт.");
            }
        }
        //  Отобразите статистику по количеству
        // моделей телефонов.
        // Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8
        public void FilterByStatsModel()
        {
            var Filter = phones.GroupBy(x => x.title).
                Select(y => new { Model = y.Key, Count = y.Count() });

            foreach (var item in Filter)
            {
                Console.WriteLine($"Модель {item.Model}" +
                    $" - {item.Count} шт.");
            }
        }
        //  Отобразите статистику телефонов по годам.
        // Например: 2021 – 10, 2022 – 5, 2019 – 3
        public void FilterByStatsYear()
        {
            var Filter = phones.GroupBy(x => x.release_date.Year).
                Select(y => new { Model = y.Key, Count = y.Count() });

            foreach (var item in Filter)
            {
                Console.WriteLine($"Год {item.Model}"+
                    $" - {item.Count} шт.");
            }
        }
    }
}

