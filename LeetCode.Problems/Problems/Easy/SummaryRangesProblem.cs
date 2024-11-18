namespace LeetCode.Problems.Problems.Easy;
public class SummaryRangesProblem
{
    /// <summary>
    /// Generates a list of summary ranges from a sorted unique integer array.
    /// </summary>
    /// <remarks>
    /// This method creates a list of strings representing ranges that cover all numbers in the input array.
    /// Each range is represented as "a->b" if a != b, or "a" if a == b.
    /// </remarks>
    /// <param name="nums">A sorted unique integer array to generate summary ranges from.</param>
    /// <returns>
    /// An IList of strings where each string represents a range in the format described above.
    /// If the input array is empty, an empty list is returned.
    /// </returns>
    /// <example>
    /// Input: [0,1,2,4,5,7]
    /// Output: ["0->2","4->5","7"]
    /// </example>
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        
        if (nums.Length == 0)
        {
            return result;
        }
 
        int start = nums[0];
        int end = nums[0];

        for (int i = 1; i <= nums.Length; i++)
        {
            if (i < nums.Length && nums[i] == nums[i - 1] + 1)
            {
                end = nums[i];
            }
            else
            {
                result.Add(start == end ? start.ToString() : $"{start}->{end}");
                if (i < nums.Length)
                {
                    start = nums[i];
                    end = nums[i];
                }
            }
        }
        
 
        return result;
    }
}