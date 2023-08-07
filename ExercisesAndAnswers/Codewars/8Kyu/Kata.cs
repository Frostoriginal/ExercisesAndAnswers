using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._8Kyu
{
    internal class Kata
    {
        public static int AddItems(int a, int b)
        {
            return a + b;
        }
        public static int AddItemsLambda(int a, int b) => a + b;

        //return string if number is even or odd
        //https://www.codewars.com/kata/53da3dbb4a5168369a0000fe
        public static string EvenOrOdd(int number) => number % 2 == 0 ? "true" : "false";

        //Write a function that will take the number of petals of each flower and return true if they are in love and false if they aren't
        //https://www.codewars.com/kata/555086d53eac039a2a000083
        public static bool OppositesAttract(int a, int b)
        {
            if (a % 2 == 0 && b % 2 != 0)
            {
                return true;
            }
            else if (b % 2 == 0 && a % 2 != 0)
            {
                return true;
            }
            else return false;

        }
        public static bool OppositesAttractLambda(int a, int b) => a % 2 == 0 && b % 2 != 0 || b % 2 == 0 && a % 2 != 0 ? true : false;


        //invert values
        //https://www.codewars.com/kata/5899dc03bc95b1bf1b0000ad
        // with iteration
        public static int[] InvertValues(int[] values)
        {
            foreach (var item in values)
            {
                Console.Write($"{item}, ");
            }

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i] * -1;
            }

            Console.WriteLine("Inverted: ");
            foreach (var item in values)
            {
                Console.Write($"{item}, ");
            }

            return values;
        }

        //with linq
        public static int[] InvertValuesWithLinq(int[] input)
        {
            return input.Select(n => -n).ToArray();
        }
        //with linq and lambda expression
        public static int[] InvertValuesWithLinqLambda(int[] input) => input.Select(n => -n).ToArray();


        //Convert number to reversed array of digits
        //https://www.codewars.com/kata/5583090cbe83f4fd8c000051
        public static long[] ConvertToReversedArray(long n)
        {
            Console.WriteLine(n);
            long[] result = n.ToString().ToCharArray().Select(x => (long)Char.GetNumericValue(x)).ToArray();

            Array.Reverse(result);
            foreach (var item in result)
            {
                Console.Write(item);
            }
            return result;
        }

        // multiply the array elements
        public static int MultiplyTheArray(int[] x)
        {
            int result = x[0];
            for (int i = 1; i < x.Length; i++)
            {
                result *= x[i];
            }
            return result;
        }

        // Summ arrays
        //https://www.codewars.com/kata/53dc54212259ed3d4f00071c
        //with iteration
        public static double SumTheArray(double[] array)
        {
            if (array.Length == 0) return 0;

            double result = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }

        // with linq and delta statement
        public static double SumArray(double[] array) => array.Sum();

        //Create a function with two arguments that will return an array of the first n multiples of x. 
        //https://www.codewars.com/kata/5513795bd3fafb56c200049e
        public static int[] CountByX(int n, int x)
        {
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                int m = i + 1;
                array[i] = x * m;
            }

            return array;
        }
        // Find average of numbers given in a list
        // https://www.codewars.com/kata/57a2013acf1fa5bfc4000921/csharp
        public static double FindAverage(double[] array) => array.Length != 0 ? array.Average() : 0;
        public static double FindAverage2(double[] array) => array.DefaultIfEmpty().Average();
        public static double FindAverage3(double[] array) => array != null ? array.Average() : 0;

        //Grading book
        //https://www.codewars.com/kata/55cbd4ba903825f7970000f5/train/csharp
        public static char GetGrade(int s1, int s2, int s3)
        {
            int avg = (s1 + s2 + s3) / 3;
            if (avg >= 90) return 'A';
            if (avg >= 80 && avg < 90) return 'B';
            if (avg >= 70 && avg < 80) return 'C';
            if (avg >= 60 && avg < 70) return 'D';
            else return 'F';

        }

        // BMI calculator
        //https://www.codewars.com/kata/57a429e253ba3381850000fb/train/csharp
        public static string Bmi(double weight, double height)
        {
            string result = "";
            double bmi = weight / (height * height);
            if (bmi <= 18.5) result = "Underweight";
            if (bmi > 18.5 && bmi <= 25.0) result = "Normal";
            if (bmi > 25.0 && bmi <= 30.0) result = "Overweight";
            if (bmi > 30) result = "Obese";
            return result;
        }
        // lamba + ternary:
        public static string BmiLambda(double w, double h) => (w = w / h / h) > 30 ? "Obese" : w > 25 ? "Overweight" : w > 18.5 ? "Normal" : "Underweight";

        //counting true sheeps
        //https://www.codewars.com/kata/54edbc7200b811e956000556
        public static int sheepCounter(bool[] sheeps)
        {
            int count = 0;
            //foreach (var item in sheeps)
            foreach (bool sheep in sheeps)
            {
                //if (item == true) count++;
                if (sheep) count++;
            }
            return count;
        }
        //with lambda
        public static int sheepCounterWithLambda(bool[] sheeps) => sheeps.Count(s => s);

        //Lost without map - Given an array of integers, return a new array with each value doubled.
        //https://www.codewars.com/kata/57f781872e3d8ca2a000007e
        public static int[] arrayDoubler(int[] x) => x.Select(s => s * 2).ToArray();



        //Beginner Series #4 Cockroach
        //https://www.codewars.com/kata/55fab1ffda3e2e44f00000c6
        public static int CockRoach(double x)
        {
            x = x * 1000 / 36;
            Math.Floor(x);
            int result = ((int)x);
            return result;

        }
        public static int CockRoach2(double x) => (int)Math.Floor(x * 1000 / 36);

        //Reverse sequence
        //https://www.codewars.com/kata/5a00e05cc374cb34d100000d/solutions/csharp
        public static int[] intsToArrays(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = n;
                n--;
            }

            return result;
        }

        // Area or perimeter
        // https://www.codewars.com/kata/5ab6538b379d20ad880000ab
        public static int areaOrPerimeter(int a, int b) => a == b ? a * b : 2 * a + 2 * b;

        // Sum ofsquares
        // https://www.codewars.com/kata/515e271a311df0350d00000f/solutions/csharp
        public static int sumOfSquares(int[] numbers) => numbers.Select(s => s * s).Sum();
        public static int sumOfSquares2(int[] numbers) => numbers.Sum(s => s * s);


        //Find Maximum and Minimum Values of a List
        //https://www.codewars.com/kata/577a98a6ae28071780000989
        /*
        public class Kata
        {
            public int Min(int[] list) => list.Min();
            public int Max(int[] list) => list.Max();
        }
        */

        //Keep Hydrated!
        //https://www.codewars.com/kata/582cb0224e56e068d800003c
        public static int Litres(double time) => (int)(time * 0.5);
        public static int LitresBitManipulation(double time) => (int)time >> 1;

        // Sum of positive
        // https://www.codewars.com/kata/5715eaedb436cf5606000381/solutions/csharp
        public static int PositiveSum(int[] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {

            }

            return result;
        }

        //Reversing strings 8kyu
        //https://www.codewars.com/kata/5168bb5dfe9a00b126000018
        //Reversing string with iteration
        public static string reverseStringWithIteration(string stringToReverse)
        {
            char[] charToReverse = stringToReverse.ToCharArray();
            char[] toHold = new char[charToReverse.Length];
            int j = charToReverse.Length;

            for (int i = 0; i < charToReverse.Length; i++)
            {

                toHold[i] = charToReverse[j - 1];
                j--;

            }


            Console.WriteLine(toHold);
            string output = new string(toHold);
            return toHold.ToString();

        }

        //reverse String with iteration2
        public static string reverseStringWithIteration2(string stringToReverse)
        {
            string rev = "";
            for (int c = stringToReverse.Length; c > 0; c--)
            {

                rev += stringToReverse[c - 1];
            }
            return rev;
        }

        //Reversing string with aray.reverse

        public static string reverseStringWithArrayReverse(string stringToReverse)
        {
            char[] charToReverse = stringToReverse.ToCharArray();
            Array.Reverse(charToReverse);


            Console.WriteLine(charToReverse);
            return charToReverse.ToString();

        }


        ///Reversing string with linq
        public static string reverseStringwithLinq(string stringToReverse)
        {
            string output = new string(stringToReverse.ToCharArray().Reverse().ToArray());
            return output;

        }

        //Reversing string with linq 2
        public static string reverseStringwithLinq2(string stringToReverse) => string.Concat(stringToReverse.Reverse());

        // Abbreviate a two word name: eg. Sam Harris => S.H, patrick Feeney => P.F 8kyu
        //https://www.codewars.com/kata/57eadb7ecd143f4c9c0000a3
        public static string abbreviateTwoWordName(string name)
        {
            string[] nameArray = name.Split(" ");
            char[] first = nameArray[0].ToUpper().ToCharArray();
            char[] second = nameArray[1].ToUpper().ToCharArray();

            return $"{first[0]}.{second[0]}";

        }
        // Abbreviate a two word name: eg. Sam Harris => S.H, patrick Feeney => P.F with linq
        public static string AbbrevName(string name) => string.Join(".", name.Split(' ').Select(w => w[0])).ToUpper();

        //Convert boolean to string 8kyu
        // https://www.codewars.com/kata/551b4501ac0447318f0009cd
        public static string boolToString(bool var1) => var1.ToString();


        // Needle in the haystack 8kyu
        // https://www.codewars.com/kata/54ba84be607a92aa900000f1

        public static string NeedleInTheHaystack(string[] someWords)
        {
            for (int i = 0; i < someWords.Length; i++)
            {
                if (someWords[i] == "needle")
                {
                    return $"found needle at position {i}";
                }
            }
            return "There is no needle here.";
        }

        // Traffic Lights 8kyu
        // https://www.codewars.com/kata/58649884a1659ed6cb000072
        public static string UpdateLight(string current)
        {
            if (current == "green") return "yellow";
            if (current == "yellow") return "red";
            return "green";
        }

        //You only need one - Beginner - check if array contains x 8kyu
        //https://www.codewars.com/kata/57cc975ed542d3148f00015b
        public static bool tester(object[] a, int x) => a.Contains(x);

        // Convert string to an array 8kyu
        //https://www.codewars.com/kata/57e76bc428d6fbc2d500036d
        public static string[] stringToArray(string str) => str.Split(' ');

        // Rock Paper Scissors 8kyu
        // https://www.codewars.com/kata/5672a98bdbdd995fad00000f
        public string RockPaperScissors(string p1, string p2)
        {
            string result = "";
            if (p1 == "scissors" && p2 == "paper") result = "Player 1 won!";
            if (p1 == "scissors" && p2 == "scissors") result = "Draw!";
            if (p1 == "scissors" && p2 == "rock") result = "Player 2 won!";

            if (p1 == "paper" && p2 == "paper") result = "Draw!";
            if (p1 == "paper" && p2 == "rock") result = "Player 1 won!";
            if (p1 == "paper" && p2 == "scissors") result = "Player 2 won!";

            if (p1 == "rock" && p2 == "paper") result = "Player 2 won!";
            if (p1 == "rock" && p2 == "rock") result = "Draw!";
            if (p1 == "rock" && p2 == "scissors") result = "Player 1 won!";

            return result;
        }



        // Total amount of points 8kyu
        // https://www.codewars.com/kata/5bb904724c47249b10000131

        public static int TotalPoints(string[] games)
        {
            int points = 0;
            foreach (string item in games)
            {
                if (int.Parse(item.Substring(0, 1)) > int.Parse(item.Substring(2))) points += 3;
                if (item.Substring(0, 1) == item.Substring(2)) points += 1;

            }

            return points;
        }


        // summ array of things 8kyu
        // https://www.codewars.com/kata/57eaeb9578748ff92a000009/solutions/csharp

        public static int SumMix(object[] x)
        {
            int sum = 0;
            foreach (var item in x)
            {
                if (item is int) sum += (int)item;
                if (item is string) sum += int.Parse((string)item);

            }

            return sum;

        }
        //with linq
        public static int SumMix2(object[] x) => x.Sum(Convert.ToInt32);


        //Parse nice int from char problem 8kyu
        //https://www.codewars.com/kata/557cd6882bfa3c8a9f0000c1/solutions/csharp
        public static int ParseStringToInt(string inputString)
        {
            int age = 0;
            char[] chars = inputString.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsNumber(chars[i]))
                {
                    int.TryParse(chars[i].ToString(), out age);
                    break;
                }
            }
            return age;

        }

        public static int ParseStringToIntLambda(string inputString) => (int)char.GetNumericValue(inputString[0]);

        //Correct the mistakes of the character recognition software 8kyu
        //https://www.codewars.com/kata/577bd026df78c19bca0002c0
        public static string Correct(string text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '5':
                        chars[i] = 'S';
                        break;
                    case '0':
                        chars[i] = 'O';
                        break;
                    case '1':
                        chars[i] = 'I';
                        break;

                    default:
                        break;
                }
            }

            return new string(chars);
        }

        //Are You Playing Banjo? 8kyu
        //https://www.codewars.com/kata/53af2b8861023f1d88000832
        public static string AreYouPlayingBanjo(string name) => name[0] == 'R' || name[0] == 'r' ? $"{name} plays banjo" : $"{name} does not play banjo";

        public static char CharPlus(char ch)
        {

            int test = (int)ch;
            Console.WriteLine(ch);
            Console.WriteLine(test);
            test += 2;
            ch = (char)test;
            //test = (int)ch;
            Console.WriteLine(ch);
            Console.WriteLine(test);
            return ch;

        }

        //Transportation on vacation
        //https://www.codewars.com/kata/568d0dd208ee69389d000016/csharp
        public static int RentalCarCost(int d)
        {
            int discount = 0;
            if (d >= 3) discount += 20;
            if (d >= 7) discount += 30;
            return d * 40 - discount;

        }

        //String repeat
        //https://www.codewars.com/kata/57a0e5c372292dd76d000d7e

        public static string RepeatStr(int n, string s) => string.Concat(Enumerable.Repeat(s, n));

        //Fake binary
        //https://www.codewars.com/kata/57eae65a4321032ce000002d/train/csharp

        public static string FakeBin(string x)
        { string result = "";
            for (int i = 0; i < x.Length; i++)
            {
                int.TryParse(x[i].ToString(), out int number);
                if (number < 5) result += "0";
                else result += "1";
            }
            return result;
        }

        //Feast of many beasts
        //https://www.codewars.com/kata/5aa736a455f906981800360d/train/csharp
        public static bool Feast(string beast, string dish) => (beast[0] == dish[0] && beast[beast.Length - 1] == dish[dish.Length - 1]);

        public static bool Feast2(string beast, string dish)
        {
            return beast[0] == dish[0] && beast[^1] == dish[^1];
        }

        //Remove exclamation marks
        //https://www.codewars.com/kata/57a0885cbb9944e24c00008e/train/csharp
        public static string RemoveExclamationMarks(string s) => new string(s.ToCharArray().Where(x => x != '?').ToArray());

        //Volume of a cuboid
        //https://www.codewars.com/kata/58261acb22be6e2ed800003a/train/csharp
        public static double GetVolumeOfCuboid(double length, double width, double height) => length * width * height;


    }
}
