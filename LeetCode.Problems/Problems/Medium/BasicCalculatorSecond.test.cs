using Xunit;

namespace LeetCode.Problems.Problems.Medium;

public class BasicCalculatorSecondTests
{
    [Theory]
    [InlineData("3+2*2", 7)]           // Multiplication before addition
    [InlineData(" 3/2 ", 1)]           // Division with truncation toward zero
    [InlineData(" 3+5 / 2 ", 5)]       // Division before addition
    public void TestCalculate_BasicOperations(string expression, int expected)
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate(expression);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("3 + 2 * 2", 7)]       // With spaces between numbers and operators
    [InlineData(" 3 / 2 ", 1)]         // Leading and trailing spaces
    [InlineData(" 3 + 5 / 2 ", 5)]     // Mixed spaces and operators
    public void TestCalculate_WithSpaces(string expression, int expected)
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate(expression);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestCalculate_HandlesMultipleOperators()
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate("2+3*4-5/2");

        // Assert
        Assert.Equal(11, result); // 2 + (3 * 4) - (5 / 2) = 11
    }

    [Fact]
    public void TestCalculate_HandlesParentheses()
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate("(2 + 3) * 4");

        // Assert
        Assert.Equal(20, result); // (2 + 3) * 4 = 20
    }

    [Fact]
    public void TestCalculate_DivisionByZero()
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act and Assert
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate("3/0"));
    }

    [Theory]
    [InlineData("-3+2*2", 1)]          // Negative number addition
    [InlineData("-3-2*2", -7)]         // Negative number subtraction
    [InlineData("-3/1", -3)]           // Negative number division
    public void TestCalculate_NegativeNumbers(string expression, int expected)
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate(expression);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestCalculate_ZeroExpression()
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate("0");

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestCalculate_LargeExpression()
    {
        // Arrange
        var calculator = new BasicCalculatorSecond();

        // Act
        var result = calculator.Calculate("1000000 + 2000000 * 3");

        // Assert
        Assert.Equal(7000000, result); // 1000000 + (2000000 * 3) = 7000000
    }
}