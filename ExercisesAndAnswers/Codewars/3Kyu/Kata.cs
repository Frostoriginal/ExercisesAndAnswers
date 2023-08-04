using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers._3Kyu
{
    public class Kata
    {
        public static void arrayPrinter(int[,] array) //Getlength(0) -> j(rows), (1)- i(columns) array[rows,columns]
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

        // Battleship field validator
        // https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7
        public static bool BattleshipValidator(int[,] battlefield)
        {
            bool result = false;
            //1st check - sum of all
            /*
            int battlefieldSum = 0;
            foreach (var item in battlefied)
            {
                if (item == 1) battlefieldSum++;
            }
            if (battlefieldSum != 20) return false;
            */
            //check only right and down, boundary check
            // single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1).
            int battleship = 0; // size 4, should be 1
            int cruiser = 0; // size 3, should be 2
            int destroyer = 0; // size 2, should be 3
            int submarine = 0; // size 1, should be 1

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (battlefield[i,j] == 1)
                    {
                        battlefield[i,j] = 5;
                        bool running = true;
                        int size = 1;
                        int locali = i;
                        int localj = j;
                        while (running && locali <9 && localj<9)
                        {
                            if ( battlefield[locali + 1, localj] == 1 && battlefield[locali, localj + 1] == 1) return false;
                            if (battlefield[locali + 1, localj + 1] == 1) return false;
                            if (localj > 0)
                            {
                                if (battlefield[locali + 1, localj - 1] == 1) return false;
                            }
                            if (battlefield[locali + 1, localj] == 1 || battlefield[locali, localj + 1] == 1)
                            {
                                size++;
                                if (battlefield[locali + 1, localj] == 1)
                                {                                    
                                    battlefield[locali + 1, localj] = 5;
                                    locali++;
                                }
                                if (battlefield[locali, localj + 1] == 1)
                                {                                    
                                    battlefield[locali, localj + 1] = 5;
                                    localj++;
                                }
                            }
                            else running = false;
                        }
                        if (size > 4) return false;
                        if (size == 4) battleship++;
                        if (size == 3) cruiser++;
                        if (size == 2) destroyer++;
                        if (size == 1) submarine++;

                    }

                    //arrayPrinter(battlefied);
                    Console.WriteLine($"Battleships:{battleship}, cruisers: {cruiser}, destroyers: {destroyer}, submarines: {submarine}");
                    //System.Threading.Thread.Sleep(1000);
                }

            }
            if (battleship == 1 && cruiser == 2 && destroyer == 3 && submarine == 4) result = true;
            return result;
        }

        //Total Area covered by rectangles 3 kyu
        //https://www.codewars.com/kata/55dcdd2c5a73bdddcb000044

        //Input is 2d array
        public static long TotalArea(int[,] rectangles)
        {
            long totalArea = 0; //variable to count total area
            long totalOverlap = 0; //variable to count total overlap area

            // total area calculation
            for (int i = 0; i < rectangles.GetLength(0); i++)// loop for iterating through rectangles
            {
                totalArea += (rectangles[i, 3] - rectangles[i, 1]) * (rectangles[i, 2] - rectangles[i, 0]);//getting each rectangle area and adding it to total                
            }

            //overlap area calculation

            for (int i = 0; i < rectangles.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < rectangles.GetLength(0); j++)
                {
                    bool isOverlaping = true;
                    if (rectangles[j, 0] < rectangles[i, 0] && rectangles[j, 2] < rectangles[i, 0] ||
                        rectangles[j, 0] > rectangles[i, 2] && rectangles[j, 2] > rectangles[i, 2]) //if bx0 < ax0 && bx1 < ax0 || bx0 > ax1 && bx1 >ax1
                    {
                        isOverlaping = false;
                    }

                    else if (isOverlaping == true)
                    {
                        int Ox0 = 0;
                        int Ox1 = 0;
                        int Oy0 = 0;
                        int Oy1 = 0;

                        //x axis
                        if (rectangles[j, 0] <= rectangles[i, 0]) Ox0 = rectangles[i, 0]; //bx0 <= ax0, Ox0 = ax0
                        if (rectangles[j, 0] >= rectangles[i, 0]) Ox0 = rectangles[j, 0]; //bx0 >= ax0, Ox0 = bx0
                        if (rectangles[j, 2] <= rectangles[i, 2]) Ox1 = rectangles[j, 2];//bx1 <= ax1, Ox1 = bx1
                        if (rectangles[j, 2] >= rectangles[i, 2]) Ox1 = rectangles[i, 2];//bx1 >= ax1, Ox1 = ax1

                        //y axis
                        if (rectangles[j, 1] <= rectangles[i, 1]) Oy0 = rectangles[i, 1]; //by0 <= ay0, Oy0 = ay0
                        if (rectangles[j, 1] >= rectangles[i, 1]) Oy0 = rectangles[j, 1]; //by0 >= ay0, Oy0 = by0
                        if (rectangles[j, 3] <= rectangles[i, 3]) Oy1 = rectangles[j, 3];//by1 <= ay1, Oy1 = by1
                        if (rectangles[j, 3] >= rectangles[i, 3]) Oy1 = rectangles[i, 3];//by1 >= ay1, Oy1 = ay1

                        totalOverlap += (Ox1 - Ox0) * (Oy1 - Oy0); //adding each overlapping rectangle area to total overlaping area                        
                    }
                }
            }
            totalArea -= totalOverlap;
            return totalArea;
        }

        //Input is list of arrays
        public static long TotalAreaWithIenumerable(IEnumerable<int[]> rectangles) //completed in 22,5120ms, timed out
        {   //possible solution: sweep algorithm: https://www.baeldung.com/cs/find-area-of-overlapping-rectangles
            // https://stackoverflow.com/questions/244452/what-is-an-efficient-algorithm-to-find-area-of-overlapping-rectangles
            // http://codercareer.blogspot.com/2011/12/no-27-area-of-rectangles.html
            //https://tryalgo.org/en/geometry/2016/06/25/union-of-rectangles/
            long totalArea = 0; //variable to count total area
            long totalOverlap = 0; //variable to count total overlap area
                                   // testowanie konwersji na liste
            List<int[]> list = rectangles.ToList<int[]>();
            //Console.WriteLine(list[0][1]);





            // total area calculation
            foreach (int[] array in rectangles) totalArea += (array[3] - array[1]) * (array[2] - array[0]);
            //foreach (var rectangle in rectangles) totalArea += (rectangle[3] - rectangle[1]) * (rectangle[2] - rectangle[0]);


            int[,] rArray = new int[rectangles.Count(), 4]; //converting to 2d array                                                            
            int k = 0;
            foreach (int[] array in rectangles)
            {
                rArray[k, 0] = array[0];
                rArray[k, 1] = array[1];
                rArray[k, 2] = array[2];
                rArray[k, 3] = array[3];
                k++;
            }



            //overlap area calculation //to correct, filter out only overlapping, calculate the overlapping area

            for (int i = 0; i < rArray.GetLength(0) - 1; i++) //first rectangle
            {

                for (int j = i + 1; j < rectangles.Count(); j++) // second rectangle
                {
                    // Checking if rectangles are overlapping
                    bool isOverlaping = rArray[j, 0] < rArray[i, 0] && rArray[j, 2] < rArray[i, 0] || rArray[j, 0] > rArray[i, 2] && rArray[j, 2] > rArray[i, 2] ? false : true;

                    if (isOverlaping == true) //if rectangles are overlapping calculate area of overlap and add it to total overlap
                    {
                        int Ox0 = rArray[j, 0] <= rArray[i, 0] ? rArray[i, 0] : rArray[j, 0];
                        int Ox1 = rArray[j, 2] <= rArray[i, 2] ? rArray[j, 2] : rArray[i, 2];
                        int Oy0 = rArray[j, 1] <= rArray[i, 1] ? rArray[i, 1] : rArray[j, 1];
                        int Oy1 = rArray[j, 3] <= rArray[i, 3] ? rArray[j, 3] : rArray[i, 3];

                        totalOverlap += (Ox1 - Ox0) * (Oy1 - Oy0); //adding each overlapping rectangle area to total overlaping area                        
                    }
                }
            }
            totalArea -= totalOverlap;
            return totalArea;
        }



        public static long TotalAreaWithLine(IEnumerable<int[]> rectangles) //completed in 32,850ms, timed out
        {

            List<Line> listaLini = new List<Line>();

            int totalCalculatedArea = 0;


            foreach (int[] array in rectangles)
            {
                for (int i = array[0]; i < array[2]; i++)
                {
                    listaLini.Add(new Line(i, array[1], array[3]));
                }
            }



            var overlapping =
                from Line in listaLini
                group Line by Line.X into lineGroup
                where lineGroup.Count() > 1
                select lineGroup.ToList<Line>();

            int overlappingLines = 0;
            foreach (var lineGroup in overlapping)
            {
                var EnumerableKeeper = Enumerable.Range(0, 0);

                foreach (var line in lineGroup)
                {
                    IEnumerable<int> ints = Enumerable.Range(line.LowerBound, line.getRangeValue(line));
                    EnumerableKeeper = EnumerableKeeper.Concat(ints);
                    listaLini.Remove(line);
                }

                overlappingLines += EnumerableKeeper.Distinct().Count();
            }

            int nonOverlappingLines = 0;
            /*
             var nonoverlapping =
                  from Line in listaLini
                  group Line by Line.X into lineGroupNonOverlap
                  where lineGroupNonOverlap.Count() == 1
                  select lineGroupNonOverlap.ToList<Line>();
             

             foreach (var lineGroupNonOverlap in nonoverlapping)
             {
                 foreach (var line in lineGroupNonOverlap)
                 {
                     nonOverlappingLines += Enumerable.Range(line.LowerBound, line.getRangeValue(line)).Count();
                 }
             }
            */
            foreach (var line in listaLini)
            {
                nonOverlappingLines += Enumerable.Range(line.LowerBound, line.getRangeValue(line)).Count();
            }

            totalCalculatedArea = nonOverlappingLines + overlappingLines;

            return totalCalculatedArea;

        }

        public class Line : IComparable<Line>
        {
            public int X { get; set; }
            public int LowerBound { get; set; }
            public int UpperBound { get; set; }
            int range = 0;

            public Line(int x, int lowerBound, int upperBound)
            {
                this.X = x;
                this.LowerBound = lowerBound;
                this.UpperBound = upperBound;

                range = upperBound - lowerBound;

            }

            public int getRangeValue(Line line) => line.UpperBound - line.LowerBound;


            public int CompareTo(Line other)
            {
                return new LineComparerByXValue().Compare(this, other);
            }
        }

        class LineComparerByXValue : IComparer<Line>
        {
            public int Compare(Line x, Line y)
            {
                if (x.X < y.X)
                    return -1;
                if (x.X > y.X)
                    return 1;
                return 0;
            }
        }

        //Binomial Expansion 3kyu
        //https://www.codewars.com/kata/540d0fdd3b6532e5c3000b5b
        public static string Expand(string expr)
        {
            string result = "";
            string[] array = expr.Split('^');
            int.TryParse(array[1], out int power);

            if (power == 0) result = "1"; // edge case
            else
            {

                int aSign = 1;
                int bSign = 1;
                char splitSign = '+';
                expr = array[0].Trim('(', ')');
                if (expr.Count(c => c == '-') == 1 && expr[0] == '-')
                {
                    aSign = -1;
                    expr = expr.Trim('-');

                }
                if (expr.Count(c => c == '-') == 1 && expr[0] != '-')
                {
                    bSign = -1;
                    splitSign = '-';
                }
                if (expr.Count(c => c == '-') == 2)
                {
                    aSign = -1;
                    bSign = -1;
                    splitSign = '-';
                    expr = expr.Trim('-');
                }

                array = expr.Split(splitSign);
                int.TryParse(array[1], out int b);
                char theVariable = 'x';
                char[] equation = array[0].ToCharArray();
                for (int i = 0; i < equation.Length; i++)
                {
                    if (char.IsLetter(equation[i])) theVariable = equation[i];
                }

                int.TryParse(new string(array[0].Where(c => (Char.IsDigit(c) || c == '-')).ToArray()), out int multiplier);
                if (multiplier == 0) multiplier++;
                if (aSign == -1) multiplier *= -1;
                List<string> toJoin = new List<string>();

                for (int i = 0; i < power; i++)
                {
                    double coeficient = BinomialCoefficient(power, i) * Math.Pow(multiplier, (power - i)) * Math.Pow(b * bSign, i);
                    Console.WriteLine(coeficient);
                    if (toJoin.Count > 0 && coeficient != 0)
                    {
                        if (coeficient > 0) toJoin.Add("+");
                    }

                    if (coeficient == 1)
                    {
                        if (power - i == 1) toJoin.Add($"{theVariable}");
                        if (power - i > 1) toJoin.Add($"{theVariable}^{power - i}");
                    }

                    if (coeficient != 1 && coeficient != 0)
                    {
                        if (coeficient == -1) toJoin.Add($"-{theVariable}^{power - i}");
                        if (power - i == 1) toJoin.Add($"{coeficient}{theVariable}");
                        if ((power - i) % 2 == 0 && power - i != 0 && power - i != 1) toJoin.Add($"{coeficient}{theVariable}^{power - i}");
                        if ((power - i) % 2 != 0 && power - i != 0 && power - i != 1 && coeficient != -1) toJoin.Add($"{coeficient}{theVariable}^{power - i}");
                    }
                }

                if (Math.Pow(b, power) != 0)
                {
                    double last = ((Math.Pow(b * bSign, power)));
                    if (last > 0) toJoin.Add($"+{last}");
                    else toJoin.Add(last.ToString());

                }

                result = string.Join("", toJoin);

            }

            return result;
        }

        //Method for Coefficient calculation
        public static double BinomialCoefficient(int n, int k)
        {
            if (k > n) return 0;
            if (k > n - k) k = n - k;

            double val = 1;
            for (int rk = 1, rn = n - k + 1; rk <= k; ++rk, ++rn)
            {
                val = (rn) * val / (rk);
            }
            return val;
        }

        //rail fence cipher 3kyu
        //https://www.codewars.com/kata/58c5577d61aefcf3ff000081    
        public static string fenceCipherEncode(string s, int n)
        {
            string result = "";
            if (s != null)
            {
                char[,] chars = new char[n, s.Length];
                int j = 0;
                int sign = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    chars[j, i] = s[i];

                    if (j == n - 1) sign = -1;
                    if (j == 0) sign = 1;
                    j += sign;

                }


                foreach (var item in chars)
                {
                    if (item != 0) result += item;
                }

            }
            return result;
        }

        public static string fenceCipherDecode(string s, int fence)
        {
            char[,] chars = new char[fence, s.Length]; //[rows,columns]
            int k = 0;
            int step = fence + 1;
            for (int j = 0; j < fence; j++)
            {
                for (int i = j; i < s.Length - 1; i += step)
                {
                    chars[j, i] = s[k];
                    k++;
                }
                if (j % 2 != 0) step = fence + 1;
                if (j % 2 == 0) step = fence - 1;
            }
            string result = "";

            int sign = 1;
            int l = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //chars[l, i] = s[i];
                result += chars[l, i];

                if (l == fence - 1) sign = -1;
                if (l == 0) sign = 1;
                l += sign;

            }
            //another approach - mark down fence with *, change each * with value

            return result;
        }

        public static string fenceCipherDecodeWithFenceMark(string s, int n)
        {
            string result = "";
            if (s != null)
            {
                char[,] chars = new char[n, s.Length]; //[rows,columns]
                                                       //draw fence
                int m = 0;
                int sign = 1;
                for (int i = 0; i < s.Length; i++)
                {
                    chars[m, i] = '*';

                    if (m == n - 1) sign = -1;
                    if (m == 0) sign = 1;
                    m += sign;

                }
                //fill with characters
                int k = 0;
                for (int j = 0; j < n; j++)
                {
                    for (int i = j; i < s.Length; i++)
                    {
                        if (chars[j, i] == '*')
                        {
                            chars[j, i] = s[k];
                            k++;
                        }
                    }
                }
                //read


                int lastSign = 1;
                int l = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    //chars[l, i] = s[i];
                    result += chars[l, i];

                    if (l == n - 1) lastSign = -1;
                    if (l == 0) lastSign = 1;
                    l += lastSign;

                }
                //another approach - mark down fence with *, change each * with value
            }
            return result;
        }

        //Do not loose at tic-tac-toe!
        //https://www.codewars.com/kata/57bc5e0471f2ff9233000005/train/csharp

        // tactic
        //1. always go for corner
        //2. if any corner is marked by other player go for center, if not go for corner
        // idea - swith to bool array?
        
        public static int[] TurnMethod(int[][] board, int player)
        {
            //initialize player sides
            int opponent;
            if (player == 1) opponent = 2;
            else opponent = 1;
            //check for center 
            if (board[1][1]==0) return new int[] { 1,1};

            #region check if there is need to block other player
            //check for block
            //rows
            for (int i = 0; i < 3; i++)
            {                
                string currentRow = $"{board[i][0]}{board[i][1]}{board[i][2]}";
                Console.WriteLine(currentRow);
                if (currentRow == $"0{opponent}{opponent}") return new int[] { i, 0 };
                if (currentRow == $"{opponent}0{opponent}") return new int[] { i, 1 };
                if (currentRow == $"{opponent}{opponent}0") return new int[] { i, 2 };
            }

            //columns
            for (int i = 0; i < 3; i++)
            {
                string currentRow = $"{board[0][i]}{board[1][i]}{board[2][i]}";
                if (currentRow == $"0{opponent}{opponent}") return new int[] { 0, i };
                if (currentRow == $"{opponent}0{opponent}") return new int[] { 1, i };
                if (currentRow == $"{opponent}{opponent}0") return new int[] { 2, i };
            }

            //slanted
            string backSlash = $"{board[0][0]}{board[1][1]}{board[2][2]}";
            if (backSlash == $"0{opponent}{opponent}") return new int[] { 0, 0 };
            if (backSlash == $"{opponent}0{opponent}") return new int[] { 1, 1 };
            if (backSlash == $"{opponent}{opponent}0") return new int[] { 2, 2 };

            string slash = $"{board[2][0]}{board[1][1]}{board[0][2]}";
            if (slash == $"0{opponent}{opponent}") return new int[] { 2, 0 };
            if (slash == $"{opponent}0{opponent}") return new int[] { 1, 1 };
            if (slash == $"{opponent}{opponent}0") return new int[] { 0, 2 };

            //go for corners
            if (board[0][0] == 0) return new int[] { 0, 0 };
            if (board[2][0] == 0) return new int[] { 2, 0 };
            if (board[0][2] == 0) return new int[] { 0, 2 };
            if (board[2][2] == 0) return new int[] { 2, 2 };

            //block adjacent
            //1st row
            if (board[0][0] == opponent && board[0][1] == 0) return new int[] { 0, 1 };
            if (board[0][0] == opponent && board[1][0] == 0) return new int[] { 1, 0 };

            if (board[1][0] == opponent && board[0][0] == 0) return new int[] { 0, 0 };
            if (board[1][0] == opponent && board[2][0] == 0) return new int[] { 2, 0 };

            if (board[2][0] == opponent && board[1][0] == 0) return new int[] { 1, 0 };
            if (board[2][0] == opponent && board[2][1] == 0) return new int[] { 2, 1 };

            //2nd row
            if (board[0][1] == opponent && board[0][0] == 0) return new int[] { 0, 0 };
            if (board[0][1] == opponent && board[0][2] == 0) return new int[] { 0, 2 };
            if (board[2][1] == opponent && board[2][0] == 0) return new int[] { 2, 0 };
            if (board[2][1] == opponent && board[2][2] == 0) return new int[] { 2, 2 };


            //center
            if (board[1][1] == opponent && board[0][1] == 0) return new int[] { 0, 1 };
            if (board[1][1] == opponent && board[1][0] == 0) return new int[] { 1, 0 };
            if (board[1][1] == opponent && board[2][1] == 0) return new int[] { 2, 1 };
            if (board[1][1] == opponent && board[1][2] == 0) return new int[] { 1, 2 };

            //3rd row
            if (board[0][2] == opponent && board[0][1] == 0) return new int[] { 0, 1 };
            if (board[0][2] == opponent && board[1][2] == 0) return new int[] { 1, 2 };

            if (board[1][2] == opponent && board[0][2] == 0) return new int[] { 0, 2 };
            if (board[1][2] == opponent && board[2][2] == 0) return new int[] { 2, 2 };

            if (board[2][2] == opponent && board[1][2] == 0) return new int[] { 1, 2 };
            if (board[2][2] == opponent && board[2][1] == 0) return new int[] { 2, 1 };



            #endregion

            // just mark the rest
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == 0) return new int[] { i, j };
                }

            }

            return null;
        }


        public static int LastDigit(int[] array)
        {
            //1. Corner cases
            if (array is null || array.Length == 0) return 1;            
            if (array[0] == 0 && array[1] == 0 && array.Length == 2)  return 1;
            if (array.Length == 1) return array[0].ToString().Last() - 48;

            //2. Check first number
            int baseOfNumber = array[0].ToString().Last() - 48;
            if (array.Length == 2 && array[0] != 0 && array[1] == 0) return 1;
            if (baseOfNumber == 0 || baseOfNumber == 1 || baseOfNumber == 5 || baseOfNumber == 6) return baseOfNumber;

            //3. simplify the array
            int[] simplified = new int[array.Length];
            for (int i = array.Length-1; i >= 0; i--)
            {
                if(i == 0) simplified[i] = baseOfNumber;
                else
                {
                    simplified[i] = array[i] % 40;
                    if (simplified[i] == 0 && array[i] != 0) simplified[i] = 40;
                    if (simplified[i] == 1) simplified[i] = array[i];
                    

                }
            }
            
            //4. calculate
            for (int i = simplified.Length-2; i >= 0; i--)
            {
                if (i == 0) return (int)BigInteger.ModPow(simplified[0], simplified[1], 10);
                if (simplified[i] == 0 && simplified[i+1] ==0) simplified[i] = 1;
                else 
                { 
                int simplifiedNumber = (int)BigInteger.ModPow(simplified[i], simplified[i + 1], 40);
                    Console.WriteLine($"Here is simplified number: {simplifiedNumber}");
                    if (simplifiedNumber == 0 && simplified[i] != 0) simplifiedNumber = 40;
                if(simplifiedNumber == 1 && simplified[i+1] == 0) simplified[i] = 1;
                if(simplifiedNumber != 1 && simplified[i+1] != 0) simplified[i] = simplifiedNumber;
                if(simplifiedNumber == 1 && i == 1) simplified[i] = 1;
                }

                Console.WriteLine("Current array");
                foreach (int num in simplified)
                {
                    Console.Write($"{num}, ");
                }
            }

            /*

            BigInteger n2 = BigInteger.Pow(array[array.Length-2],array.Length-1);
            //int baseOfNumber = array[0].ToString().Last() - 48;
            if (baseOfNumber == 0 || baseOfNumber == 1 || baseOfNumber == 5 || baseOfNumber == 6 || n2 == 1) return baseOfNumber;
            else
            {
                //int lastNumberOfBase = baseOfNumber.ToString().Last() - 48;
                Console.WriteLine($"Base number {baseOfNumber}, last number of base");

                BigInteger exponential = 0;
                exponential = BigInteger.Pow(array[array.Length - 2], array[array.Length - 1]);

                int exponentialModulo = 0;

                if (array.Length > 3)
                {
                    for (int i = array.Length - 1; i > 0; i--)
                    {
                        BigInteger a = BigInteger.Pow(array[i - 1], array[i]);
                        n2 = Power(a, n2);
                        Console.WriteLine($"Current number {n2}");
                    }
                }
                if (exponential > 10)
                {
                    string s = exponential.ToString();
                    int.TryParse(s.Substring(s.Length - 2, 2), out int lastTwoDigits);
                    exponentialModulo = lastTwoDigits % 4;
                    if (exponentialModulo == 0) exponentialModulo = 4;
                }
                else
                {
                    exponentialModulo = (int)exponential % 4;
                }
                int result = (int)Math.Pow(baseOfNumber, exponentialModulo);
                if (result > 9)
                {
                    string temp = result.ToString();
                    result = (int)temp.Last() - 48;
                }
                int dssd = 0;
                return result;
            }

            */
            return 0;

        }
        public static BigInteger Power(BigInteger value, BigInteger exponent)
        {
            BigInteger originalValue = value;
            while (exponent-- > 1)
                value = BigInteger.Multiply(value, originalValue);
            return value;
        }



    }

}
