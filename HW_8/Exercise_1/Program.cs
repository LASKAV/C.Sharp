namespace Exercise_1;

/*
 
                        Задание 1
Создайте структуру «Трёхмерный вектор». Определите внутри неё
необходимые поля и методы. Реализуйте следующую функциональность:
■ Умножение вектора на число;
■ Сложение векторов;
■ Вычитание векторов.
 */

struct Three_vector
{
    public float x;
    public float y;
    public float z;

    public Three_vector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Three_vector Multiply(float num)
    {
        return new Three_vector(x * num, y * num, z * num);
    }
    public Three_vector Addition(Three_vector temp)
    {
        float x = this.x + temp.x;
        float y = this.y + temp.y;
        float z = this.z + temp.z;

        return new Three_vector(x, y, z);
    }
    public Three_vector Subtraction(Three_vector temp)
    {
        float x = this.x - temp.x;
        float y = this.y - temp.y;
        float z = this.z - temp.z;

        return new Three_vector(x, y, z);
    }
    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }

}

class Program
{
    static void Main(string[] args)
    {
        Three_vector _vector = new Three_vector(2, 5, 7);
        Console.WriteLine($"Multiply = {_vector.Multiply(6)}");
        Three_vector three_Vector = new Three_vector(3, 4, 6);
        Console.WriteLine($"Addition = {_vector.Addition(three_Vector)}");
        Console.WriteLine($"Subtraction = {_vector.Subtraction(three_Vector)}");

        Console.Read();
    }
}

