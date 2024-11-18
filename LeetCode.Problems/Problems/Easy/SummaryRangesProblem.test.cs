using Xunit;

namespace LeetCode.Problems.Problems.Easy;

public class SummaryRangesProblemTests
{
    [Fact]
    public void SummaryRanges_ContinuousRange_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { 0, 1, 2, 4, 5, 7 };
        var expected = new List<string> { "0->2", "4->5", "7" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_NonContinuousRange_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { 0, 2, 3, 4, 6, 8, 9 };
        var expected = new List<string> { "0", "2->4", "6", "8->9" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_EmptyArray_ReturnsEmptyList()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { };
        var expected = new List<string> { };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_ArrayWithLargeNumbers_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { int.MaxValue - 2, int.MaxValue - 1, int.MaxValue };
        var expected = new List<string> { $"{int.MaxValue - 2}->{int.MaxValue}" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    

    [Fact]
    public void SummaryRanges_AlternatingContinuousAndNonContinuousRanges_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { 1, 2, 4, 5, 7, 8, 10, 12, 13, 14 };
        var expected = new List<string> { "1->2", "4->5", "7->8", "10", "12->14" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_ArrayWithMinIntegerValue_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { int.MinValue, int.MinValue + 1, int.MinValue + 2 };
        var expected = new List<string> { $"{int.MinValue}->{int.MinValue + 2}" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_ArrayWithMaxIntegerValue_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { int.MaxValue - 1, int.MaxValue };
        var expected = new List<string> { $"{int.MaxValue - 1}->{int.MaxValue}" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_ArrayWithLargeGaps_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { 1, 3, 10, 100, 1000 };
        var expected = new List<string> { "1", "3", "10", "100", "1000" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_MixedPositiveAndNegativeNumbers_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { -3, -2, -1, 1, 2, 4, 5, 7, 8 };
        var expected = new List<string> { "-3->-1", "1->2", "4->5", "7->8" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SummaryRanges_ArrayWithNegativeNumbers_ReturnsCorrectSummary()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { -5, -4, -3, -1, 0, 2, 4, 5, 7 };
        var expected = new List<string> { "-5->-3", "-1->0", "2", "4->5", "7" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }

   

    [Fact]
    public void SummaryRanges_SingleElementArray_ReturnsSingleElementList()
    {
        // Arrange
        var summaryRangesProblem = new SummaryRangesProblem();
        var nums = new int[] { 5 };
        var expected = new List<string> { "5" };

        // Act
        var result = summaryRangesProblem.SummaryRanges(nums);

        // Assert
        Assert.Equal(expected, result);
    }
}