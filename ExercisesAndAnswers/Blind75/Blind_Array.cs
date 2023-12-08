using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Blind75
{
    public class Blind_Array
    {
        //Two sum
        //https://leetcode.com/problems/two-sum/
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int,int> map = new();
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

        //Best time to Buy and Sell Stock
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

        //Contains duplicate
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

        //Find Minimum in Rotated Sorted Array
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


    }
}
