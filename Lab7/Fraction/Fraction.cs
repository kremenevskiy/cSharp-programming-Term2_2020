using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Schema;


namespace Fraction
{
    public class Fraction : IComparable<Fraction>, IEquatable<Fraction>,
        IFormattable, IConvertible, ICloneable
    {
        private long numerator;            
        private long denominator;

        public long Numerator
        {
            get => numerator;
            private set => numerator = value;
        }        

        public long Denominator
        {
            get => denominator;
            private set
            {
                if (value == 0)
                    throw new ArgumentException("Argument couldn't be equal to zero !");
                else if (value < 0)
                {
                    Numerator = -Numerator;
                    denominator = -value;
                }
                else
                {
                    denominator = value;
                }
            }
        }

        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        public Fraction(long number) : this()
        {
            Numerator = number;
        }

        public Fraction(long numerator, long denominator) : this(numerator)
        {
            Denominator = denominator;
            Simplify();
        }

        public Fraction(long numerator, long denominator, params long[] list) : this(numerator, denominator)
        {
        }

        public Fraction(double value)
        {
            Fraction fraction = value;
            Numerator = fraction.Numerator;
            Denominator = fraction.Denominator;
        }
        

        // Finding Greatest Common Divisor
        public static long GCD(long a, long b)
        {
            //return (b != 0) ? GCD(b, a % b) : a;
            while (b != 0)
            {
                return GCD(b, a % b);
            }

            return a;
        }

        // Finding List Common Multiple
        public static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        public void Simplify()
        {
            long gcd = GCD(Numerator, Denominator);

            Numerator /= gcd;
            Denominator /= gcd;
        }

        // Taking the whole part
        public long Truncate()
        {
            return Numerator / Denominator;
        }

        
        public static implicit operator Fraction(sbyte a) => new Fraction(a);
        public static implicit operator Fraction(short a) => new Fraction(a);
        public static implicit operator Fraction(int a) => new Fraction(a);
        public static implicit operator Fraction(long a) => new Fraction(a);

        public static implicit operator Fraction(byte a) => new Fraction(a);
        public static implicit operator Fraction(ushort a) => new Fraction(a);
        public static implicit operator Fraction(uint a) => new Fraction(a);

        public static implicit operator Fraction(ulong a)
        {
            long b = (long) a;
            return new Fraction(b);
        }
        
        public static implicit operator Fraction(float a)
        {
            if (TryParse(a.ToString(), out Fraction fraction));
            return fraction;
        }

        public static implicit operator Fraction(double a)
        {
            if (TryParse(a.ToString(), out Fraction fraction));
            return fraction;
        }
        
        public static implicit operator Fraction(decimal a)
        {
            if (TryParse(a.ToString(), out Fraction fraction));
            return fraction;
        }


        public static explicit operator sbyte(Fraction a) => (sbyte) (a.Numerator / a.Denominator);
        public static explicit operator short(Fraction a) => (short) (a.Numerator / a.Denominator);
        public static explicit operator int(Fraction a) => (int) (a.Numerator / a.Denominator);
        public static explicit operator long(Fraction a) => a.Numerator / a.Denominator;
        
        public static explicit operator float(Fraction a) => (float)a.Numerator / a.Denominator;
        public static explicit operator double(Fraction a) => (double)a.Numerator / a.Denominator;
        public static explicit operator decimal(Fraction a) => (decimal) a.Numerator / a.Denominator;
        

        public static explicit operator byte(Fraction a)
        {
            byte temp;
            checked
            {
                temp = (byte) (a.Numerator / a.Denominator);
            }
            
            return temp;
        }

        public static explicit operator ushort(Fraction a)
        {
            ushort temp;
            checked
            {
                temp = (ushort) (a.Numerator / a.Denominator);
            }

            return temp;
        }

        public static explicit operator uint(Fraction a)
        {
            uint temp;
            checked
            {
                temp = (uint) (a.Numerator / a.Denominator);
            }

            return temp;
        }

        public static explicit operator ulong(Fraction a)
        {
            ulong temp;
            checked
            {
                temp = (ulong) (a.Numerator / a.Denominator);
            }

            return temp;
        }
        

        public override bool Equals(object ? obj)
        {

            return obj is Fraction fraction && this.CompareTo(fraction) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        
        public int CompareTo(Fraction other)
        {
            long lcm = LCM(this.Denominator, other.Denominator);

            long num1 = this.Numerator * (lcm / this.Denominator);
            long num2 = other.Numerator * (lcm / other.Denominator);

            if (num1 > num2)
                return 1;
            if (num1 < num2)
                return -1;
            return 0;
        }


        public object Clone()
        {
            return (Fraction) this.MemberwiseClone();
        }


        public bool Equals(Fraction other)
            => this.Numerator == other.Numerator && this.Denominator == other.Denominator;


        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);


        public static Fraction operator +(Fraction a, Fraction b)
        {
            long num, denom;
            checked
            {
                num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                denom = a.Denominator * b.Denominator;
            }

            return new Fraction(num, denom);
        }

        public static Fraction operator +(Fraction a, int b) => a + (Fraction) b;
        public static Fraction operator +(int a, Fraction b) => b + a;


        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, int b) => a + (-b);
        public static Fraction operator -(int a, Fraction b) => a + (-b);


        public static Fraction operator ++(Fraction a) => a + 1;
        public static Fraction operator --(Fraction a) => a - 1;


        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator *(Fraction a, int b) => a * (Fraction) b;

        public static Fraction operator *(int a, Fraction b) => b * a;


        public Fraction FlipOver() => new Fraction(Denominator, Numerator);


        public static Fraction operator /(Fraction a, Fraction b) => a * b.FlipOver();

        public static Fraction operator /(Fraction a, int b)
        {
            Fraction temp = b;
            return a * temp.FlipOver();
        }

        public static Fraction operator /(int a, Fraction b)
        {
            Fraction temp = a;
            return temp * b.FlipOver();
        }


        public static Fraction operator %(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Division occurs when calling the remainder operation." +
                                                " Can't divide by zero!");
            else
                return a - (a / b).Truncate() * b;
        }


        public static bool operator >(Fraction a, Fraction b) => a.CompareTo(b) == 1; 
        public static bool operator >=(Fraction a, Fraction b) => a.CompareTo(b) != -1;

        public static bool operator <(Fraction a, Fraction b) => a.CompareTo(b) == -1;
        public static bool operator <=(Fraction a, Fraction b) => a.CompareTo(b) != 1;


        public static bool operator ==(Fraction a, Fraction b) => a.CompareTo(b) == 0;

        public static bool operator !=(Fraction a, Fraction b) => a.CompareTo(b) != 0;

        public static bool operator true(Fraction a) => a.Numerator != 0;
        public static bool operator false(Fraction a) => a.Numerator == 0;

        public static Fraction Pow(Fraction num, int exponent) => Math.Pow((double) num, exponent);

        public override string ToString()
        {
            return this.ToString("A");
        }

        public string ToString(string format) => ToString(format, null);
        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            string mes = "";
            
            if (string.IsNullOrEmpty(format))
                format = "A";
            switch (format.ToUpperInvariant())
            {
                case "A":
                    if (Denominator == 1)
                        return Numerator.ToString();
                    return $"{Numerator.ToString()}/{Denominator.ToString()}";
                case "NUM":
                    return Numerator.ToString();
                case "DENUM":
                    return Denominator.ToString();
                case "FLOAT":
                    return ((float) this).ToString();
                case "INT":
                    return ((long) this).ToString();
                case "FULL":
                    int hashCode = this.GetHashCode();
                    string str = $"Type: Fraction | Value: {Numerator.ToString()}/{Denominator.ToString()}" +
                                 $" | Double: {((float)this).ToString()} | HashCode: {hashCode.ToString()}\n";
                    return str;
                default:
                    string message = $"{format}' is an invalid format string." +
                                     " Try: A, FLOAT, INT, NUM, DENUM ";
                    throw new FormatException(message);
            }
        }

        public static bool TryParse(string str, out Fraction fraction)
        {
            fraction = null;
            // From long
            Regex pattern1 = new Regex(@"^\s*?([+-]?\d{1,15}\s*?$)");
            // From Fraction like: 23 / 1222
            Regex pattern2 = new Regex(@"^\s*?([+-]?\d{1,15})\s*?/\s*?([+-]?\d{1,15})\s*?$");
            // From double
            Regex pattern3 = new Regex(@"^\s*?([+-]?\d{1,20})[,.](\d{1,20})\s*?$");
            
            Regex badPattern1 = new Regex(@"^\s*?([+-]?\d{16,}\s*?$)");
            Regex badPattern2 = new Regex(@"^\s*?([+-]?\d{16,})\s*?/\s*?([+-]?\d{16,})\s*?$");
            Regex badPattern3 = new Regex(@"^\s*?([+-]\d{21,})[,.](\d{21,})\s*?$");


            if (pattern1.IsMatch(str))
            {
                Match match = pattern1.Match(str);
                long number = Int64.Parse(match.Groups[1].Value);
                fraction = new Fraction(number);
                return true;
            }
            else if(pattern2.IsMatch(str))
            {
                Match match = pattern2.Match(str);
                long numenator = Int64.Parse(match.Groups[1].Value);
                long denumerator = Int64.Parse(match.Groups[2].Value);
                fraction = new Fraction(numenator, denumerator);
                return true;
            }
            else if (pattern3.IsMatch(str))
            {
                Match match = pattern3.Match(str);

                string doubleInput = match.Value;
                int indComma = str.IndexOf(',');
                if (indComma > 0)
                    doubleInput = doubleInput.Replace(',', '.');
                
                string fractionalPart = double.Parse(match.Groups[2].Value).ToString();
                double doubleNum = double.Parse(doubleInput); 

                long tensDegree = (long) Math.Pow(10, fractionalPart.Length);
                doubleNum *= tensDegree;
                long newNum = (long) doubleNum;

                fraction = new Fraction(newNum, tensDegree);
                return true;
            }
            else if(badPattern3.IsMatch(str))
                throw new ArithmeticException("Can't convert from number with more than 20 digits");
            else if(badPattern2.IsMatch(str) || badPattern1.IsMatch(str))
                throw new ArithmeticException("Can't convert from number more then long type");
            else
            {
                return false;
            }
        }

        
        public bool ToBoolean(IFormatProvider? provider)
        {
            if (Numerator != 0 && Denominator != 0)
                return true;
            return false;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        double GetDoubleValue() => (double) this;
        
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(GetDoubleValue());
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(GetDoubleValue());
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(GetDoubleValue());
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(GetDoubleValue());
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return GetDoubleValue();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDoubleValue());
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDoubleValue());
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDoubleValue());
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDoubleValue());
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDoubleValue());
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return String.Format("({0}, {1})", Numerator.ToString(), Denominator.ToString());
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDoubleValue(),conversionType);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDoubleValue());
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDoubleValue());
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDoubleValue());
        }
    }
}