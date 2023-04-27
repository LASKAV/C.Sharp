using System;
namespace Exercise_1
{
    class Fraction
    {
        public int numerator { get; set; }
        public int denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }
    }
}

