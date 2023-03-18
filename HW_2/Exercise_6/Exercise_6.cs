namespace Exercise_6;
/*
                    Задание 6
Пользователь с клавиатуры вводит некоторый текст.
Приложение должно изменять регистр первой буквы
каждого предложения на букву в верхнем регистре.
Например, если пользователь ввёл:
«today is a good day for walking. i will try to walk near the sea».
Результат работы приложения:
«Today is a good day for walking. I will try to walk near the sea».
 */
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите текст :");
        string _txt = Console.ReadLine();
        string[] sentences = _txt.Split('.');   //Разбиваем текст 
        string output = "";  // Создаем новый текст

        foreach (string intem in sentences)
        {
            if (!string.IsNullOrEmpty(intem))    // IsNullOrEmpty - 
                                                 // не является ли текущее
                                                 // предложение пустой строкой
            {
                string sentence_With_Upper = intem.TrimStart() ==
                    "" ? "" : char.ToUpper(intem.TrimStart()[0])
                    + intem.TrimStart().Substring(1); // вносим изменения 

                output += sentence_With_Upper + ".";
            }
        }
        Console.WriteLine(output);

        Console.Read();
    }
}

