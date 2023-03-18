namespace Exercise_7;
/*
                            Задание 7
Создайте приложение, проверяющее текст на недопустимые слова.
Если недопустимое слово найдено, оно должно быть заменено на
набор символов *. По итогам работы приложения необходимо
показать статистику действий.
Например, если и у нас есть такой текст:
Недопустимое слово: die.
Результат работы:
And by opposing end them? To ***: to sleep;
Статистика: 2 замены слова die.
 */
class Program
{
    static void Main(string[] args)
    {
        string _txt = "Привет плохой человек, как у тебя дела плохой человек?";
        Console.WriteLine("Text: " + _txt);
        string badWord = "плохой";
        string bed = "***";
        string replacedText = _txt.Replace(badWord, bed);
        short num_rez = 0;
        for (int i = 0; i < replacedText.Length - bed.Length + 1; i++)
        {
            if (replacedText.Substring(i, bed.Length) == bed)
            {
                num_rez++;
            }
        }
        Console.WriteLine($"\nРезультат работы: {replacedText}");
        Console.WriteLine($"\nСтатистика: {num_rez} замены слова \"{badWord}\".");
        Console.Read();
    }
}

