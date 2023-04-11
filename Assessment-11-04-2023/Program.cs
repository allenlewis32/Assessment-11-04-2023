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