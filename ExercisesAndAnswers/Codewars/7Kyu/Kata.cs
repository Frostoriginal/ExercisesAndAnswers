using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._7Kyu
{
    public class Kata
    {

        //Survive the attack
        //https://www.codewars.com/kata/634d0f7c562caa0016debac5
        public static bool HasSurvived(int[] attackers, int[] defenders)
        {   //setting up variables
            int attackersSurvivors = attackers.Length;
            int defendersSurvivors = defenders.Length;

            //if one of the arrays is shorter, use shorter array length
            int arrayLength = attackers.Length > defenders.Length ? defenders.Length : attackers.Length;
            //iterate to check survivors count
            for (int i = 0; i < arrayLength; i++)
            {
                if (attackers[i] > defenders[i]) defendersSurvivors--;
                else attackersSurvivors--;
            }
            // if there are more defenders return true
            bool hasSurvived = attackersSurvivors <= defendersSurvivors ? true : false;
            //if defenders and attackers count is the same check for attack power (sum), if both sums are equal return draw - true
            if (attackersSurvivors == defendersSurvivors) hasSurvived = attackers.Sum() < defenders.Sum() ? true : false;
            if (attackersSurvivors == defendersSurvivors && attackers.Sum() == defenders.Sum()) hasSurvived = true;

            return hasSurvived;
        }

        // Descending order integer
        //https://www.codewars.com/kata/5467e4d82edf8bbf40000155
        public static int descendingOrder(int num)
        {
            var ordered = num.ToString().ToCharArray().OrderByDescending(c => c);
            //int.TryParse(string.Join("", ordered), out int result);
            int.TryParse(string.Concat(ordered), out int result);
            return result;

        }
        // with lambda expression, int.parse instead of tryparse, concat instead of join
        public static int descendingOrderLambda(int num) => int.Parse(string.Concat(num.ToString().OrderByDescending(x => x)));



        //Sum of lowest possible ints
        //https://www.codewars.com/kata/558fc85d8fd1938afb000014/solutions/csharp
        public static int lowestPossible(int[] numbers)
        {

            int[] sorted = numbers.OrderBy(s => s).ToArray();
            int result = sorted[0] + sorted[1];
            return result;
        }
        //with linq
        public static int sumTwoSmallestNumbers(int[] numbers) => numbers.OrderBy(i => i).Take(2).Sum();


        //number of people on the bus
        //https://www.codewars.com/kata/5648b12ce68d9daa6b000099
        public static int PeopleOnTheBus(List<int[]> peopleListInOut)
        {
            int passengers = 0;
            foreach (var item in peopleListInOut)
            {
                passengers += item[0];
                passengers -= item[1];
            }

            return passengers;
        }
        //Growth of a Population
        //https://www.codewars.com/kata/563b662a59afc2b5120000c6
        public static int nb_year(int p0, double percent, int aug, int p) //p0, percent, aug (inhabitants coming or leaving each year), p (population to equal or surpass)
        {
            percent = percent * 0.01;
            int years = 1;
            while (p0 + (int)(p0 * percent) + aug < p)
            {
                years++;
                p0 = p0 + (int)(p0 * percent) + aug;

            }
            return years;
        }

        //You're a square!
        //https://www.codewars.com/kata/54c27a33fb7da0db0100040e
        public static bool IsSquare(int n) => n % (Math.Sqrt(n)) == 0 || n == 0 ? true : false;

        //Count the divisors
        //https://www.codewars.com/kata/542c0f198e077084c0000c2e
        public static int CountTheDivisors(int n)
        {
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) count++;
            }
            return count;
        }

        //vowel count
        //https://www.codewars.com/kata/54ff3102c1bad923760001f3
        public static int vowelCount(string str)
        {
            char[] array = str.ToCharArray();
            int vowelCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'a') vowelCount++;
                else if (array[i] == 'e') vowelCount++;
                else if (array[i] == 'i') vowelCount++;
                else if (array[i] == 'o') vowelCount++;
                else if (array[i] == 'u') vowelCount++;

            }
            return vowelCount;

        }

        // vowel count with linq
        public static int vowelCountWithLinq(string str) => str.Count(c => "aeiou".Contains(c));



        //Valid Parentheses
        //https://www.codewars.com/kata/52774a314c2333f0a7000688


        public static bool ValidParentheses(string input)
        {
            char[] charArray = input.ToCharArray();
            int closingIndex = 0;
            int openingIndex = 0;
            int doneCount = 0;

            //setting up array to only parentheses
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] != '(' && charArray[i] != ')') charArray[i] = '*';
            }
            //Checking for proper parentheses pairs
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == ')')
                {
                    closingIndex = i;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (charArray[j] == '(')
                        {
                            openingIndex = j;
                            charArray[closingIndex] = '*';
                            charArray[openingIndex] = '*';
                            i = 0;
                            j = 0;
                            break;
                        }

                    }

                }


            }
            //Checking for any parentheses left            
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '*')
                {
                    doneCount++;
                }
            }
            if (doneCount == charArray.Length)
            {
                return true;
            }

            return false;
        }

        // String ends with
        // https://www.codewars.com/kata/51f2d1cafc9c0f745c00037d
        public static bool StringEndsWith(string str, string ending) => str.EndsWith(ending);

        // Disemvowel trolls
        // https://www.codewars.com/kata/52fba66badcd10859f00097e
        public static string disemvowelTrolls(string str) => string.Concat(str.Where(x => x != 'a' && x != 'e' && x != 'i' && x != 'o' && x != 'u' && x != 'A' && x != 'E' && x != 'I' && x != 'O' && x != 'U'));

        //disemvowel trolls short
        public static string disemvowelTrollsShort(string str) => string.Concat(str.Where(ch => !"aeiouAEIOU".Contains(ch)));


        // Jaden case (uppercase each word first character) 7Kyu
        // https://www.codewars.com/kata/5390bac347d09b7da40006f6
        public static string JadenCase(string str)
        {
            char[] holder = str.ToCharArray();
            for (int i = 0; i < holder.Length; i++)
            {
                if (i == 0)
                {
                    holder[i] = char.ToUpper(holder[i]);

                }
                if (holder[i] == ' ')
                {
                    holder[i + 1] = char.ToUpper(holder[i + 1]);
                }
            }

            return new string(holder); ;

        }

        // with LINQ return String.Join(" ", phrase.Split().Select(i => Char.ToUpper(i[0]) + i.Substring(1)));

        // Isograms 7kyu
        // https://www.codewars.com/kata/54ba84be607a92aa900000f1
        public static bool IsIsogram(string str)
        {
            char[] holder = str.ToCharArray();
            for (int i = 0; i < holder.Length; i++)
            {
                char ToCheck = char.ToUpper(holder[i]);
                for (int j = i + 1; j < holder.Length; j++)
                {
                    if (char.ToUpper(holder[j]) == ToCheck)
                    {
                        return false;
                    }

                }

            }
            return true;
        }

        // categorize new member 7kyu
        // https://www.codewars.com/kata/5502c9e7b3216ec63c0001aa
        public static IEnumerable<string> OpenOrSenior(int[][] data)
        {
            List<string> result = new List<string>();
            foreach (int[] item in data)
            {
                if (item[0] >= 55 && item[1] > 7)
                {
                    result.Add("Senior");
                }
                else
                {
                    result.Add("Open");
                }
            }
            return result;
        }

        // Get middle character 7kyu
        // https://www.codewars.com/kata/56747fd5cb988479af000028/solutions/csharp
        public static string GetMiddle(string s)
        {
            string result = "";
            char[] array = s.ToCharArray();
            if (s.Length % 2 == 0) result = $"{array[(s.Length / 2) - 1]}{array[(s.Length / 2)]}";
            else result = $"{array[s.Length / 2]}";

            return result;
        }


        // Reverse words 7kyu
        //https://www.codewars.com/kata/5259b20d6021e9e14c0010d4
        public static string ReverseWords(string words)
        {
            List<string> list = new List<string>();
            string[] strings = words.Split(' ');

            foreach (var item in strings)
            {
                list.Add(new string(item.ToCharArray().Reverse().ToArray()));
            }

            return string.Join(" ", list);

        }
        //with lambda
        public static string ReverseWords2(string str) => string.Join(" ", str.Split(' ').Select(s => new string(s.Reverse().ToArray())));


        // Reverse words 7 kyu
        // https://www.codewars.com/kata/5259b20d6021e9e14c0010d4
        public static string ReverseWholeWords(string str) => string.Join(" ", str.Split(" ").Reverse());


        //Mumbling 7kyu
        //https://www.codewars.com/kata/5667e8f4e3f572a8f2000039

        public static string accum(string input)
        {
            List<string> output = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string a = char.ToUpper(input[i]).ToString();
                string b = "";
                if (i > 0) b = new string(char.ToLower(input[i]), count: i);
                output.Add(a + b);
            }

            return string.Join("-", output);

        }


        //Highest and Lowest 7kyu
        //https://www.codewars.com/kata/554b4ac871d6813a03000035/solutions/csharp
        public static string HighestAndLowest(string numbers)
        {
            var a = numbers.Split(" ");
            int[] array = { };

            for (int i = 0; i < a.Length; i++)
            {
                Array.Resize(ref array, array.Length + 1);
                int.TryParse(a[i], out array[i]);
            }

            return $"{array.Max()} {array.Min()}";
        }

        //Is this a triangle
        //https://www.codewars.com/kata/56606694ec01347ce800001b/csharp
        public static bool IsTriangle(int a, int b, int c)
        {

            if (a == 0 || b == 0 || c == 0) return false;
            if (a + b > c && a + c > b && b + c > a) return true;
            return false;
        }

        //The highest profit wins!
        //https://www.codewars.com/kata/559590633066759614000063/solutions/csharp
        public static int[] minMax(int[] lst) => new int[] { lst.Min(), lst.Max()};

        //Sum of odd numbers
        //https://www.codewars.com/kata/55fd2d567d94ac3bc9000064/train/csharp
        public static long RowSumOddNumbers(long n) => n * n * n;

        //Regex validate PIN code
        //https://www.codewars.com/kata/55f8a9c06c018a0d6e000132/train/csharp
        public static bool ValidatePin(string pin)
        {
            if (pin.Length != 4 && pin.Length != 6) return false;
            return Regex.Match(pin, @"^(?:\d{4}|\d{6})$").Success;
        }
        //proper regex, edge case = "1234\n"
        public static bool ValidatePin2(string pin) =>  Regex.Match(pin, @"^(?:\d{4}|\d{6})\z").Success;
        //with linq
        public static bool ValidatePin3(string pin) => pin.All(n => Char.IsDigit(n)) && (pin.Length == 4 || pin.Length == 6);
        



    }
}
