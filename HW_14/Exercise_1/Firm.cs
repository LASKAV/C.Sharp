using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
 Реализуйте пользовательский тип Фирма.
В нём должна быть информация о
1.названии фирмы,
2.дате основания,
3.профиле бизнеса (маркетинг, IT, и т. д.),
4.ФИО директора,
5.количество сотрудников,
6.адрес.
 */

namespace Exercise_1
{
    public class Firm
    {
       public string company_name { get; set; }
       public DateTime founding_date { get; set; }
       public string business_profile { get; set; }
       public string fio_director { get; set; }
       public int number_staff { get; set; }
       public string address { get; set; }
        public List<Employee> employees = new List<Employee>();

        public Firm(){}
        public Firm(string company_name, DateTime date,
            string business_profile, string fio_director,
            int number_staff, string address, Employee employee)
        {
            this.company_name = company_name;
            this.founding_date = new DateTime(date.Year, date.Month, date.Day);
            this.business_profile = business_profile;
            this.fio_director = fio_director;
            this.number_staff = number_staff;
            this.address = address;
            this.employees.Add(employee);
        }
        public void Print_Firm()
        {
            Console.WriteLine(
            $"\nName: {company_name}" +
            $"\nDate: {founding_date.ToString("yyyy-MM-dd")}" +
            $"\nProfile: {business_profile}" +
            $"\nDirector: {fio_director}" +
            $"\nStaff: {number_staff}" +
            $"\nAddress: {address}\n");
            foreach (Employee employee in employees)
            {
                employee.Print_Employee();
            }



        }
    }
}

