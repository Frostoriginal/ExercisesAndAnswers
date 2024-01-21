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

        #region ProductExeptSelf
        [Fact]
        public void ProductExeptSelfTest0()
        {
            int[] nums = { 1, 2, 3, 4 };
            int[] output = { 24,12,8,6};

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.ProductExceptSelf3(nums));

        }

        [Fact]
        public void ProductExeptSelfTest1()
        {
            int[] nums = { -1, 1, 0, -3, 3 };
            int[] output = {0,0,9,0,0};

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.ProductExceptSelf3(nums));

        }

        [Fact]
        public void ProductExeptSelfTest2()
        {
            int[] nums = { 2, 3, 5, 0 };
            int[] output = { 0, 0, 0, 30 };

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.ProductExceptSelf3(nums));

        }
        #endregion

        #region MaxSubArray
        [Fact]
        public void MaxSubArrayTest0()
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int output = 6;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxSubArray(nums));

        }

        [Fact]
        public void MaxSubArrayTest1()
        {
            int[] nums = { 1 };
            int output = 1;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxSubArray(nums));

        }

        [Fact]
        public void MaxSubArrayTest2()
        {
            int[] nums = { 5, 4, -1, 7, 8 };
            int output = 23;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxSubArray(nums));

        }



        #endregion

        #region MaxProduct
        [Fact]
        public void MaxProductTest0()
        {
            int[] nums = { 2, 3, -2, 4 };
            int output = 6;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxProduct(nums));

        }

        [Fact]
        public void MaxProductTest1()
        {
            int[] nums = { -2, 0, -1 };
            int output = 0;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxProduct(nums));

        }

        [Fact]
        public void MaxProductTest2()
        {
            int[] nums = { -2, 3, -4 };
            int output = 24;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxProduct(nums));

        }

        [Fact]
        public void MaxProductTest3()
        {
            int[] nums = { 2, -5, -2, -4, 3 };
            int output = 24;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxProduct(nums));

        }

        [Fact]
        public void ContainterWithMostWaterTest1()
        {
            int[] nums = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            int output = 49;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxArea(nums));

        }

        [Fact]
        public void ContainterWithMostWaterTest2()
        {
            int[] nums = { 1, 1 };
            int output = 1;

            Assert.Equal(output, ExercisesAndAnswers.Blind75.Blind_Array.MaxArea(nums));

        }

        







        #endregion
    }
}
