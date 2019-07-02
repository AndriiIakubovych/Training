using System;

namespace FractionOperations
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator) == Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return (!(a == b));
        }

        public override bool Equals(object obj)
        {
            Fraction a = obj as Fraction;
            return (Convert.ToDouble(numerator) / Convert.ToDouble(denominator) == Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator));
        }

        public override int GetHashCode()
        {
            return numerator ^ denominator;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator) > Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator) >= Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator) < Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return (Convert.ToDouble(a.numerator) / Convert.ToDouble(a.denominator) <= Convert.ToDouble(b.numerator) / Convert.ToDouble(b.denominator));
        }

        public static implicit operator Fraction(double a)
        {
            int decimalPart = 1;
            for (int i = 0; i < (a - Math.Floor(a)).ToString().Length - 2; i++)
                decimalPart *= 10;
            return (new Fraction(Convert.ToInt32(a * decimalPart), decimalPart));
        }

        public static bool operator true(Fraction a)
        {
            return (a.numerator < a.denominator);
        }

        public static bool operator false(Fraction a)
        {
            return (a.numerator >= a.denominator);
        }

        public override string ToString()
        {
            if (numerator < denominator)
            {
                for (double i = numerator; i > 1; i--)
                    if (numerator / i == Convert.ToInt32(numerator / i) && denominator / i == Convert.ToInt32(denominator / i))
                    {
                        numerator /= Convert.ToInt32(i);
                        denominator /= Convert.ToInt32(i);
                        break;
                    }
            }
            else
                for (double i = denominator; i > 1; i--)
                    if (numerator / i == Convert.ToInt32(numerator / i) && denominator / i == Convert.ToInt32(denominator / i))
                    {
                        numerator /= Convert.ToInt32(i);
                        denominator /= Convert.ToInt32(i);
                        break;
                    }
            return string.Format(numerator + " / " + denominator);
        }
    }
}