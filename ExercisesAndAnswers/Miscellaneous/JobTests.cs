using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Miscellaneous
{
    internal class JobTests
    {
        static int GetLongest(List<bool> values)
        {
            int currentLength = 0;
            int sequenceLength = 0;
            foreach (bool item in values)
            {
                if (item) currentLength++;
                else currentLength = 0;
                if (currentLength > sequenceLength) sequenceLength = currentLength;
            }
            return sequenceLength;
        }

        

        

    }
}
