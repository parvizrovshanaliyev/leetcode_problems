namespace LeetCode.Problems.Problems.Easy;

public class PalindromeNumberProblem
{
    /// <summary>
    /// Determines whether the given integer is a palindrome.
    /// </summary>
    /// <param name="x">The integer to check.</param>
    /// <returns>True if the integer is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(int x) 
    {
        // Negative numbers and numbers ending with 0 (except 0 itself) are not palindromes
        if (x < 0 || (x % 10 == 0 && x != 0))
            return false;

        int reversedHalf = 0;

        // Reverse half of the number
        while (x > reversedHalf)
        {
            reversedHalf = reversedHalf * 10 + x % 10;
            x /= 10; 
        }

        // Check if the original first half matches the reversed second half
        return x == reversedHalf || x == reversedHalf / 10; 
    }
}