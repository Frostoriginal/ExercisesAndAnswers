using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Blind75
{
    public class Blind_Array_Tests
    {
        #region TwoSum
        [Fact]
        public void TwoSumTest0()
        {
            int[] nums = {2,7,11,15};
            int target = 9;
            int[] expected = {0,1};
            int[] result = ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target);

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target),expected);
            
        }

        [Fact]
        public void TwoSumTest1()
        {
            int[] nums = { 3, 2, 4 };
            int target = 6;
            int[] expected = { 1, 2 };
            int[] result = ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target);

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target), expected);

        }

        [Fact]
        public void TwoSumTest2()
        {
            int[] nums = { 3, 3 };
            int target = 6;
            int[] expected = { 0, 1 };
            int[] result = ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target);

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.TwoSum(nums, target), expected);

        }

        #endregion

        #region MaxProfit
        [Fact]
        public void MaxProfitTest0()
        {
            int[] prices = { 7,1,5,3,6,4 };
            int output = 5;
            
            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.MaxProfit(prices), output);

        }

        [Fact]
        public void MaxProfitTest1()
        {
            int[] prices = { 7,6,4,3,1 };
            int output = 0;

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.MaxProfit(prices), output);

        }

        #endregion

        #region ContainsDuplicate
        [Fact]
        public void ContainsDuplicateTest0()
        {
            int[] nums = { 1,2,3,1 };
            bool output = true;

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.ContainsDuplicate2(nums), output);

        }

        [Fact]
        public void ContainsDuplicateTest1()
        {
            int[] nums = { 1, 2, 3, 4 };
            bool output = false;

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.ContainsDuplicate2(nums), output);

        }

        [Fact]
        public void ContainsDuplicateTest2()
        {
            int[] nums = { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            bool output = true;

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.ContainsDuplicate2(nums), output);

        }

        #endregion

        #region FindMin
        [Fact]
        public void FindMinTest0()
        {
            int[] nums = { 3, 4, 5, 1, 2 };
            int output = 1;

            Assert.Equal(ExercisesAndAnswers.Blind75.Blind_Array.FindMin(nums), output);

        }
        #endregion
    }
}
