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
			Reduce(ref numerator, ref denominator);

			// assign the values
			this.numerator = numerator;
			this.denominator = denominator;
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
			if(neg)
			{
				x = -x;
			}
		}

		// Find GCD using Euclidean algorithm
		private static int GCD(int x, int y)
		{
			while(y != 0)
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
			if(denominator == 0)
			{
				throw new DivideByZeroException("Cannot divide by zero");
			}
			return new Rational(numerator, denominator);
		}
		public static Rational operator -(Rational x)
		{
			return new Rational(-x.numerator, x.denominator);
		}
	}
}
