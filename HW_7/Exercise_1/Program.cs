namespace Exercise_1;

/*
                                Задание 1
Создайте интерфейс ICalc. В нём должно быть два метода:
■ intLess(int valueToCompare) — возвращает количество значений меньших, чем valueToCompare;
■ intGreater(int valueToCompare) — возвращает количество значений больших, чем valueToCompare.
Класс, созданный ранее в практическом задании Array, должен имплементировать интерфейс ICalc.
Метод Less — возвращает количество элементов массива меньших, чем valueToCompare.
Метод Greater — возвращает количество элементов массива больших, чем valueToCompare.
Напишите код для тестирования полученной функциональности.
 */

class Program
{
    static void Main(string[] args)
    {
        Array _array = new Array();
        _array.Show();
       //Console.WriteLine("\nvalueToCompare > Array: " + _array.Less(5));
       //Console.WriteLine("\nvalueToCompare < Array: " + _array.Greater(5));
        ICalc calc = _array;
        Console.WriteLine("\nvalueToCompare > Array: " + calc.Less(5));
        Console.WriteLine("\nvalueToCompare < Array: " + calc.Greater(5));
        Console.Read();
    }
}
interface ICalc
{
    int Less(int valueToCompare);
    int Greater(int valueToCompare);
}
class Array : ICalc
{
    int[] _arr;
    public Array()
    {
        _arr = new int[9];
        Random random = new Random();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] = random.Next(0, 10);
        }
    }
    public void Show()
    {
        Console.Write("Array: ");
        foreach (int item in _arr)
        {
            Console.Write($"{item}" + " ");
        }
    }
    public void Show(string info)
    {
        foreach (int item in _arr)
        {
            Console.Write($"{info} {item}" + " ");
        }
    }
    public int Less(int valueToCompare)
    {
        int rezalt = 0;
        Console.Write("\nArray Less: ");
        for (int i = 0; i < _arr.Length; i++)
        {
            if (valueToCompare > _arr[i])
            {
                rezalt++;
                Console.Write($"{rezalt}: {_arr[i]}" + " ");
            }
        }
        return rezalt;
    }
    public int Greater(int valueToCompare)
    {
        int rezalt = 0;
        Console.Write("Array Greater: ");
        for (int i = 0; i < _arr.Length; i++)
        {
            if (valueToCompare < _arr[i])
            {
                rezalt++;
                Console.Write($"{rezalt}: {_arr[i]}" + " ");
            }
        }
        return rezalt;
    }
}
