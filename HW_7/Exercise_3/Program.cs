namespace Exercise_3;

/*
                        Задание 3
Создайте интерфейс ICalc2. В нём должно быть два метода:
■ int CountDistinct() — возвращает количество уникальных значений в контейнере данных;
■ int EqualToValue(int valueToCompare) — возвращает количество значений равных valueToCompare.
Класс, созданный ранее в практическом задании Array, должен имплементировать интерфейс ICalc2.
Метод CountDistinct — возвращает количество уникальных значений в массиве.
Метод EqualToValue — возвращает количество элементов массива равных valueToCompare.
Напишите код для тестирования полученной функциональности.
 */

class Program
{
    static void Main(string[] args)
    {
        Array _array = new Array();
        ICalc2 calc2 = _array;
        Console.WriteLine(calc2.CountDistinct());
        Console.WriteLine(calc2.EqualToValue(5));
        Console.Read();
    }
}
interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int valueToCompare);
}
interface IOutput2
{
    void ShowEven();
    void ShowOdd();
}
interface IOutput
{
    void Show();
    void Show(string info);
}
interface ICalc
{
    int Less(int valueToCompare);
    int Greater(int valueToCompare);
}
class Array : ICalc, IOutput, IOutput2, ICalc2
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
    public void ShowEven()
    {
        Console.Write("ShowEven: ");
        foreach (int item in _arr)
        {
            if ((item % 2) == 0)
            {

                Console.Write($"{item}" + " ");
            }
        }
    }
    public void ShowOdd()
    {
        Console.Write("\nShowOdd: ");
        foreach (int item in _arr)
        {
            if ((item % 2) != 0)
            {
                Console.Write($"{item}" + " ");
            }
        }
    }
    public int CountDistinct()
    {
        Console.Write("CountDistinct: ");
        int rezalt = 0;
        int[] _arrTwo = new int[_arr.Length];

        for (int i = 0; i < _arr.Length; i++)
        {
            bool Flag = true;

            for (int j = 0; j < rezalt; j++)
            {
                if (_arr[i] == _arrTwo[j])
                {
                    Flag = false;
                    break;
                }
            }

            if (Flag)
            {
                _arrTwo[rezalt] = _arr[i];
                rezalt++;
            }
        }
        foreach (var item in _arrTwo)
        {
            if (item != 0)
            Console.Write(item + " ");
        }
        return rezalt;
    }
    public int EqualToValue(int valueToCompare)
    {

        Console.Write("EqualToValue: ");

        foreach (int item in _arr)
        {
            if (item == valueToCompare)
            {

                Console.Write($"{item}" + " ");
                valueToCompare++;
            }
        }
        return valueToCompare;
    }
}

