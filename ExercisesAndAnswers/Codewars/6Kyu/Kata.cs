using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._6Kyu
{
    internal class Kata
    {
        //Bouncing balls
        //https://www.codewars.com/kata/5544c7a5cb454edb3c000047/solutions/csharp
        public static int BouncingBalls(double h, double bounce, double window)
        {
            int result = 0;
            if (bounce > 0 && bounce < 1 && h != 0 && h > window)
            {
                while (h > window)
                {
                    result += 1;
                    if (h * bounce > window) result += 1;
                    h *= bounce;
                }
            }
            else result = -1;

            return result;
        }
        //with recursion
        public static int bouncingBall(double h, double bounce, double window)
        {
            if (h <= 0 || bounce <= 0 || bounce >= 1 || window >= h) return -1;
            return 2 + bouncingBall(h * bounce, bounce, window);
        }// wywołuje funkcję bouncingBall tak długo jak nie spiełni warunków if, jak spełni odejmie od wyniku -1, lub zwróci -1 jeśli warunki zostały spełnione w 1 iteracji.

        //Find the odd int
        //https://www.codewars.com/kata/54da5a58ea159efa38000836
        public static int findTheOddInt(int[] seq)
        {
            int result = 0;
            foreach (int num in seq)
            {
                int count = seq.Count(n => n == num);
                if (count % 2 != 0) result = num;
            }
            return result;

        }

        //Sort the odd
        //https://www.codewars.com/kata/578aa45ee9fd15ff4600090d
        public static int[] SortTheOdd(int[] array)
        {
            int[] keys = { };
            int j = 0;
            int[] values = { };

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    Array.Resize(ref keys, keys.Length + 1);
                    keys[j] = i;
                    Array.Resize(ref values, values.Length + 1);
                    values[j] = array[i];
                    j++;
                }
            }

            Array.Sort(values);
            for (int i = 0; i < keys.Length; i++)
            {
                array[keys[i]] = values[i];
            }

            return array;
        }


        //Are they the "same"
        //https://www.codewars.com/kata/550498447451fbbd7600041c
        public static bool comp(int[] a, int[] b)
        {
            bool aretheysquares = false;
            if ((a == null) || (b == null)) { aretheysquares = false; }
            else if (a.Length == 0 && b.Length == 0) { aretheysquares = true; }


            else
            {

                Array.Sort(a);
                Array.Sort(b);

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > 0)
                    {
                        if (b[i] / a[i] == a[i])
                        {
                            aretheysquares = true;
                        }
                        else
                        {
                            aretheysquares = false;
                            break;
                        }
                    }
                    else if (b[i] == 0 && a[i] == 0) aretheysquares = true;
                    // Console.WriteLine($"{b[i]} / {a[i]} = {b[i]/a[i]}");
                }
            }
            return aretheysquares;
        }


        //Maze runner 
        //https://www.codewars.com/kata/58663693b359c4a6560001d6/train/csharp
        public static string mazeRunner(int[,] maze, string[] directions)
        {
            int pointI = 0;
            int pointJ = 0;
            int bounds = maze.GetLength(1) - 1;

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == 2)
                    {
                        pointI = i;
                        pointJ = j;
                    }
                }
            }

            for (int i = 0; i < directions.Length; i++)
            {

                if (directions[i] == "N")
                {
                    pointI--;
                    if (pointJ < 0) return "Dead";
                }
                if (directions[i] == "S")
                {
                    pointI++;
                    if (pointJ > bounds) return "Dead";
                }
                if (directions[i] == "E")
                {
                    pointJ++;
                    if (pointI > bounds) return "Dead";
                }
                if (directions[i] == "W")
                {
                    pointJ--;
                    if (pointI < 0) return "Dead";
                }
                if (maze[pointI, pointJ] == 1) return "Dead";
                if (maze[pointI, pointJ] == 3) return "Finish";
            }

            return "Lost";
        }

        //Duplicate Encoder 6 kyu
        //https://www.codewars.com/kata/54b42f9314d9229fd6000d9c/solutions/csharp
        public static string duplicateEncoder(string word)
        {
            word = word.ToUpper();//ignore case
            char[] array = word.ToCharArray();

            for (int i = 0; i < word.Length; i++)
            {
                var a = word.Count(x => x == word[i]);

                if (a == 1) array[i] = '(';
                else
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (array[i] == word[i]) array[i] = ')';
                    }
                }
            }

            return new string(array);

        }

        //Who likes it 6 kyu
        //https://www.codewars.com/kata/5266876b8f4bf2da9b000362
        public static string whoLikesIt(string[] name)
        {
            if (name.Length == 1) return $"{name[0]} likes this";
            if (name.Length == 2) return $"{name[0]} and {name[1]} likes this";
            if (name.Length == 3) return $"{name[0]}, {name[1]} and {name[2]} likes this";
            if (name.Length > 3) return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            else return "no one likes this";

        }

        //Replace with alphabet position 6 kyu
        // https://www.codewars.com/kata/546f922b54af40e1e90001da
        public static string alphabetPosition(string text)
        {
            string result = "";
            if (text.Length != 0)
            {

                char[] array = text.ToUpper().ToCharArray();
                int[] position = new int[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 'A') position[i] = 1;
                    if (array[i] == 'B') position[i] = 2;
                    if (array[i] == 'C') position[i] = 3;
                    if (array[i] == 'D') position[i] = 4;
                    if (array[i] == 'E') position[i] = 5;
                    if (array[i] == 'F') position[i] = 6;
                    if (array[i] == 'G') position[i] = 7;
                    if (array[i] == 'H') position[i] = 8;
                    if (array[i] == 'I') position[i] = 9;
                    if (array[i] == 'J') position[i] = 10;
                    if (array[i] == 'K') position[i] = 11;
                    if (array[i] == 'L') position[i] = 12;
                    if (array[i] == 'M') position[i] = 13;
                    if (array[i] == 'N') position[i] = 14;
                    if (array[i] == 'O') position[i] = 15;
                    if (array[i] == 'P') position[i] = 16;
                    if (array[i] == 'Q') position[i] = 17;
                    if (array[i] == 'R') position[i] = 18;
                    if (array[i] == 'S') position[i] = 19;
                    if (array[i] == 'T') position[i] = 20;
                    if (array[i] == 'U') position[i] = 21;
                    if (array[i] == 'V') position[i] = 22;
                    if (array[i] == 'W') position[i] = 23;
                    if (array[i] == 'X') position[i] = 24;
                    if (array[i] == 'Y') position[i] = 25;
                    if (array[i] == 'Z') position[i] = 26;
                }

                for (int i = 0; i < position.Length; i++) if (position[i] != 0) result += $" {position[i]}";
            }
            return result.Trim();

            // with linq:
            //return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(x => x - 'a' + 1));
            //or
            //return string.Join(" ", text.ToLower()
            //                              .Where(c => char.IsLetter(c))
            //                              .Select(c => "abcdefghijklmnopqrstuvwxyz".IndexOf(c) + 1)
            //                              .ToArray());
        }

        // pangram detector 6kyu
        // https://www.codewars.com/kata/545cedaa9943f7fe7b000048

        public static bool PangramDetector(string str)
        {
            str = str.ToUpper();
            if (str.Contains('A') && str.Contains('B') && str.Contains('C')
                && str.Contains('D') && str.Contains('E') && str.Contains('F')
                && str.Contains('G') && str.Contains('H') && str.Contains('I')
                && str.Contains('J') && str.Contains('K') && str.Contains('L')
                && str.Contains('M') && str.Contains('N') && str.Contains('O')
                && str.Contains('P') && str.Contains('Q') && str.Contains('R')
                && str.Contains('S') && str.Contains('T') && str.Contains('U')
                && str.Contains('V') && str.Contains('W') && str.Contains('X')
                && str.Contains('Y') && str.Contains('Z')
                )
                return true;
            else return false;

        }

        // with linq
        public static bool PangramDetector2(string str) => str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;



        //Break Camel case 6kyu
        // https://www.codewars.com/kata/5208f99aee097e6552000148
        public static string BreakCamelCase2(string str) => string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));

        //string.Join(" ", str.ToCharArray().Where(ch => char.IsUpper(ch))); //do poprawy

        public static string BreakCamelCase(string str) => string.Join(" ", str.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }));

        public static string BreakCamelHardWay(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            else
            {
                char[] array = str.ToCharArray();
                int breakTheCamelPoint = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (char.IsUpper(array[i]))
                    {
                        breakTheCamelPoint = i;
                        Array.Resize(ref array, array.Length + 1);

                        for (int j = array.Length - 1; j > breakTheCamelPoint; j--)
                        {
                            array[j] = array[j - 1];

                        }
                        array[i] = ' ';
                        i++;
                    }
                }
                return new string(array);
            }

        }


        //Calculate String rotation 6kyu
        //https://www.codewars.com/kata/5596f6e9529e9ab6fb000014

        public static int StringRotationPoints(string first, string second)
        {
            int index = -1;
            if ((second + second).Contains(first) && first.Length == second.Length) index = (second + second).IndexOf(first);
            return index;

        }

        //Ternary

        public static int StringRotationPointsT(string first, string second) => second.Length == first.Length ? (second + second).IndexOf(first) : -1;


        //Count characters in your string 6kyu
        //https://www.codewars.com/kata/52efefcbcdf57161d4000091/solutions/csharp
        public static string countTheCharacters(string s)
        {
            List<string> result = new List<string>();
            foreach (char character in s)
            {
                int count = s.Where(x => x == character).Count();
                result.Add($"'{character}': {count} ");
            }
            result = result.Distinct().ToList();
            string resultString = string.Join(", ", result);
            Console.WriteLine(resultString);
            return resultString;
        }

        public static Dictionary<char, int> Count(string str)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            if (str == "") return counter;

            foreach (char character in str)
            {
                int count = str.Where(x => x == character).Count();
                if (counter.ContainsKey(character) != true) counter.Add(character, count);
            }
            return counter;
        }

        //Decode the morse code 6kyu
        //https://www.codewars.com/kata/54b724efac3d5402db00065e/solutions/csharp

        public static string morseDecoder(string morseCode)
        {
            List<string> decodedWords = new List<string>();
            var morseWords = morseCode.Trim().Split("   ");

            foreach (string item in morseWords)
            {
                string decodedWord = "";
                var morseChars = item.Split(" ");
                foreach (string characterToDecode in morseChars)
                {
                    decodedWord += characterToDecode;//MorseCode.Get(characterToDecode);
                }
                decodedWords.Add(decodedWord);
            }


            return string.Join(" ", decodedWords);
        }

        //Highest scoring word
        //https://www.codewars.com/kata/57eb8fcdf670e99d9b000272

        public static string High(string s)
        {
            List<string> words = s.Split(' ').ToList();
            string currentHighestScoringWord = "";
            int currentHighestScore = 0;
            foreach (string word in words)
            {
                int wordHighScore = score(word);
                if (wordHighScore > currentHighestScore)
                {
                    currentHighestScore = wordHighScore;
                    currentHighestScoringWord = word;
                }
            }

            return currentHighestScoringWord;
        }

        public static int score(string s)
        {
            int score = 0;
            foreach (char character in s)
            {
                score += character - 96;
            }
            return score;
        }

        //Consecutive strings
        //https://www.codewars.com/kata/56a5d994ac971f1ac500003e/train/csharp
        public static string LongestConsec(string[] strarr, int k)
        {
            if (k == 0) return "";
            if (k == 1) return strarr.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            //List<string> concatenated = new List<string>();
            string currentLongest = "";
            for (int i = 0; i <= strarr.Length - k; i++)
            {
                string result = "";
                for (int j = 0; j < k; j++)
                {
                    result += strarr[i + j];
                }
                //concatenated.Add(result);
                if (result.Length > currentLongest.Length) currentLongest = result;
            }

            


            return currentLongest;//concatenated.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
        }

        //Count the smiley faces
        //https://www.codewars.com/kata/583203e6eb35d7980400002a/solutions/csharp
        public static int countSmileys(string[] smileys)
        {
            int count = 0;
            Regex regex = new Regex(@"^([:|;])([-|~)])?([\)|D])$");
            foreach (string item in smileys)
            {
                Match match = regex.Match(item);
                if (match.Success) count++;
            }
            return count;

        }
        public static int CountSmileys2(string[] smileys) =>  smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));

        //Two sum
        //https://www.codewars.com/kata/52c31f8e6605bcc646000082/solutions/csharp

        public static int[] twoSum(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target) return new int[] { i, j };
                }
            }
            return new int[0];
        }

        //Take a ten minutes walk
        //https://www.codewars.com/kata/54da539698b8a2ad76000228/train/csharp
        public static bool IsValidWalk(string[] walk)
        {
            if (walk.Length != 10) return false;

            int horizontal = 0;
            int vertical = 0;
            for (int i = 0; i < walk.Length; i++)
            {
                if (walk[i] == "n") horizontal++;
                if (walk[i] == "s") horizontal--;
                if (walk[i] == "w") vertical++;
                if (walk[i] == "e") vertical--;
            }
            if (horizontal != 0 || vertical != 0) return false;
            return true;
        }



    }



}
