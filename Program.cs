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
			double b = 0;
			for (i = 0; i < n; i++) 
			{
				string seedSqrStr = Math.Pow (seed, 2).ToString ();
				if (seedSqrStr.Length - 1 == 2 * r) {
					Int32.TryParse (seedSqrStr.Substring (r - 1, r * 2), out seed);

				} else
				{
					if (seedSqrStr.Length - 1 < 2 * r)
						seedSqrStr = Math.Pow (int.Parse(seedSqrStr), 2).ToString ();
//						seed *= seed;
					Int32.TryParse (seedSqrStr.Substring (r, r * 2), out seed);
				}
				b = seed * Math.Pow (10, -2 * r);
				genStr += b.ToString() + " ";
			}

			Console.WriteLine (genStr);

		}
	}
}
