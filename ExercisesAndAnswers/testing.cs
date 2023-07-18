using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers
{
     class testing
    {
        

    }

    //memoization example
    public static class Memoizer
    {
        public static Func<TInput, TResult> Memoize <TInput, TResult>(this Func<TInput,TResult> func)
        {
            //create cache memo
            var memo = new Dictionary<TInput, TResult>();
            return input =>
            {
                if (memo.TryGetValue(input, out var fromMemo))
                    return fromMemo; //if yes return value
                // if no call function
                var result = func(input);
                //cache the result
                memo.Add(input, result);
                return result;
            };
        }
    }
}
