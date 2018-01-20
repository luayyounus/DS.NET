using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonPractice
{
    internal class MaximumSizeSubarraySumEqualsK
    {
        public static int MaxSubArrayLengthFaster(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int max = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == k) max = Math.Max(max, i + 1);
                int diff = sum - k;
                if (dict.ContainsKey(diff)) max = Math.Max(max, i - dict[diff]);
                if (!dict.ContainsKey(sum)) dict.Add(sum, i);
            }
            return max;
        }

        public static int MaxSubArrayLen(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return 0;
            int result = 0;
            Dictionary<int, int> dict = new Dictionary<int, int> {{0, -1}};

            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i] - k))
                {
                    result = Math.Max(result, i - dict[(nums[i] - k)]);
                }
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return result;
        }
    }
}
