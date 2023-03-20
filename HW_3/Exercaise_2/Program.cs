namespace Exercaise_2;
/*
                            Задание 2
Напишите метод, который проверяет является ли переданное число «палиндромом».
Число передаётся в качестве параметра. Если число палиндром нужно вернуть из
метода true, иначе false.
Палиндром — число, которое читается одинаково как справа налево, так и слева
направо. Например:
1221 — палиндром;
3443 — палиндром;
7854 — не палиндром.
 */
class Program
{
    static void Main(string[] args)
    {
        int num = 7854;
        if (Palindrome(num) == true)
        {
            Console.WriteLine("\nпалиндром!");
        }
        else
        {
            Console.WriteLine("\nне палиндром");
        }
        Console.Read();
    }

    public static bool Palindrome(int number)
    {
        string number_str = number.ToString(); // преобразуем число в строку
        int length = number_str.Length;

        for (int i = 0; i < length / 2; i++) 
        {
            if (number_str[i] != number_str[length - i - 1])
            {
                Console.Write(number_str[i] + " || "
                    + number_str[length - i - 1]);
                return false;
            }
        }

        return true; 
    }

}

