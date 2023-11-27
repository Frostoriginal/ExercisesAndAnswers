using ExercisesAndAnswers._3Kyu;
using ExercisesAndAnswers.Codewars._5Kyu;
using ExercisesAndAnswers.Codewars._5Kyu.Car2;
using ExercisesAndAnswers.Codewars;
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ExercisesAndAnswers { 
public class Program
{
        public static void Main(string[] args)
        {
            //string a =
            //        "..WWWWWWWWWWWWWWWWWW\n" +
            //        "W.................WW\n" +
            //        "W.WWWWWWWWWWWWWWW.WW\n" +
            //        "W.WW..............WW\n" +
            //        "W.WW.WWWWWWWWWWWWWWW\n" +
            //        "W.WW.WWWWWWWWWWWWWWW\n" +
            //        "W.WW.WWWWWWWWWWWWWWW\n" +
            //        "W.WW................\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W.WWWWWWWWWWWWWWWWW.\n" +
            //        "W...................";
            ////MathWorks.mazeConvertor(a);
            //string c = "......\n" +
            //        "......\n" +
            //        "......\n" +
            //        "......\n" +
            //        "......\n" +
            //        "......";
            //Console.WriteLine(MathWorks.PathFinder2(a));
            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.PathFinder2(a));
            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.PathGraph(c));


            //Fibonacci memoization
            // Func<int, int> fibonacci = null;
            // fibonacci = Memoizer.Memoize((int n1) => Fibonacci(n1, fibonacci));
            //Console.WriteLine($"{fibonacci(10)}");

            //for (int i = 1; i < 10000; i++)
            //{
            //    if (ExercisesAndAnswers._4Kyu.Kata.solve(i) != ExercisesAndAnswers._4Kyu.Kata.solve2(i))
            //    {
            //        Console.WriteLine($"Problem number:{i}");
            //    }

            //}           


            //if (ExercisesAndAnswers._4Kyu.Kata.solve(x) == ExercisesAndAnswers._4Kyu.Kata.solve(x))
            //{
            //    Console.WriteLine(true);
            //}
            //else { Console.WriteLine(false); }

            long x = 999999999999999993;
            Console.WriteLine($"Answer: {ExercisesAndAnswers._4Kyu.Kata.solve(x)}");
            

            // Console.WriteLine($"BruteForce: {ExercisesAndAnswers._4Kyu.Kata.solve2(x)}");






            //List<int[]> rectangles = new();
            //rectangles.Add(new int[] { 3, 3, 8, 5 });
            //rectangles.Add(new int[] { 6, 3, 8, 9 });
            //rectangles.Add(new int[] { 11, 6, 14, 12 });

            //  Console.WriteLine(ExercisesAndAnswers.Codewars._3Kyu.RectangleUnion.TotalAreaWithLineAndDictionary(rectangles));
            //  Console.WriteLine(ExercisesAndAnswers.Codewars._3Kyu.RectangleUnion.RectangleArea(rectangles));





        }






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