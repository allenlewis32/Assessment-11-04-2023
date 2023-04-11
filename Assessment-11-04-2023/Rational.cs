using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_11_04_2023
{
	public struct Rational
	{
		public readonly int numerator, denominator;
		public Rational(int numerator, int denominator)
		{
			if(denominator == 0)
			{
				throw new Exception("Denominator cannot be zero");
			}
			Reduce(ref numerator, ref denominator);

			// assign the values
			this.numerator = numerator;
			this.denominator = denominator;
		}
		public int Sign // Sign of the Rational
		{
			get
			{
				return numerator < 0?-1:numerator==0?0:1;
			}
		}

		// reduce to the lowest form
		private static void Reduce(ref int x, ref int y)
		{
			bool neg = (x < 0) ^ (y < 0);
			x = Math.Abs(x);
			y = Math.Abs(y);
			int gcd = GCD(x, y);
			x /= gcd;
			y /= gcd;
			if (neg)
			{
				x = -x;
			}
		}

		// Find GCD using Euclidean algorithm
		private static int GCD(int x, int y)
		{
			while (y != 0)
			{
				int t = x % y;
				x = y;
				y = t;
			}
			return x;
		}

		// returns the value of this Rational in fraction form
		public override string ToString()
		{
			return $"{numerator}/{denominator}";
		}
		public static Rational operator +(Rational x, Rational y)
		{
			return new Rational(x.numerator * y.denominator + y.numerator * x.denominator, x.denominator * y.denominator);
		}
		public static Rational operator -(Rational x, Rational y)
		{
			return new Rational(x.numerator * y.denominator - y.numerator * x.denominator, x.denominator * y.denominator);
		}
		public static Rational operator *(Rational x, Rational y)
		{
			return new Rational(x.numerator * y.numerator, x.denominator * y.denominator);
		}
		public static Rational operator /(Rational x, Rational y)
		{
			int numerator = x.numerator * y.denominator;
			int denominator = x.denominator * y.numerator;
			if (denominator == 0)
			{
				throw new DivideByZeroException("Cannot divide by zero");
			}
			return new Rational(numerator, denominator);
		}
		public static Rational operator -(Rational x)
		{
			return new Rational(-x.numerator, x.denominator);
		}
		public static bool operator ==(Rational x, Rational y)
		{
			return (x.numerator == y.numerator) && (x.denominator == y.denominator);
		}
		public static bool operator !=(Rational x, Rational y)
		{
			return (x.numerator != y.numerator) || (x.denominator != y.denominator);
		}
		public static bool operator >(Rational x, Rational y)
		{
			return ((decimal)x.numerator / x.denominator) > ((decimal)y.numerator / y.denominator);
		}
		public static bool operator <(Rational x, Rational y)
		{
			return ((decimal)x.numerator / x.denominator) < ((decimal)y.numerator / y.denominator);
		}
		public static bool operator >=(Rational x, Rational y)
		{
			return ((decimal)x.numerator / x.denominator) >= ((decimal)y.numerator / y.denominator);
		}
		public static bool operator <=(Rational x, Rational y)
		{
			return ((decimal)x.numerator / x.denominator) <= ((decimal)y.numerator / y.denominator);
		}
		public static implicit operator decimal(Rational x)
		{
			return (decimal)x.numerator / x.denominator;
		}
		public static explicit operator Rational(decimal x)
		{
			int denominator = 1;
			while(x % 1 != 0)
			{
				x *= 10;
				denominator *= 10;
			}
			int numerator = (int)x;
			return new Rational(numerator, denominator);
		}
	}
}
