using AdventOfCodeCSharp.Day01;

namespace AOCTests.Day01;

public class SafeDialTests
{
    [Theory]
    [InlineData(0, 50, 50, 0)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(0, 99, 99, 0)] // edge
    [InlineData(0, 100, 0, 1)]
    [InlineData(80, 20, 0, 1)]
    [InlineData(99, 1, 0, 1)]
    [InlineData(50, 100, 50, 1)]
    [InlineData(0, 101, 1, 1)]
    [InlineData(0, 200, 0, 2)]
    [InlineData(0, 165, 65, 1)]
    [InlineData(50, 204, 54, 2)]
    [InlineData(52, 48, 0, 1)]
    [InlineData(50, 1000, 50, 10)]
    [InlineData(95, 60, 55, 1)]
    public void DialToRightTests(int currentValue, int valueToAdd, int expectedNewPosition, int expectedClicks)
    {
        var result = SafeDial.DialToRight(currentValue, valueToAdd);

        Assert.Equal(expectedNewPosition, result.NewPosition);
        Assert.Equal(expectedClicks, result.TotalClicks);
    }

    [Theory]
    [InlineData(60, 20, 40, 0)]
    [InlineData(19, 2, 17, 0)]
    [InlineData(50, 2, 48, 0)]
    [InlineData(50, 50, 0, 1)] // edge
    [InlineData(50, 51, 99, 1)]
    [InlineData(50, 100, 50, 1)]
    [InlineData(20, 220, 0, 3)]
    [InlineData(30, 290, 40, 3)]
    [InlineData(50, 1000, 50, 10)]
    [InlineData(0, 5, 95, 0)]
    public void DialToLeftTests(int currentValue, int valueToSubtract, int expectedNewPosition, int expectedClicks)
    {
        var result = SafeDial.DialToLeft(currentValue, valueToSubtract);

        Assert.Equal(expectedNewPosition, result.NewPosition);
        Assert.Equal(expectedClicks, result.TotalClicks);
    }
}
