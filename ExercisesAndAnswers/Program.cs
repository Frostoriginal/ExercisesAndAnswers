﻿using ExercisesAndAnswers._3Kyu;
using ExercisesAndAnswers.Codewars._5Kyu;
using ExercisesAndAnswers.Codewars._5Kyu.Car2;
using System;
using System.Numerics;

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

            int[] abc = ExercisesAndAnswers._7Kyu.Kata.minMax(new int[] { 1, 2, 5, -1, 12, 20 });
            int bxc = 0;
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