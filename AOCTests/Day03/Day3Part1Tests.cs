using AdventOfCodeCSharp.Day03.P1;

namespace AOCTests.Day03;

public class Day3Part1Tests
{
    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void GetJoltageTests(string battery, long expectedResult)
    {
        var result = BatteryChecker.GetJoltage(battery);
        Assert.Equal(expectedResult, result);
    }
}
