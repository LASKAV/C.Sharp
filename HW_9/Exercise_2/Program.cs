namespace Exercise_2;

/*
                        Задание 2
Создайте набор методов:
■ Метод для отображения текущего времени;
■ Метод для отображения текущей даты;
■ Метод для отображения текущего дня недели;
■ Метод для подсчёта площади треугольника;
■ Метод для подсчёта площади прямоугольника.
Для реализации проекта используйте делегаты Action, Predicate, Func.
 */

class Program
{
    static void Main(string[] args)
    {
        // отображения текущего времени
        Action ShowTime = () => Console.WriteLine($"Time: {DateTime.Now.ToString("hh:mm:ss")}");
        ShowTime();
        // отображения текущей даты
        Action ShowDate = () => Console.WriteLine($"Date: {DateTime.Now.ToString("dd.MM.yy")}");
        ShowDate();
        // отображения текущего дня недели
        Action ShowWeekDay = () => Console.WriteLine($"Week: {DateTime.Now.ToString("dddd")}");
        ShowWeekDay();

        Console.Read();
    }
}

