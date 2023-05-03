using System;
using NLog;
using Faker;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using NLog.Fluent;
using NLog;


namespace Exercise_2
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Старт генерации фейковых пользователей");

            for (int i = 0; i < 10; i++)
            {
                var fakeUser = new User
                {
                    FirstName = Name.First(),
                    LastName = Name.Last(),
                    Phone = Phone.Number(),
                    Email = Internet.Email(),
                    Address = Address.FullAddress()
                };

                Log.Debug("Сгенерирован фейковый пользователь: {@User}", fakeUser);
            }

            Log.Information("Генерация фейковых пользователей завершена");

            Console.ReadLine();
        }
    }
}


