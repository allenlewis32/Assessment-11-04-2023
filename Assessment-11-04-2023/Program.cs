namespace Assessment_11_04_2023
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(CheckParentheses("(())()()"));
			Console.WriteLine(CheckParentheses("(())()("));
			Console.WriteLine(CheckParentheses("(())()("));
			Console.WriteLine(CheckParentheses("(())())"));

			foreach (string str in GenerateParentheses(3))
			{
				Console.WriteLine(str);
			}

			Rational r = new(25, -75);
			Console.WriteLine(r);

			Rational r1 = new(1, 3);
			Rational r2 = new(2, 4);
			Console.WriteLine(r1 + r2);
			Console.WriteLine(r1 - r2);
			Console.WriteLine(r1 * r2);
			Console.WriteLine(r1 / r2);
			Console.WriteLine(-r1);
		}
		private static List<string> GenerateParentheses(int n)
		{
			List<string> result = new();
			char[] ch = new char[n * 2]; // since there are n pairs(n*2)
			GenerateParenthesesHelper(result, ch, 0, n, 0);
			return result;
		}
		private static void GenerateParenthesesHelper(List<string> result, char[] ch, int pos, int toOpen, int toClose)
		{
			if (toOpen == 0 && toClose == 0) // if no more brackets to add, add ch to result
			{
				result.Add(new(ch));
				return;
			}
			if(toOpen > 0) // if more pair needs to be opened, open it
			{
				ch[pos] = '(';
				GenerateParenthesesHelper(result, ch, pos + 1, toOpen - 1, toClose + 1);
			}
			if(toClose > 0) // if there are pairs that need to be closed, close it
			{
				ch[pos] = ')';
				GenerateParenthesesHelper(result, ch, pos + 1, toOpen, toClose - 1);
			}
		}
		private static bool CheckParentheses(string str)
		{
			Stack<char> stack = new();
			foreach (char c in str)
			{
				if (c == '(')
				{
					stack.Push(c);
				}
				else
				{
					if (stack.Count == 0 || stack.Pop() != '(')
					{
						return false;
					}
				}
			}
			return stack.Count == 0;
		}
	}
}