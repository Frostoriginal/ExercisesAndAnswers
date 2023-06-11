using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace ExercisesAndAnswers
{
    
    public class MathWorks
    {
        
        
       //Converting Ienumerable int[] arrays into one int[,] 2d array
        public static int[,] SwitchMatrix(IEnumerable<int[]> rectangles)
        {
            int[,] rectanglesArray = new int[rectangles.Count(), 4];

            int i = 0;
            foreach (int[] array in rectangles)
            {
                rectanglesArray[i, 0] = array[0];
                rectanglesArray[i, 1] = array[1];
                rectanglesArray[i, 2] = array[2];
                rectanglesArray[i, 3] = array[3];
                i++;
            }

            return rectanglesArray;
        }

        ///: Print all positive integer solutions to the equation a3 + b3=c3+d3 and d are integers between 1 and 1000. 

        public static void positiveIntegers(int n)
        {
            
            for (int a = 1; a < n; a++)
            {
                for (int b = 1; b < n; b++)
                {
                    for (int c = 1; c < n; c++)
                    {
                        //double beforeRoot = Math.Pow(a, 3) + Math.Pow(b, 3) - Math.Pow(c, 3);                                          

                        //int d = (int)Math.Pow(beforeRoot, (1.0/3.0));





                        for (int d = 1; d < n; d++)
                                 {
                        if (Math.Pow(a, 3) + Math.Pow(b, 3) == Math.Pow(c, 3) + Math.Pow(d, 3))
                        {
                            Console.WriteLine($"{a}^3 + {b}^3 = {c}^3 + {d}^3");
                        }
                                }

                    }
                }
            }

        }


        
        

       

       

       

        public static void arrayPrinter(char[,] array) //Getlength(0) -> j(rows), (1)- i(columns) array[rows,columns]
        {            
            Console.Clear();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row += $" {array[i, j]} ";
                }
                Console.WriteLine(row);               
            }
        }


       
        

        // Path Finder #2: shortest path
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

                if (ipoint - 1 > 0 && lastMove !='S')
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
                { if (movePreferred == ' ' || movePreferred == 'S')
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
                arrayPrinter(mazeArray);
                Console.WriteLine($"moves done: {movesDone}");
                Console.WriteLine($"Last move = {lastMove}");
                Console.WriteLine($"Move preferred = {movePreferred}");

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

                if(possibleWays == 0 ) movePreferred = ' ';

            }
            return pathLength.Min();
        }
    }
}
