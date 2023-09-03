using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._5Kyu
{
    public class Kata
    {

        // RGB to hex conversion 5kyu
        // https://www.codewars.com/kata/513e08acc600c94f01000001
        public static string HexConverter(int r, int g, int b)
        {
            if (r > 255) r = 255;
            if (r < 0) r = 0;
            if (g > 255) g = 255;
            if (g < 0) g = 0;
            if (b > 255) b = 255;
            if (b < 0) b = 0;

            return $"{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}";

        }

        //Rot13 5kyu
        //https://www.codewars.com/kata/530e15517bc88ac656000716/solutions/csharp
        //https://www.codewars.com/kata/52223df9e8f98c7aa7000062/solutions/csharp
        public static string Rot13(string message)
        {
            char[] chars = message.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {

                    if ((int)chars[i] >= 65 && (int)chars[i] < 78)
                        chars[i] = (char)((int)chars[i] + 13);
                    else if ((int)chars[i] >= 78 && (int)chars[i] <= 90)
                        chars[i] = (char)((int)chars[i] - 13);
                    else if ((int)chars[i] >= 97 && (int)chars[i] <= 109)
                        chars[i] = (char)((int)chars[i] + 13);
                    else if ((int)chars[i] > 109 && (int)chars[i] <= 122)
                        chars[i] = (char)((int)chars[i] - 13);

                }
            }
            return new string(chars);
        }


        //Last digit of a large number
        //https://www.codewars.com/kata/5511b2f550906349a70004e1/train/csharp
        public static int GetLastDigit(BigInteger n1, BigInteger n2)
        { //n1^n2
            // last digit of n1 = 0 => 0
            // = 1 => 1
            // = 2 => 2,4,8,6,  2,4,8,6 
            // = 3 => 3,9,7,1, 3,9,7,1
            // = 4 => 4,6, 4,6
            // = 5  => 5
            // = 6  => 6
            // = 7  => 7,9,3,1, 7,9,3,1
            // = 8 => 8,4,2,8 ,8,4,2,8
            // = 9 => 9,1, 9,1,9,1
            // = 0 => 0

            if (n1 == 0 && n2 == 0) return 1;
            if (n1 == 0 && n2 != 0) return 0;
            if (n1 != 0 && n2 == 0) return 1;
            int lastDigitInBigNumber = n1.ToString().Last()-48;
            
            if (lastDigitInBigNumber == 0 || lastDigitInBigNumber == 1 || lastDigitInBigNumber == 5 || lastDigitInBigNumber == 6 || n2 == 1) return lastDigitInBigNumber;
            
            else return (int)BigInteger.ModPow(n1, n2, 10);

            //Console.WriteLine($"integer last number is {lastDigitInBigNumber} ");

            //return -1;
        }

        //Not very secure
        //https://www.codewars.com/kata/526dbd6c8c0eb53254000110/train/csharp

        public static bool Alphanumeric(string str) => Regex.Match(str, @"^[a-zA-Z\d]+\z").Success;

        //Human Readable Time
        //https://www.codewars.com/kata/52685f7382004e774f0001f7/solutions/csharp
        public static string GetReadableTime(int seconds) => $"{seconds / 3600:D2}:{seconds % 3600 / 60:D2}:{seconds % 3600 % 60:D2}";



        //The road-kill detective
        //https://www.codewars.com/kata/58e18c5434a3022d270000f2/train/csharp
        public static string RoadKill(string photo)
        {
            Console.WriteLine(photo);

            List<string> animals = new List<string> { "hyena", "penguin", "bear", "baboon", "wallaby", "snake", "rat", "rabbit", "aardvark", "squirrel", "fox" };

            if (photo.Contains(" ") || photo.Contains("X")) return "??"; //edge case uncomplete tracks
            string cleanedUp = new string(photo.Replace("=", "").ToCharArray());
            string reversed = new string(cleanedUp.Reverse().ToArray());

            if (cleanedUp.Length == 0) return "??";

            foreach (string animal in animals)
            {
                if (animal[0] == cleanedUp[0])
                {
                    int j = 1;                    
                    for (int i = 1; i < cleanedUp.Length; i++)
                    {   if (i > cleanedUp.Length-1 || j > animal.Length - 1) break;                        
                        if (animal[j] == cleanedUp[i])
                        {
                            int temp = animal.Length - 1;
                            if (j == animal.Length - 1)
                            {  if (i == cleanedUp.Length - 1) return animal;
                                for (int k = i+1; k < cleanedUp.Length; k++)
                                {
                                    if (cleanedUp[k] != animal[j]) break;
                                    if(k == cleanedUp.Length-1) return animal;
                                }                                
                            }
                            j++;
                        };
                        if (cleanedUp[i] != animal[j - 1] && cleanedUp[i] != animal[j]) break;
                    }
                }

                if (animal[0] == reversed[0])
                {
                    int j = 1;
                    for (int i = 1; i < reversed.Length; i++)
                    {
                        if (i > reversed.Length - 1 || j > animal.Length - 1) break;
                        if (animal[j] == reversed[i])
                        {
                            int temp = animal.Length - 1;
                            if (j == animal.Length - 1)
                            {
                                if (i == reversed.Length - 1) return animal;
                                for (int k = i + 1; k < reversed.Length; k++)
                                {
                                    if (reversed[k] != animal[j]) break;
                                    if (k == reversed.Length - 1) return animal;
                                }
                            }
                            j++;
                        };
                        if (reversed[i] != animal[j - 1] && reversed[i] != animal[j]) break;
                    }
                }
            }
            return "??";

            /*
            
            char[] chars = photo.Replace("=", "").ToCharArray();            
            if(chars.Length == 0) return "??";
            string deflattenedAnimal = "";
            deflattenedAnimal += chars[0];             

            for (int i = 1; i < chars.Length; i++)
            {  
                if (chars[i] != chars[i-1]) deflattenedAnimal += chars[i];
            }
            
            if (animals.Contains(deflattenedAnimal)) return deflattenedAnimal;
            string reversed = new string(deflattenedAnimal.Reverse().ToArray());
            if (animals.Contains(reversed)) return reversed;

            foreach (string str in animals) 
            {
                bool animalCheck = false;
                if (str[0] == deflattenedAnimal[0] && str.Length == deflattenedAnimal.Length)
                {
                    animalCheck = true;
                    for (int i = 1; i < str.Length; i++)
                    {
                        if (deflattenedAnimal[i] != str[i] ) animalCheck = false;
                    }
                }
                if (str[0] == reversed[0] && str.Length == deflattenedAnimal.Length) 
                {
                    animalCheck = true;
                    for (int i = 1; i < str.Length; i++)
                    {
                        if (reversed[i] != str[i]) animalCheck = false;
                    }
                }
                //1 away
                if (str[0] == deflattenedAnimal[0] && str.Length == deflattenedAnimal.Length+1)
                {
                    animalCheck = true;
                    for (int i = 1; i < deflattenedAnimal.Length; i++)
                    {

                        if (deflattenedAnimal[i] != str[i])
                        {
                            animalCheck = false;
                            if (i + 1<= deflattenedAnimal.Length)
                            {
                                if (deflattenedAnimal[i] == str[i + 1]) animalCheck = true;
                            }
                            if (i - 1>= 0)
                            {
                                if (deflattenedAnimal[i] == str[i - 1]) animalCheck = true;
                            }

                        }

                    }
                }
                if (str[0] == reversed[0] && str.Length == deflattenedAnimal.Length)
                {
                    animalCheck = true;
                    for (int i = 1; i < reversed.Length; i++)
                    {
                        if (reversed[i] != str[i])
                        {
                            animalCheck = false;
                            if(i+1 !> reversed.Length)
                            {
                                if (reversed[i] == str[i + 1]) animalCheck = true;
                            }
                            if(i-1 !<0 )
                            {
                                if (reversed[i] == str[i - 1]) animalCheck = true;
                            }
                            
                        }
                        
                    }
                }

                if (animalCheck) return str;
            }           

            */


        }





    }

}
