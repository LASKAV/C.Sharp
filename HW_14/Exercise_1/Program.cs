using System;
using static Exercise_1.Firm;
namespace Exercise_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListFirm _firms = CreateFirm();

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
                "123 Main St."
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
                "410 Terry Avenue North, Seattle, Washington, U.S."
            );
            return firm;
        }
        static Firm CreateFirmFood()
        {
            Firm firm = new Firm(
            "Food",
            new DateTime(2000, 1, 1),
            "Food and Beverage",
            "Jane Doe",
            100,
            "456 Main St."
            );
            return firm;
        }
        static Firm CreateFirmMarketing()
        {
            Firm firm = new Firm(
                "Marketing Inc.",
                new DateTime(2005,7,3),
                "marketing",
                "Jane Doe",
                300,
                "456 Market St."
            );
            return firm;
        }
        static Firm CreateFirmITSolutions()
        {
            Firm firm = new Firm(
                "IT Solutions",
                new DateTime(2010,1,15),
                "IT",
                "Bob Johnson",
                75,
                "789 Tech Ave."
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
                "London");
            return firm;
        }
    }
}