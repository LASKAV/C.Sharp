using System.Net;
using System.Numerics;
using System.Xml.Linq;
using NLog.Fluent;
using NLog;
using NLog.Targets;
using System.Diagnostics;
using NLog.Conditions;

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
            User user1 = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Phone = "123-456-7890",
                Email = "john.doe@example.com",
                Address = "123 Main Street"
            };

            User user2 = new User
            {
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "987-654-3210",
                Email = "jane.smith@example.com",
                Address = "456 Elm Street"
            };

            User user3 = new User
            {
                FirstName = "Bob",
                LastName = "Johnson",
                Phone = "555-123-4567",
                Email = "bob.johnson@example.com",
                Address = "789 Oak Avenue"
            };

            List<User> fakeUser = new List<User>();
            fakeUser.Add(user1);
            fakeUser.Add(user2);
            fakeUser.Add(user3);

            var config = new NLog.Config.LoggingConfiguration();

            //-------------------- Target Console ----------------------------------------

            var consoleTarget = new ColoredConsoleTarget()
            {
                Layout = @"${longdate}|${level:uppercase=true}|${logger}|${message}"
            };

            // Rules for mapping loggers to targets
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, consoleTarget);

            //-------------------- Target File ----------------------------------------
            // Apply config
            NLog.LogManager.Configuration = config;

            var Trace = new ConsoleRowHighlightingRule();
            Trace.Condition = ConditionParser.ParseExpression("level == LogLevel.Trace");
            Trace.ForegroundColor = ConsoleOutputColor.Yellow;
            consoleTarget.RowHighlightingRules.Add(Trace);
            var Debug = new ConsoleRowHighlightingRule();
            Debug.Condition = ConditionParser.ParseExpression("level == LogLevel.Debug");
            Debug.ForegroundColor = ConsoleOutputColor.DarkCyan;
            consoleTarget.RowHighlightingRules.Add(Debug);
            var Info = new ConsoleRowHighlightingRule();
            Info.Condition = ConditionParser.ParseExpression("level == LogLevel.Info");
            Info.ForegroundColor = ConsoleOutputColor.Green;
            consoleTarget.RowHighlightingRules.Add(Info);

            Logger.Info($"Старт генерации пользователей");

            for (int i = 0; i < 3; i++)
            {
                Logger.Debug($"Сгенерирован пользователь: @{fakeUser[i].FirstName}");
            }

            Logger.Info("Генерация фейковых пользователей завершена");

            Console.ReadLine();
        }

    }
}


