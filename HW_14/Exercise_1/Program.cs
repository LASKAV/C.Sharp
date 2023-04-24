using System;
using static Exercise_1.Firm;
namespace Exercise_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListFirm _firms = CreateFirm();

            Console.WriteLine("Получить информацию обо всех фирмах");
            _firms.Print_Firm();

            Console.WriteLine("Получить фирмы," +
                " у которых в названии есть слово Food");

            _firms.FilterByСompanyName("Food");

            Console.WriteLine("Получить фирмы," +
                " которые работают в области маркетинга");

            _firms.FilterByBusinessProfile("marketing");

            Console.WriteLine("Получить фирмы," +
                " которые работают в области маркетинга или IT");
            _firms.FilterByBusinessProfileSeveral("marketing", "IT");

            Console.WriteLine("Получить фирмы" +
                " с количеством сотрудников, большем 100");
            _firms.FilterByNumberStaff(100);

            Console.WriteLine("Получить фирмы" +
                " с количеством сотрудников в диапазоне от 100 до 300");
            _firms.FilterByNumberStaffSeveral(100, 300);

            Console.WriteLine("Получить фирмы, которые находятся в Лондоне");
            _firms.FilterByAdress("London");

            Console.WriteLine("Получить фирмы," +
                " у которых фамилия директора White");
            _firms.FilterByDirectorName("White");

            Console.WriteLine("Получить фирмы," +
                " которые основаны больше двух лет назад");
            _firms.FilterByTwoYearsAgo();

            Console.WriteLine("Получить фирмы" +
                " со дня основания, которых прошло 123 дня");
            _firms.FilterBy123DayAgo();

            Console.WriteLine("Получить фирмы," +
                " у которых фамилия директора Black и название " +
                "фирмы содержит слово White");
            _firms.FilterByBlackAndWhite();

            Console.WriteLine("Получить всех сотрудников конкретной фирмы");
            _firms.FilterByEmployeeFirm("Asus");

            Console.WriteLine("Получить всех сотрудников конкретной фирмы," +
                " у которых заработные платы больше заданной");
            _firms.FilterByEmployeeSalary("Amazon", 3000);

            Console.WriteLine("Получить сотрудников всех фирм," +
                " у которых должность менеджер");
            _firms.FilterByEmployeeManager();

            Console.WriteLine("Получить сотрудников," +
                " у которых телефон начинается с 23");
            _firms.FilterByEmployeePhone();

            Console.WriteLine("Получить сотрудников," +
                " у которых Email начинается с di");
            _firms.FilterByEmployeeEmail();

            Console.WriteLine("Получить сотрудников, у которых имя Lionel");
            _firms.FilterByEmployeeName();


            Console.Read();
        }
        static ListFirm CreateFirm()
        {
            Firm firm = new Firm();
            ListFirm listFirm = new ListFirm();
            firm = CreateFirmASUS();
            listFirm.AddFirm(firm);
            firm = CreateFirmAmazon();
            listFirm.AddFirm(firm);
            firm = CreateFirmFood();
            listFirm.AddFirm(firm);
            firm = CreateFirmITSolutions();
            listFirm.AddFirm(firm);
            firm = CreateFirmMarketing();
            listFirm.AddFirm(firm);
            firm = CreateFirmFromLondon();
            listFirm.AddFirm(firm);
            return listFirm;
        }
        static Firm CreateFirmASUS()
        {
            Firm firm = new Firm(
                "Asus",
                new DateTime(1990,4,12),
                "technologies",
                "John Smith",
                100,
                "123 Main St.",
               new Employee
                (
                 "Lionel Doe",
                 "Manager",
                 "555-1234",
                 "johndoe@example.com",
                 50000
                )
            );
            return firm;
        }
        static Firm CreateFirmAmazon()
        {
            Firm firm = new Firm(
                "Amazon",
                new DateTime(1994, 7, 5),
                "E-commerce",
                "Jeff Bezos",
                1298000,
                "410 Terry Avenue North, Seattle, Washington, U.S.",
                new Employee
               (
                 "Jane Smith",
                 "Manager",
                 "555-5678",
                 "dinesmith@example.com",
                 30000
               )
            );
            return firm;
        }
        static Firm CreateFirmFood()
        {
            Firm firm = new Firm(
            "Food White",
            new DateTime(2000, 1, 1),
            "Food and Beverage",
            "Jane Black",
            100,
            "456 Main St.",
            new Employee
                (
                "Tom Wilson",
                "Engineer",
                "235-7890",
                "diilson@example.com",
                60000
                )
            );
            return firm;
        }
        static Firm CreateFirmMarketing()
        {
   
            Firm firm = new Firm(
                "Marketing Inc.",
                new DateTime(2022,12,22),
                "marketing",
                "Jane White",
                300,
                "456 Market St.",
                new Employee
                (
                    "Alice Johnson",
                    "Manager",
                    "235-4321",
                    "alicejohnson@example.com",
                    60000
                )
            );
            return firm;
        }
        static Firm CreateFirmITSolutions()
        {
            Firm firm = new Firm(
                "IT Solutions",
                new DateTime(2020,1,15),
                "IT",
                "Bob White",
                75,
                "789 Tech Ave.",
                new Employee(
                    "Lionel Wilson",
                    "Manager",
                    "555-7890",
                    "twilson@example.com",
                    60000
                    )
               
            );
            return firm;
        }
        static Firm CreateFirmFromLondon()
        {
            
            Firm firm =
                new Firm("FirmLondon",
                new DateTime(2000, 1, 1),
                "Marketing",
                "John Smith",
                150,
                "London",
                new Employee
                (
                    "Bob Johnson",
                    "Analyst",
                    "235-9012",
                    "bjohnson@example.com",
                    45000
                )
                );
            return firm;
        }
    }
}