using ExercisesAndAnswers._3Kyu;
using ExercisesAndAnswers.Codewars._5Kyu;
using ExercisesAndAnswers.Codewars._5Kyu.Car2;
using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ExercisesAndAnswers { 
internal class Program
{
        private static void Main(string[] args)
        {
            string a =
                    "..WWWWWWWWWWWWWWWWWW\n" +
                    "W.................WW\n" +
                    "W.WWWWWWWWWWWWWWW.WW\n" +
                    "W.WW..............WW\n" +
                    "W.WW.WWWWWWWWWWWWWWW\n" +
                    "W.WW.WWWWWWWWWWWWWWW\n" +
                    "W.WW.WWWWWWWWWWWWWWW\n" +
                    "W.WW................\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W.WWWWWWWWWWWWWWWWW.\n" +
                    "W...................";
            //MathWorks.mazeConvertor(a);
            string c = "......\n" +
                    "......\n" +
                    "......\n" +
                    "......\n" +
                    "......\n" +
                    "......";
            //Console.WriteLine(MathWorks.PathFinder2(a));
            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.PathFinder2(a));
            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.PathGraph(c));


            //Fibonacci memoization
            // Func<int, int> fibonacci = null;
            // fibonacci = Memoizer.Memoize((int n1) => Fibonacci(n1, fibonacci));
            //Console.WriteLine($"{fibonacci(10)}");
            //Console.WriteLine(IsValidWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }));
            string toOrder = "is2 Thi1s T4est 3a"; //-- > "Thi1s is2 3a T4est"
            string test = "3a";
            int.TryParse(test, out int u);
            int j = 0;
        }

     //   public static string OrderAll(string s) => string.Join(",", s.Split(" ").OrderBy(s.Select(x=>x)));
            

        public static string TheLongest(List<string> strings)
        {
            List<string> concatenated = new List<string>();
            for (int i = 0; i < strings.Count-1; i++)
            {
                concatenated.Add(string.Join("", strings[i], strings[i+1]));
            }

            foreach (var item in concatenated)
            {
                Console.WriteLine(item);
            }

            return concatenated.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        }

        int Fibonacci(int n1)
        {
            return Fibonacci(n1, Fibonacci);
        }

        static int Fibonacci(int n1, Func<int,int> fibonacci)
        {
            if (n1 <= 2) return 1;
            return fibonacci(n1 - 1) + fibonacci(n1 - 2);
        }

      






    }

}