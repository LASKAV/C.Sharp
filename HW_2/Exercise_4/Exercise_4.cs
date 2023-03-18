namespace Exercise_4;

/*
                        Задание 4
Создайте приложение, которое производит операции над матрицами:
■ Умножение матрицы на число;
■ Сложение матриц;
■ Произведение матриц.
 */
class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\tMatrix");
        int[,] _arr = new int[4, 4];
        Set_arr(_arr);
        Get_arr(_arr);
        Console.ForegroundColor = ConsoleColor.Black;
        do
        {
            short ch = 0;
            Console.WriteLine
                ("\n1.Умножение матрицы на число" +
                 "\n2.Сложение матриц" +
                 "\n3.Произведение матриц" +
                 "\n4.Выход");
            Console.Write("\n Ведите число :");
            ch = short.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    Console.WriteLine("\nУмножение матрицы на число");
                    Console.Write("\nВведите число :");
                    int number = int.Parse(Console.ReadLine());
                    Matrix_multiplication(_arr, number);
                    break;
                case 2:
                    Console.WriteLine("\nСложение матриц");
                    Matrix_addition(_arr);
                    break;
                case 3:
                    Console.WriteLine("\nПроизведение матриц");
                    Matrix_product(_arr);
                    break;
                case 4:
                    Console.WriteLine("\nВыход");
                    Console.Read();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Error menu");
                    break;
            }
        } while (true);
        
    }
    static void Set_arr(int[,] _arr)
    {
        Random random = new Random();
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] += random.Next(1,10);
            }
        }
    }
    static void Get_arr(int[,] _arr)
    {
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            Console.Write("\n\t");
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                Console.Write(_arr[i, j] + " ");
            }
        }
        Console.WriteLine("");
    }
    static void Matrix_multiplication(int[,] _arr, int number)
    {
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] *= number;
            }
        }
        Get_arr(_arr);
    }
    static void Matrix_addition(int[,] _arr)
    {
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] += _arr[i, j];
            }
        }
        Get_arr(_arr);
    }
    static void Matrix_product(int[,] _arr)
    {
        for (int i = 0; i < _arr.GetLength(0); i++)
        {
            for (int j = 0; j < _arr.GetLength(1); j++)
            {
                _arr[i, j] *= _arr[i, j];
            }
        }
        Get_arr(_arr);
    }
}

