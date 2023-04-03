namespace Exercise_2;

/*
            Задание 2
Создайте структуру «Десятичное число».
Определите внутри неё необходимые поля и методы.
Реализуйте следующую функциональность:
■ Перевод числа в двоичную систему;
■ Перевод числа в восьмеричную систему;
■ Перевод числа в шестнадцатеричную систему.
 */
struct DecimalNumber
{
    decimal decimalValue;

    public DecimalNumber(decimal value)
    {
        decimalValue = value;
    }

    public string ToBinary()
    {
        return Convert.ToString((long)decimalValue, 2);
    }

    public string ToOctal()
    {
        return Convert.ToString((long)decimalValue, 8);
    }

    public string ToHex()
    {
        return ((UInt64)decimalValue).ToString("X");
    }


}

class Program
{
    static void Main(string[] args)
    {
        DecimalNumber number = new DecimalNumber(42);
        Console.WriteLine(number.ToBinary());  
        Console.WriteLine(number.ToOctal());   
        Console.WriteLine(number.ToHex());
        Console.Read();
    }
}

