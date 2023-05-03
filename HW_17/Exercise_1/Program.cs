using System.Net;
using System.Numerics;
using System.Xml.Linq;
using static Exercise_2.User;
using NLog.Fluent;
using NLog;

namespace Exercise_2
{
    /*
                                Задание 2:
    Создайте приложение для генерации фейковых пользователей.
    У каждого пользователя должна быть такая информация:

     Имя
     Фамилия
     Контактный телефон
     Email
     Адрес

    Генерация фейковых пользователей должна быть оформлена
    в виде класса. Фактически нужно создать класс для
    генерации фейкового пользователя.

    Напишите код для тестирования фейковых пользователей
    В программе настройте логирование с использованием Serialog.

     */
    class Program
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Настройка логирования с использованием Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Старт генерации пользователей");

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

                Log.Debug("Сгенерирован пользователь: {@User}", fakeUser);
            }

            Log.Information("Генерация фейковых пользователей завершена");

            Console.ReadLine();
        }
    }
}


