using System;
using System.IO;
using static Exercise_1.Firm;

/*
 Для массива фирм реализуйте следующие запросы:
 Получить информацию обо всех фирмах
 Получить фирмы, у которых в названии есть слово Food
 Получить фирмы, которые работают в области маркетинга
 Получить фирмы, которые работают в области маркетинга или IT
 Получить фирмы с количеством сотрудников, большем 100
 Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
 Получить фирмы, которые находятся в Лондоне
 Получить фирмы, у которых фамилия директора White
 Получить фирмы, которые основаны больше двух лет назад
 Получить фирмы со дня основания, которых прошло 123 дня
 Получить фирмы, у которых фамилия директора Black и название
фирмы содержит слово White
 */

namespace Exercise_1
{
    public class ListFirm
    {
        List<Firm> firms = new List<Firm>();

        public ListFirm() { }

        public void AddFirm(Firm firm)
        {
            this.firms.Add(firm);
        }
        //  Получить информацию обо всех фирмах
        public void Print_Firm()
        {
            foreach (var firm in firms)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, у которых в названии есть слово Food
        public void FilterByСompanyName(string Type)
        {
            var Filter = firms.Where(f => f.company_name.Contains(Type)).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }

        }
        //  Получить фирмы, которые работают в области маркетинга
        public void FilterByBusinessProfile(string Type)
        {
            var Filter = firms.Where(f => f.business_profile.Contains(Type)).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, которые работают в области маркетинга или IT
        public void FilterByBusinessProfileSeveral(string Type_one,
            string Type_two)
        {
            var Filter = firms.Where(
                business => business.business_profile == Type_one ||
                business.business_profile == Type_two).ToList();

            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы с количеством сотрудников, большем 100
        public void FilterByNumberStaff(int Type)
        {
            var Filter = firms.Where(f => f.number_staff > Type).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы с количеством сотрудников в диапазоне от 100 до 300
        public void FilterByNumberStaffSeveral(int Type_one, int Type_two)
        {
            var Filter = firms.Where(
                Staff => Staff.number_staff >= Type_one &&
                Staff.number_staff <= Type_two
                ).ToList();

            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, которые находятся в Лондоне
        public void FilterByAdress(string Type)
        {
            var Filter = firms.Where(adress => adress.address == Type).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, у которых фамилия директора White
        public void FilterByDirectorName(string Type)
        {
            var Filter = firms.Where
                (director => director.fio_director.EndsWith(Type)).ToList();
            // EndsWith() -  позволяет проверить, заканчивается
            // ли строка на заданную подстроку.
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, которые основаны больше двух лет назад
        public void FilterByTwoYearsAgo()
        {
            var Filter = firms.Where
                (date =>
                date.founding_date < new DateTime(year: 2021, month: 01, day: 1));
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы со дня основания, которых прошло 123 дня
        public void FilterBy123DayAgo()
        {
            var Filter = firms.Where
                (day =>
                (DateTime.Today - day.founding_date).Days == 123).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }
        }
        //  Получить фирмы, у которых фамилия директора Black и название
        // фирмы содержит слово White
        public void FilterByBlackAndWhite()
        {
            var Filter = firms.Where
                (fil => fil.fio_director.EndsWith("Black")
                && fil.company_name.EndsWith("White")).ToList();
            foreach (Firm firm in Filter)
            {
                firm.Print_Firm();
            }

        }
    }
}

