using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Blind75
{
    public class Blind_Array
    {
        #region Two sum
        //https://leetcode.com/problems/two-sum/
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new();
            map.Add(nums[0], 0);

            for (int i = 1; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }

                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }


            }

            return new int[0];
        }
        #endregion

        #region Best time to Buy and Sell Stock
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
        public static int MaxProfit(int[] prices)
        {
            int profit = 0;
            int lowest = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > lowest)
                {
                    if (prices[i] - lowest > profit) profit = prices[i] - lowest;
                }

                else lowest = prices[i];
            }
            return profit;
        }

        #endregion

        #region Contains duplicate
        //https://leetcode.com/problems/contains-duplicate/
        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1]) return true;
            }
            return false;
        }

        public static bool ContainsDuplicate2(int[] nums)
        {
            Dictionary<int, int> map = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i])) return true;
                else map.Add(nums[i], i);
            }
            return false;
        }

        #endregion

        #region Find Minimum in Rotated Sorted Array
        //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/description/
        public static int FindMin(int[] nums)
        {
            int lowest = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < lowest) lowest = nums[i];
            }
            return lowest;
        }

        public int FindMin2(int[] nums)
        {
            int leftHand = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < leftHand) return nums[i];
            }
            return nums[0];
        }

        #endregion

        #region Product of Array Except Self
        //https://leetcode.com/problems/product-of-array-except-self/
        public static int[] ProductExceptSelf(int[] nums) // Time Limit Exceeded
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int product = 1;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j != i) product *= nums[j];
                }
                result[i] = product;

            }

            return result;
        }

        public static int[] ProductExceptSelf2(int[] nums) //wrong answer
        {
            int[] result = new int[nums.Length];
            int lefProduct = 1;
            // int rightProduct = 1;
            for (int i = 0; i < nums.Length; i++)
            {

                int rightProduct = 1; //reset
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (j != nums.Length) rightProduct *= nums[j];
                    if (i > 0) lefProduct *= nums[i - 1];
                }

                if (i == nums.Length - 1) lefProduct *= nums[i - 1];


                if (i == 0)
                {
                    result[i] = rightProduct;
                }
                if (i == nums.Length - 1)
                {
                    result[i] = lefProduct;
                }
                if (i != 0 && i != nums.Length - 1)
                {
                    result[i] = lefProduct * rightProduct;
                }


            }

            return result;
        }

        public static int[] ProductExceptSelf3(int[] nums)
        {
            int[] result = new int[nums.Length];
            int[] leftProductArr = new int[nums.Length];
            int[] rightProductArr = new int[nums.Length];

            int leftProduct = 1;
            leftProductArr[0] = 1;
            rightProductArr[nums.Length - 1] = 1;
            int rightProduct = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                leftProduct *= nums[i - 1];
                leftProductArr[i] = leftProduct;
                rightProduct *= nums[nums.Length - i];
                rightProductArr[nums.Length - i - 1] = rightProduct;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = leftProductArr[i] * rightProductArr[i];
            }

            return result;
        }

        #endregion

        #region Maximum Subarray  / Kadane algorithm
        //https://leetcode.com/problems/maximum-subarray/
        public static int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = maxSum;
            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i] + currentSum, nums[i]);
                maxSum = Math.Max(currentSum, maxSum);

            }
            return maxSum;

        }

        #endregion

        #region Maximum Product Subarray  / Kadane algorithm
        //https://leetcode.com/problems/maximum-subarray/
        public static int MaxProduct(int[] nums) //wrong answer, dont handle - signs
        {
            int maxSumPositive = nums[0];
            int maxSumNegative = maxSumPositive;
            int currentSumPositive = maxSumPositive;
            int currentSumNegative = maxSumPositive;
            for (int i = 1; i < nums.Length; i++)
            {
                currentSumPositive = Math.Max(nums[i] * currentSumPositive, nums[i]);
                maxSumPositive = Math.Max(currentSumPositive, maxSumPositive);

                currentSumNegative = Math.Min(nums[i] * currentSumNegative, nums[i]);
                maxSumNegative = Math.Min(currentSumNegative, maxSumNegative);


            }
            if(maxSumPositive > maxSumNegative) return maxSumPositive;
            else return maxSumNegative;

        }

        #endregion

        #region Container With Most Water //Time limit exceeded
        // https://leetcode.com/problems/container-with-most-water/description/
        public static int MaxAreaBrute(int[] height)
        {
            int maxArea = 0;
            for (int i = 0; i < height.Length-1; i++)
            {
                for (int j = i+1; j < height.Length; j++)
                {
                    int boxHeight = height[i] < height[j] ? height[i] : height[j];
                    int boxWidth = j - i;                  
                    int currentArea = boxWidth * boxHeight;
                    if(currentArea>maxArea) maxArea = currentArea;
                    Console.WriteLine($"Current i:{i}, current j: {j} current h:{boxHeight} current w:{boxWidth} current maxArea: {maxArea}");
                }
            }
            return maxArea;
        }

        public static int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length-1;
            int maxArea = 0;

            while (i!=j)
            {
                int boxHeight = height[i] < height[j] ? height[i] : height[j];
                int boxWidth = j - i;
                int currentArea = boxWidth * boxHeight;
                if (currentArea > maxArea) maxArea = currentArea;
                if (height[i] <= height[j]) i++;
                else j--;                
            }
            return maxArea;
        }

        #endregion

        #region 3 sum //unfinished!
        //https://leetcode.com/problems/3sum/description/
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<List<int>> result = new();
            List<int[]> arrayResult = new();
           

            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                //twosumFunc
                for (int j = i+1; j < nums.Length; j++)
                {
                    int b = nums[j];
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        int c = nums[k];
                        if (b + nums[k] == -a)
                        {
                            List<int> matchingNumber  = new() { a, b, nums[k] };

                            matchingNumber.Sort();
                            
                            result.Add(matchingNumber);
                          
                        }
                        Console.WriteLine($"a:{a}, b:{b}, c:{c}");
                    }

                }

            }
            

            List<List<int>> result2 = result.Distinct().ToList();
            


            foreach (List<int> list in result2)
            {
                Console.WriteLine($"{list[0]},{list[1]},{list[2]}");
            }

            

            return result.Distinct() as IList<IList<int>>;

        }


        #endregion

    }
}
