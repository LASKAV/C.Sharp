using System;
using System.IO;
using System.Linq;
using NLog;

namespace Exercise_1;

/*
                            Задание 1:
Создайте приложение для поиска информации в файле по текстовому шаблону.
Варианты поддерживаемых шаблонов:

 Отобразить все предложения, содержащие хотя бы одну маленькую, английскую букву
 Отобразить все предложения, содержащие хотя бы одну цифру
 Отобразить все предложения, содержащие хотя бы одну большую, английскою букву

В программе настройте логирование с использованием NLog.

 */

class Program
{
    public static Logger Logger = LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
        string file = "Text.txt";

        string[] lines = File.ReadAllLines(file);

        // Поиск предложений, содержащих хотя бы одну маленькую, английскую букву
        string[] lowercaseSentences = lines.
            Where(line => line.Any(char.IsLower)).ToArray();
        LogSentences(lowercaseSentences,
            "предложения, содержащие хотя бы одну маленькую, английскую букву:");


        // Поиск предложений, содержащих хотя бы одну цифру
        string[] numericSentences = lines.
            Where(line => line.Any(char.IsDigit)).ToArray();
        LogSentences(numericSentences,
            "предложения, содержащие хотя бы одну цифру:");


        // Поиск предложений, содержащих хотя бы одну большую, английскую букву
        string[] uppercaseSentences = lines.
                Where(line => line.Any(char.IsUpper)).ToArray();
            LogSentences(uppercaseSentences,
                "предложения, содержащие хотя бы одну большую, английскую букву:");
        Console.Read();
    }
    static void LogSentences(string[] sentences, string message)
    {
       
        if (sentences.Length == 0)
        {
            Logger.Info("Не найдено " + message);
            Console.WriteLine("Не найдено " + message);

            return;
        }

        Logger.Info("Найдено " + sentences.Length + " " + message);
        Console.WriteLine("Найдено " + sentences.Length + " " + message);
        for (int i = 0; i < sentences.Length; i++)
        {
            Logger.Info("Предложение " + (i + 1) + ": " + sentences[i]);
            Console.WriteLine("Предложение " + (i + 1) + ": " + sentences[i]);
        }
    }
}

