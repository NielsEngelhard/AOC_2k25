using AdventOfCodeCSharp.Day05.P1;

namespace AOCTests.Day05;

public class FreshCheckerTests
{
    [Fact]
    public void GetNumbersInRangeTest()
    {
        var range = new RangeRecord { Start = 3, End = 5 };

        var result = FreshChecker.GetNumbersInRange(range).ToArray();

        Assert.Equal(long.Parse("3"), result[0]);
        Assert.Equal(long.Parse("4"), result[1]);
        Assert.Equal(long.Parse("5"), result[2]);
        Assert.Equal(3, result.Length);
    }
}
