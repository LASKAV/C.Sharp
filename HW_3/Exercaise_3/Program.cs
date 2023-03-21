namespace Exercaise_3;
/*                          Задание 3
Напишите метод, фильтрующий массив на основании переданных параметров.
Метод принимает параметры: оригинальный_массив, массив_с_данными_для_фильтрации.
Метод возвращает оригинальный массив без элементов,
которые есть вмассиве для фильтрации.
Например:
1 2 6 -1 88 7 6 — оригинальный массив; 6 88 7 — массив для фильтрации;
1 2 -1 — результат работы метода.
*/
class Program
{
    static void Main(string[] args)
    {
        int[] _arr = new int[9];
        int[] _arr_cop = new int[5] { 1, 2, 6, 7, 9 };
        Rand_arr(_arr);
        Console.Write("Оригинальный массив: ");
        show_arr(_arr);
        Console.Write("Массив для фильтрации: ");
        show_arr(_arr_cop);
        Console.Write("\n\n");
        int[] _arr_filter = Filtering(_arr, _arr_cop);
        Console.Write("Результат работы метода: ");
        show_arr(_arr_filter);
        
        Console.Read();
    }
    public static void Rand_arr(int[] _arr)
    {
        Random random = new Random();
        for (int i = 0; i < _arr.Length; i++)
        {
            _arr[i] += random.Next(1, 10);
        }
    }
    public static void show_arr(int[] _arr)
    {
        foreach (var item in _arr)
        {
            Console.Write($"{item}" + " ");
        }
    }
    public static int[] Filtering(int[] _arr , int[] _arr_cop)
    {
        Console.Write("\n\n");
        List<int> List_arr = new List<int>(_arr);

        foreach (int filter in _arr_cop)
        {
            List_arr.RemoveAll(item => item == filter);
        }
        return List_arr.ToArray();
    }
}

