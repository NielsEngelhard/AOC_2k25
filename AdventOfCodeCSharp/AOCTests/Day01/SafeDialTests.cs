using AdventOfCodeCSharp.Day01;

namespace AOCTests.Day01;

public class SafeDialTests
{
    [Theory]
    [InlineData(0, 50, 50)]
    [InlineData(0, 0, 0)]
    [InlineData(0, 99, 99)] // edge
    [InlineData(0, 100, 0)]
    [InlineData(0, 101, 1)]
    [InlineData(0, 200, 0)]
    [InlineData(0, 165, 65)]
    [InlineData(50, 204, 54)]
    [InlineData(52, 48, 0)]
    public void DialToRightTests(int currentValue, int valueToAdd, int expectedValue)
    {
        var result = SafeDial.DialToRight(currentValue, valueToAdd);

        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData(0, 5, 95)]
    [InlineData(50, 2, 48)]
    [InlineData(50, 50, 0)] // edge
    [InlineData(50, 51, 99)]
    [InlineData(50, 100, 50)]
    [InlineData(20, 220, 0)]
    [InlineData(30, 290, 40)]
    public void DialToLeftTests(int currentValue, int valueToSubtract, int expectedValue)
    {
        var result = SafeDial.DialToLeft(currentValue, valueToSubtract);

        Assert.Equal(expectedValue, result);
    }
}
