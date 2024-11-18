using Xunit;

namespace LeetCode.Problems.Problems.Easy;

public class PalindromeNumberProblemTests
{
    [Fact]
    public void IsPalindrome_SingleDigitNumber_ReturnsTrue()
    {
        // Arrange
        int number = 7;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_EvenDigitPalindromeNumber_ReturnsTrue()
    {
        // Arrange
        int number = 1221;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_EvenDigitNonPalindromeNumber_ReturnsFalse()
    {
        // Arrange
        int number = 1234;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_OddDigitPalindromeNumber_ReturnsTrue()
    {
        // Arrange
        int number = 12321;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_Zero_ReturnsTrue()
    {
        // Arrange
        int number = 0;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_MinIntegerValue_ReturnsFalse()
    {
        // Arrange
        int number = int.MinValue;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_MaxIntegerValue_ReturnsFalse()
    {
        // Arrange
        int number = int.MaxValue;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsPalindrome_OddDigitNonPalindromeNumber_ReturnsFalse()
    {
        // Arrange
        int number = 12345;

        // Act
        bool result = PalindromeNumberProblem.IsPalindrome(number);

        // Assert
        Assert.False(result);
    }
}