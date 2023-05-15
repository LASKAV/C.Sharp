using System.Net;
using System.Numerics;
using System.Xml.Linq;
using NLog.Fluent;
using NLog;
using NLog.Targets;
using System.Diagnostics;
using NLog.Conditions;




/*
                            Задание 1:
Создайте приложение для поиска информации в файле по текстовому шаблону.
Варианты поддерживаемых шаблонов:
 Отобразить все предложения, содержащие хотя бы одну маленькую, английскую букву
 Отобразить все предложения, содержащие хотя бы одну цифру
 Отобразить все предложения, содержащие хотя бы одну большую, английскою букву
В программе настройте логирование с использованием NLog.

 */

namespace Exercise_1
{

    class Program
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
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

            #region NLog Colors

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
            var Warn = new ConsoleRowHighlightingRule();
            Warn.Condition = ConditionParser.ParseExpression("level == LogLevel.Warn");
            Warn.ForegroundColor = ConsoleOutputColor.DarkYellow;
            consoleTarget.RowHighlightingRules.Add(Warn);
            var Error = new ConsoleRowHighlightingRule();
            Error.Condition = ConditionParser.ParseExpression("level == LogLevel.Error");
            Error.ForegroundColor = ConsoleOutputColor.DarkRed;
            consoleTarget.RowHighlightingRules.Add(Error);
            var Fatal = new ConsoleRowHighlightingRule();
            Fatal.Condition = ConditionParser.ParseExpression("level == LogLevel.Fatal");
            Fatal.ForegroundColor = ConsoleOutputColor.Black;
            Fatal.BackgroundColor = ConsoleOutputColor.DarkRed;
            consoleTarget.RowHighlightingRules.Add(Fatal);

            #endregion NLog Colors

            string nameFile = "Mytxt.txt";
            string myText = "THE 123.ААА a";

            RecordFile(myText, nameFile);
            DataFiltering(nameFile);

            Console.ReadLine();
        }
        static void DataFiltering(string nameFile)
        {
            try
            {
                Logger.Info("Начало фильтрации");
                Logger.Info($"{nameFile} открыт");

                string content = File.ReadAllText(nameFile);
                string[] sentences = content.Split('.');

                Console.WriteLine("Отобразить все предложения, содержащие хотя бы одну маленькую, английскую букву");
                foreach (string sentence in sentences)
                {
                    if (sentence.Any(char.IsLower))
                    {
                        Console.WriteLine(sentence);
                    }
                }

                Console.WriteLine("Отобразить все предложения, содержащие хотя бы одну цифру");
                foreach (string sentence in sentences)
                {
                    if (sentence.Any(char.IsDigit))
                    {
                        Console.WriteLine(sentence);
                    }
                }

                Console.WriteLine("Отобразить все предложения, содержащие хотя бы одну большую, английскую букву");
                foreach (string sentence in sentences)
                {
                    if (sentence.Any(char.IsUpper))
                    {
                        Console.WriteLine(sentence);
                    }
                }

                Logger.Info($"{nameFile} закрыт");
            }
            catch (FileNotFoundException)
            {
                Logger.Warn("Файл не найден");
            }
        }
        static void RecordFile(string myText, string nameFile)
        {
            try
            {
                Logger.Info($"{nameFile} открыт");

                using (StreamWriter fileWriter = new StreamWriter(nameFile))
                {
                    Logger.Info("Запись в файл");
                    fileWriter.Write(myText);
                }

                Logger.Info($"{nameFile} закрыт");
            }
            catch (FileNotFoundException)
            {
                Logger.Warn("Файл не найден");
            }
        }


    }
}
