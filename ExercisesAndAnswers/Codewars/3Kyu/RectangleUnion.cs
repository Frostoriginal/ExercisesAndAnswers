using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Codewars._3Kyu
{
    public class RectangleUnion //fail, timeout 
    {
        public static long TotalAreaWithLineAndDictionary(IEnumerable<int[]> rectangles)
        {
            long result = 0;
            Dictionary<int, line> lineDictionary = new();

            foreach (int[] rectangle in rectangles)
            {
                for (int i = rectangle[0]; i < rectangle[2]; i++)
                {
                    if (lineDictionary.ContainsKey(i))
                    {
                        lineDictionary[i].addLine(rectangle[1], rectangle[3]);
                    }
                    else
                    {
                        lineDictionary.Add(i, new line(rectangle[1], rectangle[3]));
                    }
                }
            }
            
            
            foreach (KeyValuePair<int,line> currentLine in lineDictionary)
            {
                result += currentLine.Value.lineSum;
            }            
            return result;
        }

        public static long RectangleArea(IEnumerable<int[]> rectangles)
        {
            HashSet<int> xv = new HashSet<int>();
            HashSet<int> yv = new HashSet<int>();
            foreach (int[] rec in rectangles)
            {
                xv.Add(rec[0]);
                xv.Add(rec[2]);
                yv.Add(rec[1]);
                yv.Add(rec[3]);
            }

            int[] imapx = xv.ToArray();
            int[] imapy = yv.ToArray();
            Array.Sort(imapx);
            Array.Sort(imapy);

            Dictionary<int, int> dx = new Dictionary<int, int>();
            for (int i = 0; i < imapx.Length; ++i)
            {
                dx[imapx[i]] = i;
            }

            Dictionary<int, int> dy = new Dictionary<int, int>();
            for (int i = 0; i < imapy.Length; ++i)
            {
                dy[imapy[i]] = i;
            }

            bool[][] g = new bool[imapx.Length][];
            for (int i = 0; i < imapx.Length; ++i) g[i] = new bool[imapy.Length];

            foreach (int[] rec in rectangles)
            {
                for (int x = dx[rec[0]]; x < dx[rec[2]]; ++x)
                {
                    for (int y = dy[rec[1]]; y < dy[rec[3]]; ++y)
                    {
                        g[x][y] = true;
                    }
                }
            }

            long area = 0;
            for (int x = 0; x < g.Length; ++x)
            {
                for (int y = 0; y < g[x].Length; ++y)
                {
                    if (g[x][y])
                    {
                        area += (long)(imapx[x + 1] - imapx[x]) * (imapy[y + 1] - imapy[y]);
                    }
                }
            }
            int xuz = 0;
            return area;// (int)(area % 1000000007);
        }

    }

    public class line
    {
        public int lineSum { get; set; }
        public List<int[]> ranges { get; set; } = new();

        public line(int startRange, int endRange)
        {
            ranges.Add(new int[] { startRange, endRange });
            int[] temp = ranges[0];
            lineSum = temp[1] - temp[0];
        }

        public void addLine(int startRange, int endRange)
        {
            List<int[]> rangesTemporary = new();
            //check for union
            foreach (int[] item in ranges)
            {   //1. item inside new line, update item to new length
                if (startRange < item[0] && endRange > item[1])
                {
                    item[0] = startRange;
                    item[1] = endRange;
                }

                //2. new line inside item
                //if (startRange > item[0] && endRange< item[1]) // do nothing

                //overlapping lower bound
                if (item[0] >= startRange && item[0] <= endRange)
                {
                    item[0] = startRange;
                }
                //overlapping upper bound
                if (item[0] <= startRange && item[1] >= startRange)
                {
                    item[1] = endRange;
                }
                //non overlapping
                if (startRange > item[1] || endRange < item[0]) rangesTemporary.Add(new int[] { startRange, endRange });

            }
            ranges.AddRange(rangesTemporary);
            //update lineSum value
            lineSum = 0;
            foreach (int[] item in ranges)
            {
                lineSum += item[1] - item[0];
            }
        }


        

    }
}
