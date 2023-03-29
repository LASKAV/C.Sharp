namespace Exercise_2;

/*
                        Задание 2
Создайте интерфейс IOutput2. В нём должно быть два метода:
■ void ShowEven() — отображает четные значения из контейнера с данными;
■ void ShowOdd() — отображает нечетные значения из контейнера с данными.
Класс, созданный ранее в практическом задании Array, должен имплементировать интерфейс IOutput2.
Метод ShowEven — отображает четные значения из массива.
Метод ShowOdd — отображает нечетные значения из массива.
Напишите код для тестирования полученной функциональности.
 */

class Program
{
    static void Main(string[] args)
    {
        Array _array = new Array();
        IOutput2 output2 = _array;
        output2.ShowEven();
        output2.ShowOdd();
        Console.Read();
    }
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
class Array : ICalc, IOutput , IOutput2
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
            if((item % 2) == 0)
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
}