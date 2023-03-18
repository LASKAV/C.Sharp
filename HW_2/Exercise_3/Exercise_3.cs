namespace Exercise_3;

/*
                        Задание 3
Пользователь вводит строку с клавиатуры. Необходимо
зашифровать данную строку используя шифр Цезаря. Из Википедии:
Шифр Цезаря — это вид шифра подстановки, в котором каждый символ
в открытом тексте заменяется символом, находящимся на некотором
постоянном числе позиций левее или правее него в алфавите.
Например, в шифре со сдвигом вправо на 3, A была бы
заменена на D, B станет E, и так далее.
Подробнее тут: https://en.wikipedia.org/wiki/Caesar_ cipher.
Кроме механизма шифровки, реализуйте механизм расшифрования.
 */

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("\tCaeser");
        Console.Write("\nText : ");
        Console.Write("Hello world");

        string txt = "Hello world";
        int shift = 3;

        Console.WriteLine("\nEncrypt: " + CaesarEncrypt(txt, shift));
        Console.WriteLine("Decrypt: " + CaesarDecrypt(txt, shift));
        Console.Read();
    }
    // Функция для зашифровки строки с помощью шифра Цезаря
    static string CaesarEncrypt(string input, int shift)
    {
        string result = "";

        foreach (char c in input)
        {
            // Проверяем, является ли символ буквой латинского алфавита
            if (char.IsLetter(c))
            {
                // Получаем номер символа в таблице ASCII
                int charCode = (int)c;
                int shiftAmount = shift % 26;
                // Если символ находится за пределами букв A-Z, то возвращаем его же
                if (charCode + shiftAmount > 90 && charCode <= 90 || charCode + shiftAmount > 122)
                {
                    charCode -= 26;
                }
                char shiftedChar = (char)(charCode + shiftAmount);
                result += shiftedChar;
            }
            else
            {
                // Если символ не является буквой латинского алфавита, то возвращаем его же
                result += c;
            }
        }

        return result;
    }
    // Функция для расшифровки строки, зашифрованной шифром Цезаря
    static string CaesarDecrypt(string input, int shift = 0)
    {
        return CaesarEncrypt(input, 3 - shift);
    }
}

