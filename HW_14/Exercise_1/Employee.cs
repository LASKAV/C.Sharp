using System;

/*
сотрудниках. Нужно хранить такие данные:
 ФИО сотрудника
 Должность
 Контактный телефон
 Email
 Заработная плата
 */

namespace Exercise_1
{
    public class Employee
    {
        public string full_name { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public decimal salary { get; set; }

        public Employee() { }

        public Employee(string fullName,
            string position, string phone,
            string email, decimal salary)
        {
            this.full_name = fullName;
            this.position = position;
            this.phone = phone;
            this.email = email;
            this.salary = salary;
        }
        public void Print_Employee()
        {
            Console.WriteLine(
                $"\nName: {full_name}" +
                $"\nPosition: {position}" +
                $"\nPhone: {phone}" +
                $"\nEmail: {email}" +
                $"\nSalary: {salary}\n");
        }
    }
}

