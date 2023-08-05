using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._4Kyu
{
    #region    // Validate Sudoku with size `NxN`
    // https://www.codewars.com/kata/540afbe2dc9f615d5e000425
    public class SudokuAsAClass
    {
        bool realsudoku = true;
        int n;
        int m;
        int expectedSum;
        int realSum;
        int rowSum;
        int[][] SudokuData;
        //int smallSquareN;
        public SudokuAsAClass(int[][] sudokuData)
        {
            SudokuData = sudokuData;
            n = sudokuData.Length; //column count
            m = sudokuData.Count(); //row counts 
            expectedSum = n * Enumerable.Sum(Enumerable.Range(1, n));
            realSum = 0;
            foreach (var item in sudokuData)
            {
                realSum += item.Sum();
            }
            if (m != n) realsudoku = false;
            if (realSum != expectedSum) realsudoku = false;

            rowSum = Enumerable.Sum(Enumerable.Range(1, n));
            if (realsudoku == true)
            {
                //row check
                for (int i = 0; i < n; i++)
                {
                    int localRowSum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        localRowSum += sudokuData[i][j];
                    }
                    if (localRowSum != rowSum) realsudoku = false;
                }
                //column check
                for (int i = 0; i < n; i++)
                {
                    int localColSum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        localColSum += sudokuData[j][i];
                    }
                    if (localColSum != rowSum) realsudoku = false;

                }
                //small square check
                int smallSquareN = (int)Math.Sqrt(n);
                int localSquareSum = 0;
                for (int i = 0; i < smallSquareN; i++)
                {
                    for (int j = 0; j < smallSquareN; j++)
                    {
                        localSquareSum += sudokuData[j][i];
                    }
                }
                if (localSquareSum != rowSum) realsudoku = false;

            }
        }

        public bool IsValid()
        {
            Console.WriteLine($"n equals {n}, m equals {m}, expected sum equals {expectedSum}, realsum equals {realSum} rowsum {rowSum}");
            foreach (var item in SudokuData)
            {

                Console.WriteLine(string.Join("", item));
            }
            return realsudoku;



        }
    }

    #endregion
    internal class Kata
    {

        #region        //Adding big numbers
        //https://www.codewars.com/kata/525f4206b73515bffb000b21

        public static string AddBigNumbers(string a, string b)  // another solution - using BigIntegers.
        {
            string result = "";
            int arrayLength = 0;

            //check if both numbers are the same lenght, if not check which one is longer to determine array length.
            if (a.Length != b.Length)
            {
                if (a.Length > b.Length) arrayLength = a.Length;
                else arrayLength = b.Length;
            }
            else arrayLength = a.Length;
            char[] arrayA = a.ToArray();
            char[] arrayB = b.ToArray();

            //set up arrays
            char[] newArrayA = new char[arrayLength + 1];
            Array.Fill(newArrayA, '0');
            Array.Reverse(arrayA);
            Array.Copy(arrayA, newArrayA, a.Length);
            Array.Reverse(newArrayA);
            // possible refactor- use string.padleft instead of arrays, acces string as array.

            char[] newArrayB = new char[arrayLength + 1];
            Array.Fill(newArrayB, '0');
            Array.Reverse(arrayB);
            Array.Copy(arrayB, newArrayB, b.Length);
            Array.Reverse(newArrayB);

            //add the numbers
            int localSum = 0;
            int moved = 0;
            for (int i = arrayLength; i >= 0; i--)
            {

                int.TryParse(newArrayA[i].ToString(), out int aInt);
                int.TryParse(newArrayB[i].ToString(), out int bInt);
                localSum = aInt + bInt + moved;
                if (localSum > 9)
                {
                    moved = 1;
                    localSum -= 10;
                }
                else moved = 0;
                result += localSum;

            }

            //Parse the array, trim leading 0's if needeed
            char[] arrayResult = result.ToCharArray();
            if (arrayResult[arrayResult.Length - 1] == 48) Array.Resize(ref arrayResult, arrayResult.Length - 1);
            Array.Reverse(arrayResult);
            result = new String(arrayResult);

            return result;

        }
        #endregion
        #region        //Sudoku checker
        //https://www.codewars.com/kata/540afbe2dc9f615d5e000425

        public static bool SudokuCheck(int[][] SudokuArray)
        {
            bool realsudoku = true;
            //array dimension is n x n
            //int n = (int)Math.Sqrt(SudokuArray.Length);
            int n = SudokuArray.Length; //column count
            int m = SudokuArray.Count(); //row counts 
            Console.WriteLine($"N equals {n}, length equals {SudokuArray.Count()}");

            //check if array is nxn /square
            if (SudokuArray.Count() % n != 0) realsudoku = false;

            //check if the sum equals
            int expectedSum = n * Enumerable.Sum(Enumerable.Range(1, n));
            Console.WriteLine($"expected sum = {expectedSum}");
            int realsum = 0;
            foreach (var item in SudokuArray)
            {
                realsum += item.Sum();
            }
            if (realsum != expectedSum) realsudoku = false;

            //check rows
            int rowSum = Enumerable.Sum(Enumerable.Range(1, n));

            for (int i = 0; i < n; i++)
            {
                int localRowSum = 0;
                for (int j = 0; j < n; j++)
                {
                    localRowSum += SudokuArray[i][j];
                }
                if (localRowSum != rowSum) realsudoku = false;
                Console.WriteLine($"This is local row sum is {localRowSum}");
            }

            //check colums
            for (int i = 0; i < n; i++)
            {
                int localColSum = 0;
                for (int j = 0; j < n; j++)
                {
                    localColSum += SudokuArray[j][i];
                }
                if (localColSum != rowSum) realsudoku = false;
                Console.WriteLine($"This is local column sum is {localColSum}");
            }

            Console.WriteLine($"realsum is {realsum}");

            int lineSum = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9;
            Console.WriteLine($"Sum of the line = {lineSum}, sum of the array should be {lineSum * 9}");
            int anotherlinesum = 0;
            var a = Enumerable.Range(1, 9);
            anotherlinesum = Enumerable.Sum(a);
            Console.WriteLine(anotherlinesum);

            int b = SudokuArray.Length;
            Console.WriteLine($"Array length {b}");



            return realsudoku;
        }
        #endregion
        #region        //Next bigger number with the same digits 
        //https://www.codewars.com/kata/55983863da40caa2c900004e
        //https://www.geeksforgeeks.org/find-next-greater-number-set-digits/
        public static long nextBiggerNumber(long n)
        { // generates timeout --calculates all permutations
            long next = -1;
            int[] arrayOfNumbers = n.ToString().ToCharArray().Select(c => c - 48).ToArray();
            List<string> strings = new List<string>();
            foreach (var permutation in arrayOfNumbers.GetPermutations())
            {
                strings.Add(string.Join("", permutation));
            }

            var a = strings.OrderBy(c => int.Parse(c)).Distinct();

            int numberIndex = a.ToList().IndexOf(n.ToString());

            foreach (var item in a.ToList())
            {
                Console.WriteLine(item);
            }

            if (numberIndex != a.ToList().Count() - 1) next = int.Parse(a.ToList().ElementAt(numberIndex + 1));

            return next;
        }

        public static long nextBigThing(long n)
        {
            long result = 0;
            int[] numbers = n.ToString().ToCharArray().Select(c => c - 48).ToArray();
            int rightHandValue = 0;
            int leftHandValue = -1;
            int rightHandIndex = -1;
            int leftHandIndex = 0;
            int rightHandTemporary = 10;
            int rightHandTemporaryIndex = 0;

            if (n > 11)
            {
                //find left hand value, change result to -1 if there is none
                for (int i = numbers.Length - 1; i > 0; i--)
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        leftHandValue = numbers[i - 1];
                        leftHandIndex = i - 1;
                        break;
                    }

                }
                if (leftHandValue == -1) result = -1;

                //find righthand value
                for (int i = leftHandIndex; i < numbers.Length; i++)
                {
                    if (numbers[i] > leftHandValue && numbers[i] < rightHandTemporary)
                    {
                        rightHandTemporary = numbers[i];
                        rightHandTemporaryIndex = i;
                    }
                    if (i == numbers.Length - 1)
                    {
                        rightHandIndex = rightHandTemporaryIndex;
                        rightHandValue = rightHandTemporary;
                    }

                }
                //swap
                if (leftHandValue != -1)
                {
                    numbers[leftHandIndex] = rightHandValue;
                    numbers[rightHandIndex] = leftHandValue;
                }
                //oder the rest
                if (leftHandIndex < numbers.Length && leftHandIndex != -1 && result != -1)
                {
                    int[] holder = new int[numbers.Length - leftHandIndex - 1];
                    Array.Copy(numbers, leftHandIndex + 1, holder, 0, numbers.Length - leftHandIndex - 1);
                    Array.Sort(holder);

                    int j = numbers.Length - 1;
                    for (int i = holder.Length - 1; i >= 0; i--)
                    {
                        numbers[j] = holder[i];
                        j--;
                    }

                }
                if (leftHandIndex < numbers.Length && leftHandIndex != -1 && result != -1) result = long.Parse(string.Join("", numbers));
            }
            return result;
        }

        #endregion

        #region        // Path Finder #1: can you reach the exit?
        // https://www.codewars.com/kata/5765870e190b1472ec0022a2/train/csharp
        public static bool findExit(char[,] mazeArray)
        {

            int ipoint = 0; //rows
            int jpoint = 0; //columns //starting point 0,0, endpoint N-1,N-1
            int iBoundary = mazeArray.GetLength(0) - 1;
            int jBoundary = mazeArray.GetLength(1) - 1; //W-E -> columns change, N-S -> row change

            bool running = true;
            Stack<int[]> crossroads = new Stack<int[]>();
            int movesDone = 0;

            while (running)
            {

                bool moveNPossible = false;
                bool moveSPossible = false;
                bool moveWPossible = false;
                bool moveEPossible = false;
                int possibleWays = 0;


                mazeArray[ipoint, jpoint] = '+'; //+ for been there

                //1. look around
                //N
                if (ipoint - 1 >= 0)
                {
                    if (mazeArray[ipoint - 1, jpoint] == '.')
                    {
                        moveNPossible = true;
                        possibleWays++;
                    }
                }

                //S
                if (ipoint + 1 <= iBoundary)
                {
                    if (mazeArray[ipoint + 1, jpoint] == '.')
                    {
                        moveSPossible = true;
                        possibleWays++;
                    }
                }

                //W
                if (jpoint - 1 >= 0)
                {
                    if (mazeArray[ipoint, jpoint - 1] == '.')
                    {
                        moveWPossible = true;
                        possibleWays++;
                    }
                }

                //E
                if (jpoint + 1 <= jBoundary)
                {
                    if (mazeArray[ipoint, jpoint + 1] == '.')
                    {
                        moveEPossible = true;
                        possibleWays++;
                    }
                }

                if (possibleWays > 1)
                {
                    mazeArray[ipoint, jpoint] = '*';
                    crossroads.Push(new int[] { ipoint, jpoint, movesDone });
                }

                if (possibleWays > 0)
                {
                    bool movedAlready = false;
                    if (moveNPossible == true && movedAlready == false)
                    {
                        ipoint--;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveSPossible == true && movedAlready == false)
                    {
                        ipoint++;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveWPossible == true && movedAlready == false)
                    {
                        jpoint--;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveEPossible == true && movedAlready == false)
                    {
                        jpoint++;
                        movesDone++;
                    }
                }

                if (possibleWays == 0 && crossroads.Count == 0) return false;

                if (possibleWays == 0)
                {
                    if (crossroads.Count != 0)
                    {
                        int[] coordinates = new int[2];
                        coordinates = crossroads.Peek();
                        ipoint = coordinates[0];
                        jpoint = coordinates[1];
                        movesDone = coordinates[2];
                        crossroads.Pop();
                    }
                };


                MathWorks.arrayPrinter(mazeArray);
                Console.WriteLine($"moves done: {movesDone}");
                System.Threading.Thread.Sleep(100);
                if (ipoint == iBoundary && jpoint == jBoundary) running = false;
            }
            return true;
        }

        #endregion

        public static void mazeConvertor(string maze)
        {

            List<string> temp = new List<string>();
            temp = maze.Split("\n").ToList();
            char[,] mazeArray = new char[temp.Count, temp[0].Length];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[0].Length; j++)
                {
                    mazeArray[i, j] = temp[i][j];
                }
            }
            MathWorks.arrayPrinter(mazeArray);
            System.Threading.Thread.Sleep(1000);
        }

        public static bool PathFinder(string maze)
        {
            if (maze == ".") return true;

            List<string> temp = maze.Split("\n").ToList();
            List<int> pathLength = new List<int>();

            char[,] mazeArray = new char[temp.Count, temp[0].Length];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[0].Length; j++)
                {
                    mazeArray[i, j] = temp[i][j];
                }
            }

            int ipoint = 0;
            int jpoint = 0;
            int iBoundary = mazeArray.GetLength(0) - 1;
            int jBoundary = mazeArray.GetLength(1) - 1;
            int movesDone = 0;

            bool running = true;
            Stack<int[]> crossroads = new Stack<int[]>();

            while (running)
            {
                bool moveNPossible = false;
                bool moveSPossible = false;
                bool moveWPossible = false;
                bool moveEPossible = false;
                int possibleWays = 0;

                mazeArray[ipoint, jpoint] = '+';

                if (ipoint - 1 > 0)
                {
                    if (mazeArray[ipoint - 1, jpoint] == '.')
                    {
                        moveNPossible = true;
                        possibleWays++;
                    }
                }


                if (ipoint + 1 <= iBoundary)
                {
                    if (mazeArray[ipoint + 1, jpoint] == '.')
                    {
                        moveSPossible = true;
                        possibleWays++;
                    }
                }


                if (jpoint - 1 > 0)
                {
                    if (mazeArray[ipoint, jpoint - 1] == '.')
                    {
                        moveWPossible = true;
                        possibleWays++;
                    }
                }


                if (jpoint + 1 <= jBoundary)
                {
                    if (mazeArray[ipoint, jpoint + 1] == '.')
                    {
                        moveEPossible = true;
                        possibleWays++;
                    }
                }

                if (possibleWays > 1)
                {
                    mazeArray[ipoint, jpoint] = '*';
                    crossroads.Push(new int[] { ipoint, jpoint });
                }

                if (possibleWays > 0)
                {
                    bool movedAlready = false;
                    if (moveNPossible == true && movedAlready == false)
                    {
                        ipoint--;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveSPossible == true && movedAlready == false)
                    {
                        ipoint++;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveWPossible == true && movedAlready == false)
                    {
                        jpoint--;
                        movedAlready = true;
                        movesDone++;
                    }

                    if (moveEPossible == true && movedAlready == false)
                    {
                        jpoint++;
                        movesDone++;
                    }
                }

                //visualizer
                MathWorks.arrayPrinter(mazeArray);
                Console.WriteLine($"moves done: {movesDone}");
                System.Threading.Thread.Sleep(1000);

                if (ipoint == iBoundary && jpoint == jBoundary)
                {
                    pathLength.Add(movesDone);
                    return true;
                }

                if (possibleWays == 0 && crossroads.Count == 0) return false;

                if (possibleWays == 0)
                {
                    if (crossroads.Count != 0)
                    {
                        int[] coordinates = new int[3];
                        coordinates = crossroads.Peek();
                        ipoint = coordinates[0];
                        jpoint = coordinates[1];
                        crossroads.Pop();
                    }
                }

            }
            return true;
        }


        // Path Finder #2: shortest path 4kyu //unsolved
        // https://www.codewars.com/kata/57658bfa28ed87ecfa00058a

        public static int PathFinder2(string maze)
        {
            if (maze == ".") return 0;

            List<string> temp = maze.Split("\n").ToList();
            List<int> pathLength = new List<int>();

            char[,] mazeArray = new char[temp.Count, temp[0].Length];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[0].Length; j++)
                {
                    mazeArray[i, j] = temp[i][j];
                }
            }

            int ipoint = 0;
            int jpoint = 0;
            int iBoundary = mazeArray.GetLength(0) - 1;
            int jBoundary = mazeArray.GetLength(1) - 1;
            int movesDone = 0;
            char lastMove = ' ';
            char movePreferred = ' ';

            bool running = true;
            Stack<int[]> crossroads = new Stack<int[]>();

            while (running)
            {
                bool moveNPossible = false;
                bool moveSPossible = false;
                bool moveWPossible = false;
                bool moveEPossible = false;
                int possibleWays = 0;


                mazeArray[ipoint, jpoint] = '+';

                if (ipoint - 1 > 0 && lastMove != 'S')
                {
                    if (movePreferred == ' ' || movePreferred == 'N')
                    {
                        if (mazeArray[ipoint - 1, jpoint] == '.')
                        {
                            moveNPossible = true;
                            possibleWays++;
                        }
                        else movePreferred = ' ';
                    }
                }


                if (ipoint + 1 <= iBoundary && lastMove != 'N')
                {
                    if (movePreferred == ' ' || movePreferred == 'S')
                    {

                        if (mazeArray[ipoint + 1, jpoint] == '.')
                        {
                            moveSPossible = true;
                            possibleWays++;
                        }
                        else movePreferred = ' ';
                    }
                }

                if (jpoint + 1 <= jBoundary && lastMove != 'W')
                {
                    if (movePreferred == ' ' || movePreferred == 'E')
                    {
                        if (mazeArray[ipoint, jpoint + 1] == '.')
                        {
                            moveEPossible = true;
                            possibleWays++;
                        }
                        else movePreferred = ' ';
                    }
                }


                if (jpoint - 1 > 0 && lastMove != 'E')
                {
                    if (movePreferred == ' ' || movePreferred == 'W')
                    {
                        if (mazeArray[ipoint, jpoint - 1] == '.')
                        {
                            moveWPossible = true;
                            possibleWays++;
                        }
                        else movePreferred = ' ';
                    }
                }



                if (possibleWays > 1)
                {
                    mazeArray[ipoint, jpoint] = '*';
                    crossroads.Push(new int[] { ipoint, jpoint, movesDone });
                }

                if (possibleWays > 0)
                {
                    bool movedAlready = false;
                    if (moveNPossible == true && movedAlready == false)
                    {
                        ipoint--;
                        movedAlready = true;
                        movesDone++;
                        lastMove = 'N';
                        movePreferred = 'N';
                    }

                    if (moveSPossible == true && movedAlready == false)
                    {
                        ipoint++;
                        movedAlready = true;
                        movesDone++;
                        lastMove = 'S';
                        movePreferred = 'S';
                    }

                    if (moveEPossible == true && movedAlready == false)
                    {
                        jpoint++;
                        movesDone++;
                        lastMove = 'E';
                        movedAlready = true;
                        movePreferred = 'E';
                    }

                    if (moveWPossible == true && movedAlready == false)
                    {
                        jpoint--;
                        movedAlready = true;
                        movesDone++;
                        lastMove = 'W';
                        movePreferred = 'W';
                    }


                }

                //visualizer
                MathWorks.arrayPrinter(mazeArray);
                Console.WriteLine($"moves done: {movesDone}");
                Console.WriteLine($"Last move = {lastMove}");
                Console.WriteLine($"Move preferred = {movePreferred}");
                Console.WriteLine($"Possible ways = {possibleWays}");

                System.Threading.Thread.Sleep(1000);

                if (ipoint == iBoundary && jpoint == jBoundary)
                {
                    pathLength.Add(movesDone);
                    possibleWays = 0;
                    movePreferred = ' ';
                }

                if (possibleWays == 0 && crossroads.Count == 0 && pathLength.Count == 0) return -1;
                if (possibleWays == 0 && crossroads.Count == 0 && pathLength.Count != 0) running = false;



                if (possibleWays == 0 && movePreferred == ' ')
                {

                    if (crossroads.Count != 0)
                    {
                        int[] coordinates = new int[3];
                        coordinates = crossroads.Peek();
                        ipoint = coordinates[0];
                        jpoint = coordinates[1];
                        movesDone = coordinates[2];
                        crossroads.Pop();
                    }
                }

                if (possibleWays == 0) movePreferred = ' ';

            }
            return pathLength.Min();
        }


        public static int PathGraph(string maze)
        {
            int result = 0; //placeholder
            if (maze == ".") return 0; //edgecase

            //convert string maze to array
            List<string> temp = maze.Split("\n").ToList();
            char[,] mazeArray = new char[temp.Count, temp[0].Length];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[0].Length; j++) mazeArray[i, j] = temp[i][j];
            }

            int ipoint = 0;
            int jpoint = 0;

            bool running = true; //placeholder

            Queue<int[]> coordinates = new Queue<int[]>();
            List<int[]> points = new List<int[]>();
            bool[,] visited = new bool[temp.Count, temp[0].Length]; // false by default


            while (running)
            {

                if (coordinates.Count != 0)
                {
                    int[] cords = coordinates.Peek();
                    ipoint = cords[0];
                    jpoint = cords[1];
                    coordinates.Dequeue();
                }

                //1. lookaround, if w mark as visited, return possible ways
                bool[] directions = PathLookaround(ipoint, jpoint, mazeArray, visited); //returns bool[] NSWE
                //2. add nodes to queue by possible ways, mark point as visited
                if (directions[0] && points.Contains(new int[] { ipoint - 1, jpoint }) == false)
                {
                    mazeArray[ipoint - 1, jpoint] = 'x';
                    coordinates.Enqueue(new int[] { ipoint - 1, jpoint });
                    points.Add(new int[] { ipoint - 1, jpoint });
                } //addnode W
                if (directions[1] && points.Contains(new int[] { ipoint + 1, jpoint }) == false)
                {
                    mazeArray[ipoint + 1, jpoint] = 'x';
                    coordinates.Enqueue(new int[] { ipoint + 1, jpoint });
                    points.Add(new int[] { ipoint + 1, jpoint });
                }
                if (directions[2] && points.Contains(new int[] { ipoint, jpoint - 1 }) == false)
                {
                    mazeArray[ipoint, jpoint - 1] = 'x';
                    coordinates.Enqueue(new int[] { ipoint, jpoint - 1 });
                    points.Add(new int[] { ipoint, jpoint - 1 });
                }
                if (directions[3] && points.Contains(new int[] { ipoint, jpoint + 1 }) == false)
                {
                    mazeArray[ipoint, jpoint + 1] = 'x';
                    coordinates.Enqueue(new int[] { ipoint, jpoint + 1 });
                    points.Add(new int[] { ipoint, jpoint + 1 });
                }
                //3. lookaround through queue
               // coordinates.Dequeue();

                //visualizer

                MathWorks.arrayPrinter(mazeArray);

                if (ipoint == mazeArray.GetLength(0) - 1 && jpoint == mazeArray.GetLength(0) - 1) running = false;

                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"Queue size bottom = {coordinates.Count()}");

            }
            Console.WriteLine("Reached the end here");
            return result;
        }

        private static bool[] PathLookaround(int ipoint, int jpoint, char[,] mazeArray, bool[,] visited)
        {
            bool[] directions = new bool[4]; // N S W E
            int iBoundary = mazeArray.GetLength(0) - 1;
            int jBoundary = mazeArray.GetLength(1) - 1;
            visited[ipoint, jpoint] = true;
            mazeArray[ipoint, jpoint] = '*'; // for visualizer


            if (ipoint - 1 >= 0)
            {
                if (mazeArray[ipoint - 1, jpoint] == '.' && visited[ipoint - 1, jpoint] != true) directions[0] = true;
                if (mazeArray[ipoint - 1, jpoint] == 'W') visited[ipoint - 1, jpoint] = true;
            }

            if (ipoint + 1 <= iBoundary)
            {
                if (mazeArray[ipoint + 1, jpoint] == '.' && visited[ipoint + 1, jpoint] != true) directions[1] = true;
                if (mazeArray[ipoint + 1, jpoint] == 'W') visited[ipoint + 1, jpoint] = true;
            }

            if (jpoint - 1 >= 0)
            {
                if (mazeArray[ipoint, jpoint - 1] == '.' && visited[ipoint, jpoint - 1] != true) directions[2] = true;
                if (mazeArray[ipoint, jpoint - 1] == 'W') visited[ipoint, jpoint - 1] = true;
            }

            if (jpoint + 1 <= jBoundary)
            {
                if (mazeArray[ipoint, jpoint + 1] == '.' && visited[ipoint, jpoint + 1] != true) directions[3] = true;
                if (mazeArray[ipoint, jpoint + 1] == 'W') visited[ipoint, jpoint + 1] = true;
            }

            return directions;
        }


        #region         // Factorials 4kyu
        // https://www.codewars.com/kata/557f6437bf8dcdd135000010
        public static string Factorial(int n) // simple formula to test, numbers are quickly too big to be stored in number types
        {                                      // anything bigger than n=12 will overflow int max value 2147483647
            int factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
          
            return factorial.ToString();
        }
        public static string Factorial2(int n) 
                                               
        {   
            if (n < 0) return "";

            //Calculte array size with stirlings formula
            int computingArraySize = (int)Math.Ceiling(((Math.Log(2 * Math.PI) / 2 + Math.Log(n) / 2 + n * Math.Log(n) - n) / Math.Log(10)));
            int[] resultArray = new int[computingArraySize];
            // Initialize result array
            resultArray[0] = 1;
            int result_size = 1;

            //Multiply consecutive numbers starting from 2 to n
            for (int x = 2; x <= n; x++)
            {
                result_size = multiply(x, resultArray, result_size);
            }          
            //parse result from array to string, number by number in reverse order
            string resultatAsString = "";            
            for (int i = result_size - 1; i >= 0; i--)
            {     
                resultatAsString += resultArray[i].ToString();
            }
            //string tempTest = String.Join("", resultArray.Reverse()); is it faster?
            //Console.WriteLine(tempTest);


            return resultatAsString;
        }

        static int multiply(int x, int[] resultArray, int res_size) // multiply x * resultArray elementary school style, return result length
        {            
            int carry = 0;
            for (int i = 0; i < res_size; i++)
            {
                int localMultiplicationResult = resultArray[i] * x + carry;
                resultArray[i] = localMultiplicationResult % 10; // Store last digit of localMultiplication result in resultArray, put rest in carry                                    
                carry = localMultiplicationResult / 10; 
            }
            // Put carry in res and increase result size
            while (carry != 0)
            {
                resultArray[res_size] = carry % 10;
                carry = carry / 10;
                res_size++;
            }
            return res_size;
        }

        #endregion

        #region        //Human Readable format 4 kyu
        //https://www.codewars.com/kata/52742f58faf5485cae000b9a
        public static string secondsToDate(int seconds)
        {
            List<string> listOfTime = new List<string>();

            //calculate phase
            if (seconds >= 31536000) //calculate years
            {
                int y = seconds / 31536000;
                seconds = seconds - (y * 31536000);

                if (y == 1) listOfTime.Add($"{y} year");
                if (y > 1) listOfTime.Add($"{y} years");
            }

            if (seconds >= 86400) //calculate days
            {
                int d = seconds / 86400;
                seconds = seconds - (d * 86400);

                if (d == 1) listOfTime.Add($"{d} day");
                if (d > 1) listOfTime.Add($"{d} days");

            }

            if (seconds >= 3600) //calculate hours
            {
                int h = seconds / 3600;
                seconds = seconds - (h * 3600);

                if (h == 1) listOfTime.Add($"{h} hour");
                if (h > 1) listOfTime.Add($"{h} hours");

            }

            if (seconds >= 60) //calculate minutes
            {
                int m = seconds / 60;
                seconds = seconds - (m * 60);

                if (m == 1) listOfTime.Add($"{m} minute");
                if (m > 1) listOfTime.Add($"{m} minutes");

            }

            if (seconds > 0) //calculate seconds
            {
                if (seconds == 1) listOfTime.Add($"{seconds} second");
                if (seconds > 1) listOfTime.Add($"{seconds} seconds");

            }

            //concatenation and output
            string result = "";
            if (listOfTime.Count() == 0) result = "now";
            if (listOfTime.Count() == 1) result = $"{listOfTime[0]}";
            if (listOfTime.Count() == 2) result = $"{listOfTime[0]} and {listOfTime[1]}";
            if (listOfTime.Count() == 3) result = $"{listOfTime[0]}, {listOfTime[1]} and {listOfTime[2]}";
            if (listOfTime.Count() == 4) result = $"{listOfTime[0]}, {listOfTime[1]}, {listOfTime[2]} and {listOfTime[3]}";
            if (listOfTime.Count() == 5) result = $"{listOfTime[0]}, {listOfTime[1]}, {listOfTime[2]}, {listOfTime[3]} and {listOfTime[4]}";

            return result;
        }

        #endregion

        #region        //Roman Numerals Helper 4kyu
        //https://www.codewars.com/kata/51b66044bce5799a7f000003/solutions/csharp
        public static string ArabicToRoman(int n)
        {
            string result = "";

            while (n >= 1000)
            {
                if (n >= 1000)
                {
                    result += "M";
                    n -= 1000;
                }
            }

            if (n >= 900)
            {
                result += "CM";
                n -= 900;
            }


            if (n >= 500)
            {
                result += "D";
                n -= 500;
            }

            if (n >= 400)
            {
                result += "CD";
                n -= 400;
            }


            while (n >= 100)
            {
                if (n >= 100)
                {
                    result += "C";
                    n -= 100;
                }
            }

            if (n >= 90)
            {
                result += "XC";
                n -= 90;
            }


            if (n >= 50)
            {
                result += "L";
                n -= 50;
            }

            if (n >= 40)
            {
                result += "XL";
                n -= 40;
            }

            while (n >= 10)
            {
                if (n >= 10)
                {
                    result += "X";
                    n -= 10;
                }
            }

            if (n >= 9)
            {
                result += "IX";
                n -= 9;
            }


            if (n >= 5)
            {
                result += "V";
                n -= 5;
            }

            if (n >= 4)
            {
                result += "IV";
                n -= 4;
            }

            while (n >= 1)
            {
                if (n >= 1)
                {
                    result += "I";
                    n -= 1;
                }
            }

            return result;
        }

        public static int RomanToArabic(string romanNumeral)
        {
            int result = 0;

            if (romanNumeral.Contains("CM"))
            {
                romanNumeral = romanNumeral.Replace("CM", string.Empty);
                result += 900;
            }

            if (romanNumeral.Contains("CD"))
            {
                romanNumeral = romanNumeral.Replace("CD", string.Empty);
                result += 400;
            }

            if (romanNumeral.Contains("XC"))
            {
                romanNumeral = romanNumeral.Replace("XC", string.Empty);
                result += 90;
            }

            if (romanNumeral.Contains("XL"))
            {
                romanNumeral = romanNumeral.Replace("XL", string.Empty);
                result += 40;
            }

            if (romanNumeral.Contains("IX"))
            {
                romanNumeral = romanNumeral.Replace("IX", string.Empty);
                result += 9;
            }

            if (romanNumeral.Contains("IV"))
            {
                romanNumeral = romanNumeral.Replace("IV", string.Empty);
                result += 4;
            }

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                if (romanNumeral[i] == 'M') result += 1000;
                if (romanNumeral[i] == 'D') result += 500;
                if (romanNumeral[i] == 'C') result += 100;
                if (romanNumeral[i] == 'L') result += 50;
                if (romanNumeral[i] == 'X') result += 10;
                if (romanNumeral[i] == 'V') result += 5;
                if (romanNumeral[i] == 'I') result += 1;

            }

            return result;

        }

        #endregion

        #region        //Decode the morse code - advanced 4kyu
        //https://www.codewars.com/kata/54b72c16cd7f5154e9000457
        public static string morseDecoderFromImpulses(string bits) //decodeBits take 0 and 1, return dots and dashes          
        {
            int tempMultiplier = 0;
            int multiplier = 0;

            bits = bits.Trim('0');
            if (bits.Contains("0"))
            {

                for (int i = 0; i < bits.Length; i++)
                {
                    if (bits[i] == '1')
                    {
                        tempMultiplier++;
                    }
                    else
                    {
                        tempMultiplier = 0;
                    }
                    if (tempMultiplier > multiplier) multiplier = tempMultiplier;

                }

                if (multiplier % 3 == 0)
                {
                    if (bits.Contains(new string('0', multiplier)) == false)
                        multiplier = multiplier / 3;
                }

            }
            else multiplier = bits.Length;
            string morseDot = new string('1', multiplier);
            string morseDash = new string('1', 3 * multiplier);
            string morsePause = new string('0', multiplier);
            string morseLongPause = new string('0', 3 * multiplier);
            string morseLongPauseBetweenWords = new string('0', 7 * multiplier);

            string result = bits.Replace(morseDash, "-").Replace(morseDot, ".").Replace(morseLongPauseBetweenWords, "       ").Replace(morseLongPause, "   ").Replace(morsePause, " ");
            Console.WriteLine(bits);
            Console.WriteLine(result);
            return bits;
        }

        #endregion


    }


}
