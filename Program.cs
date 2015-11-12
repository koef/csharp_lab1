using System;

namespace lab1
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Write ("Input r: ");
			int r = int.Parse (Console.ReadLine());
			if (r < 1) 
			{
				Console.WriteLine ("r must be greater than 0!");
				System.Environment.Exit (1);
			}

			Console.Write ("Input number ({0} digits): ", r*2);
			int seed = int.Parse (Console.ReadLine());

			Console.Write ("How many numbers do you need?: ");
			int n = int.Parse (Console.ReadLine());

			string genStr = "";

			int i;
			double b = 0; //псевдослучайное число текущей итерации
			int sum = seed; //дополнительная переменная (являющаяся суммой всех предыдущих сгенерированных чисел) для разбития повторяющейся последовательности
			int sumMidle = 0;
			for (i = 0; i < n; i++) {
				string seedSqrStr = Math.Pow (seed, 2).ToString ();
				string sumSqrStr = Math.Pow (sum, 2).ToString ();

				if (sumSqrStr.Length - 1 == 2 * r) {
					Int32.TryParse (sumSqrStr.Substring (r - 1, r * 2), out sumMidle);
				} else {
					if (sumSqrStr.Length == 2 * r)
						sumSqrStr = Math.Pow (int.Parse (sumSqrStr), 2).ToString ();
					Int32.TryParse (sumSqrStr.Substring (r, r * 2), out sumMidle);
				}


				if (seedSqrStr.Length - 1 == 2 * r) { //если квадрат цифры больше на один разряд
					Int32.TryParse (seedSqrStr.Substring (r - 1, r * 2), out seed);
				} else {
					if (seedSqrStr.Length == 2 * r) //если квадрат цифры равен разряду двойного r
													//в случае если в центре квадрата seed получена последовательность типа "05"
						seedSqrStr = Math.Pow (int.Parse(seedSqrStr), 2).ToString ();
					Int32.TryParse (seedSqrStr.Substring (r, r * 2), out seed);
				}
				sum += seed;
				b = (seed + sumMidle) / 2 * Math.Pow (10, -2 * r);
				genStr += b.ToString() + " ";
			}

			Console.WriteLine (genStr);

		}
	}
}
