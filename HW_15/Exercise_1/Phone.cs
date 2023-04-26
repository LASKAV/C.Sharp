using System;

/*
 Создайте пользовательский тип Телефон. Необходимо хранить такую информацию:
 Название телефона
 Производитель
 Цена
 Дата выпуска
 */

namespace Exercise_1
{
    public class Phone
    {
        public string title;
        public string manufacturer;
        public decimal price;
        public DateTime release_date;

        public Phone(){}
        public Phone(
            string title, string manufacturer ,
            decimal price, DateTime date)
        {
            this.title = title;
            this.manufacturer = manufacturer;
            this.price = price;
            this.release_date = new DateTime(date.Year, date.Month, date.Day);
        }
        public void ShowPhone()
        {
            Console.WriteLine
                (
                $"\nTitle: {title}" +
                $"\nManufacturer: {manufacturer}" +
                $"\nPrice: {price:C}" +
                $"\nRelease Date: {release_date.ToString("dd.MM.yy")}\n");
        }

    }
}

