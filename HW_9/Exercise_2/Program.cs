using System;
using System.Reflection.Metadata.Ecma335;

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

    public static Action<string> ShowTime = (Time)
        => Console.WriteLine
        ($"Time: {DateTime.Now.ToString(Time)}");

    public static Func<double, double, double, double>
        ShowTriangleArea = TriangleArea;

    public static Func<double, double, double>
        ShowRectangleArea = RectangleArea;

    static void Main(string[] args)
    {
        // отображения текущего времени
        ShowTime("hh:mm:ss");
        // отображения текущей даты
        ShowTime("dd.MM.yy");
        // отображения текущего дня недели
        ShowTime("dddd");
        // подсчёта площади треугольника
        Console.WriteLine($"Подсчёт площади треугольника: {ShowTriangleArea(5, 5, 5)}");
        // подсчёта площади прямоугольника
        Console.WriteLine($"Подсчёт площади прямоугольника: {ShowRectangleArea(5, 5)}");

        Console.Read();
    }

    public static double TriangleArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2; 
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return area;
    }
    public static double RectangleArea(double length, double width)
    {
        return length * width;
    }

}

