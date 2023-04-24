using System;
using System.IO;
using static System.Net.WebRequestMethods;
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

Для массива сотрудников фирмы реализуйте следующие запросы:
 Получить всех сотрудников конкретной фирмы
 Получить всех сотрудников конкретной фирмы, у которых
заработные платы больше заданной
 Получить сотрудников всех фирм, у которых должность
менеджер
 Получить сотрудников, у которых телефон начинается с 23
 Получить сотрудников, у которых Email начинается с di
 Получить сотрудников, у которых имя Lionel

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
        //  Получить всех сотрудников конкретной фирмы
        public void FilterByEmployeeFirm(string Type)
        {
            var Filter = firms.Where
                (emplFirm => emplFirm.company_name == Type).ToList();
            Console.WriteLine($"Firm: {Type}");
            foreach (Firm firm in Filter)
            {
                foreach (Employee employee in firm.employees)
                {
                    employee.Print_Employee();
                }
            }
        }
        //  Получить всех сотрудников конкретной фирмы, у которых
        // заработные платы больше заданной
        public void FilterByEmployeeSalary(string Type, decimal salary)
        {
            var Filter_firm = firms.Where
                (sal => sal.company_name == Type).ToList();

            Console.WriteLine($"Firm: {Type}");
            foreach (Firm firm in Filter_firm)
            {
                var Filter_empl = firm.employees.
                    Where(empl => empl.salary > salary).ToList();
                foreach (Employee employee in Filter_empl)
                {
                    employee.Print_Employee();
                }
            }
           




        }
        //  Получить сотрудников всех фирм, у которых должность
        // менеджер
        public void FilterByEmployeeManager()
        {
            var managers = firms.SelectMany(firm => firm.employees)
                        .Where(employee => employee.position == "Manager")
                        .ToList();
            // SelectMany - для объединения списков сотрудников из всех фирм
            foreach (var manager in managers)
            {
                Console.WriteLine(
                    $"\nName: {manager.full_name}\n" +
                    $"Position: {manager.position}\n");
            }
        }
        //  Получить сотрудников, у которых телефон начинается с 23
        public void FilterByEmployeePhone()
        {
            var Filter = firms.SelectMany(fir => fir.employees)
                .Where(pho => pho.phone.StartsWith("23")).ToList();
            foreach (var manager in Filter)
            {
                Console.WriteLine(
                    $"\nName: {manager.full_name}\n" +
                    $"Position: {manager.phone}\n");
            }
        }
        //  Получить сотрудников, у которых Email начинается с di
        public void FilterByEmployeeEmail()
        {
            var Filter = firms.SelectMany(fir => fir.employees)
                .Where(emal => emal.email.StartsWith("di")).ToList();

            foreach (var manager in Filter)
            {
                Console.WriteLine(
                    $"\nName: {manager.full_name}\n" +
                    $"Position: {manager.email}\n");
            }
        }
        //  Получить сотрудников, у которых имя Lionel
        public void FilterByEmployeeName()
        {
            var Filter = firms.SelectMany(fir => fir.employees)
                .Where(name => name.full_name.StartsWith("Lionel")).ToList();

            foreach (var manager in Filter)
            {
                Console.WriteLine(
                    $"\nName: {manager.full_name}\n" +
                    $"Position: {manager.email}\n");
            }

        }
    }
}

