using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
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

    }

}
