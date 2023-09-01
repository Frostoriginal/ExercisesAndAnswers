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


            // ExercisesAndAnswers._6Kyu.Kata.UniqueInOrder("AAAABBBCCDAABBB");

            // ExercisesAndAnswers._6Kyu.Kata.UniqueInOrder(new int[] { 1, 2, 2, 3, 3 });
            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.Extract(new int[] {1,2,3}));

            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.Extract(new int[] { -10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20,22,23,25 }));

            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 }));

            //   Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.sumStrings("00103", "08567"));




            //Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(80402, 0.4657497334675821));

            // ExercisesAndAnswers._4Kyu.Kata.solve(123456789);



            ///Block sequences brute force
            ///   new Regex(@"^([:|;])([-|~)])?([\)|D])$");       

            /*
            //  string currString = "";

            string currNumber = "";
            long currLength = 0;
            for (long i = 1; i < 30; i++)
            {
                currNumber += i.ToString();
                long currStep = currNumber.ToString().Length;
                currLength += currStep;
               // currString += currNumber;
                Console.WriteLine($"current n: {currLength} current step: {currStep} current i {i}");

            }

            if(currLength>1000000000000000000) Console.WriteLine("maxed out");
            */

            // Console.WriteLine(ExercisesAndAnswers._4Kyu.Kata.solve(123456789));

            //          await ExercisesAndAnswers._6Kyu.Kata.WikidataScraper("https://www.wikidata.org/wiki/Special:EntityData/Q42.json");

           string photo = "======pe====nnnnnn=======================n=n=ng====u==iiii=iii==nn========================n=";
            /*
            Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));

            photo = "==========h===yyyyyy===eeee=n==a========";
            Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));

            photo = "=====r=rrr=rra=====eee======bb====b=======";
            Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));
            */
            photo = "===b=b==========a=a=a=a=a=a=a=boo======n=====";
            Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));
            
           // photo = "=====tt=tww=w==en===n=n=n========X===\r\n======y==y==l=ll===l==f==ff=r===rr==r==e==e===e==t===tt=t=t==u==uub========X===\r\n=======w=a=a==a==l===l==l==ll===l==laa=bb=y=====";
          //  Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));
            
            photo = "=====";
           // Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));
            
            photo = "==============\r\n===       ===snake=========";
          //  Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));
            
          //  photo = "===b=b==========a=a=a=a=a=a=a=boo======n=====\r\n====l===e===r=======riuqs=====\r\n=====k====r=a=vvvv==d=d=d=d=r==a=a=======\r\n====rraabbiitt==";
          //  Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));

          //  photo = "==a======a=a=a=lig===a=t====o=r=r=r=r==";
            //Console.WriteLine(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo));

            /*
            string unflatten = new string(bear.Replace('=', ' ').Replace(" ", "").Distinct().ToArray());
            Console.WriteLine(bear);
            Console.WriteLine(unflatten);
            var animals ="x";

            string reversed = new string(unflatten.Reverse().ToArray());
            Console.WriteLine(reversed);
            */
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