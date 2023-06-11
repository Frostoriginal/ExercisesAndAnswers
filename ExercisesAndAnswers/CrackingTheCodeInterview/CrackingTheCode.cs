using System;
using System.Linq;

namespace ExercisesAndAnswers.CrackingTheCodeInterview
{
    public class CrackingTheCode
    {
        public class Question11 //Solved
        {
            //1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you  cannot use additional data structures?

            //is input string with whitespaces? is input string only alphabet chars?  - anything longer than 26(alphabet length) would return false.
            //is input string including numbers and symbols? is it case sensitive?

            //Count the distinct letters and confront it with total characters count,
            public static bool hasOnlyUniqeLetters(string str) => str.Where(ch => char.IsLetter(ch)).Select(ch => char.ToLower(ch)).Distinct().Count() == str.Where(ch => char.IsLetter(ch)).Count();
            //Count the distinct letters and confront it with string length
            public static bool hasOnlyUniqeLettersNoWhitespaces(string str) => str.Where(ch => char.IsLetter(ch)).Select(ch => char.ToLower(ch)).Distinct().Count() == str.Length;
            //Count the distinct characters and confront it with string length
            public static bool hasOnlyUniqeCharactersNoWhitespaces(string str) => str.Select(ch => ch).Distinct().Count() == str.Length;
            //Count the distinct characters and confront it with total character count 
            public static bool hasOnlyUniqeCharacters(string str) => str.Select(ch => ch).Distinct().Count() == str.Select(ch => ch).Count();

            //Iterate through whole string to check for more than one occurence, return false on first one. If string is longer than - 26 for alphabet, 255 for ascii, more for unicode 

            public static bool hasOnlyUniqueCharactersBruteForce(string str)
            {
                if (str.Length > 254) return false;
                char[] chars = str.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    char toCheck = chars[i];
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (toCheck == chars[j]) return false;
                    }
                }

                return true;
            }

        }

        public class Question12 //Solved
        {
            //1.2 Check Permutation: Given two strings, write a method to decide if one is a permutation of the other.

            //possible answers:
            //check if both strings are the same size and have the same characters
            //Brute force - compare two strings with for loop for consisting the same characters 
            public static bool isPermutationBruteForce(string a, string b)
            {
                if (a.Length != b.Length) return false;
                char[] fromA = a.ToCharArray();
                char[] fromB = b.ToCharArray();

                int sameLetters = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (fromA[i] == fromB[j])
                        {
                            sameLetters++;
                        }
                    }
                }
                if (sameLetters != a.Length) return false;

                return true;
            }

            public static bool isPermutationSort(string a, string b)
            { //more readable code than the more compact / commented one
                if (a.Length != b.Length) return false;

                a = new string(a.ToCharArray().OrderBy(x => x).ToArray());
                b = new string(b.ToCharArray().OrderBy(x => x).ToArray());

                if (string.Equals(a, b)) return true;
                else return false;

                // if (a.Length == b.Length && string.Equals(new string(a.ToCharArray().OrderBy(x => x).ToArray()), new string(b.ToCharArray().OrderBy(x => x).ToArray()))) return true;
                // else return false;
            }

            //with linq
            public static bool isPermutationSortWithLambda(string a, string b) => a.Length == b.Length && string.Equals(new string(a.ToCharArray().OrderBy(x => x).ToArray()), new string(b.ToCharArray().OrderBy(x => x).ToArray()));
        }

        public class Question13 // Solved
        {
            //1.3 URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string 
            //has sufficient space at the end to hold the additional characters, and that you are given the "true" 
            //length of the string. (Note: If implementing in Java, please use a character array so that you can
            //perform this operation in place.).

            //possible answers: use linq split(' '), linq join("%20")
            //brute force - for every whitespace resize the array +2, move next chars to indexes +2 and insert %20 instead of whitespace
            //with linq
            public static string urlifiedString(string s) => string.Join("%20", s.Split(' '));

        }

        public class Question14
        {
            //1.4 Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
            //A palindrome is a word or phrase that is the same forwards and backwards. A permutation 
            //is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.

            //remarks - palindrome would have 1 distinct letter(or odd number), and 2 or power of 2 of other letters - for uneven length, 2 or power of 2 for even ones

        }

        public class Question15
        {
            //1.5 One Away: There are three types of edits that can be performed on strings: insert a character, 
            //remove a character, or replace a character.Given two strings, write a function to check if they are
            //one edit (or zero edits) away.

            //remarks - compare if one string consists the second one, sorted - for adding or deleting char, for replacing check if distinct letters are more than 1?

        }

        public class Question16 // solved
        {
            //1.6 String Compression: Implement a method to perform basic string compression using the counts 
            //of repeated characters.For example, the string aabcccccaaa would become a2b1c5a3.If the 
            //"compressed" string would not become smaller than the original string, your method should return 
            //the original string. You can assume the string has only uppercase and lowercase letters(a - z).

            //Remarks - is it case sensitive? edge cases?
            public static string StringCompressor(string s)
            {
                string result = "";

                char currentChar = s[0];
                int repetition = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == currentChar)
                    {
                        repetition++;
                    }
                    else
                    {
                        result += $"{currentChar}{repetition}";
                        currentChar = s[i];
                        repetition = 1;
                    }

                }
                result += $"{currentChar}{repetition}";


                if (result.Length > s.Length) return s;
                else return result;
            }

        }

        public class Question17
        {
            //1.7 Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4 
            //bytes, write a method to rotate the image by 90 degrees.Can you do this in place?

        }

        public class Question18 //Solved
        {
            //1.8 Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and 
            //column are set to 0.

            //Remarks - add copy of the matrix and add function to zero whole row and whole column of [i,j]
            //Matrix have to be copied by each cell value, otherwise it is referenced arrayA = arrayB is a reference 

            public static int[,] ZeroTheMatrix(int[,] array)
            {
                int iBound = array.GetLength(0);
                int jBound = array.GetLength(1);
                int[,] result = new int[array.GetLength(0), array.GetLength(1)];
                //fill result with input data
                for (int i = 0; i < iBound; i++)
                {
                    for (int j = 0; j < jBound; j++)
                    {
                        result[i, j] = array[i, j];

                    }
                }

                for (int i = 0; i < iBound; i++)
                {
                    for (int j = 0; j < jBound; j++)
                    {
                        // Console.WriteLine($"i:{i}, j:{j}, value: {array[i, j]}");
                        if (array[i, j] == 0)
                        {
                            //zero the row
                            for (int x = 0; x < iBound; x++)
                            {
                                result[i, x] = 0;
                            }
                            //zero the column
                            for (int y = 0; y < jBound; y++)
                            {
                                result[y, j] = 0;
                            }
                        }

                    }
                }

                return result;
            }



        }

        public class Question19 //Solved
        {
            //1.9 String Rotation:Assume you have a method isSubstring which checks if one word is a substring 
            //of another.Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one
            //call to isSubstring(e.g., "waterbottle" is a rotation of"erbottlewat"). 

            public static bool StringRotation(string s1, string s2) => (s1 + s1).Contains(s2);



        }

    }
}
