namespace LeetCode.Problems.Problems.Easy;

/// <summary>
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/// You may assume that each input would have exactly one solution, and you may not use the same element twice.
/// You can return the answer in any order.
/// </summary>
/// <remarks>
/// Example 1:
/// Input: nums = [2,7,11,15], target = 9
/// Output: [0,1]
/// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
/// Example 2:
///
/// Input: nums = [3,2,4], target = 6
/// Output: [1,2]
/// Example 3:
///
/// Input: nums = [3,3], target = 6
/// Output: [0,1]
/// </remarks>"
/// <reference> https://leetcode.com/problems/two-sum/ </reference>
public static class TwoSum
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TwoSum"/> class.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] SolutionOne(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] != target) continue;
                
                return new[] {i, j};
            }
        }

        return Array.Empty<int>();
    }
    
    
    /// <summary>
    ///  Initializes a new instance of the <see cref="TwoSum"/> class.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int[] SolutionTwo(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            
            if (dict.TryGetValue(complement, out var value))
            {
                return new[] {dict[complement], i};
            }

            dict.TryAdd(nums[i], i);
        }

        // if no solution found
        return Array.Empty<int>();
    }
}