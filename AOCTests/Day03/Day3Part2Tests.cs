using AdventOfCodeCSharp.Day03;
using AdventOfCodeCSharp.Day03.P1;

namespace AOCTests.Day03;

public class Day3Part2Tests
{
    [Theory]
    [InlineData("987654321111111", 987654321111)]
    [InlineData("811111111111119", 811111111119)]
    [InlineData("234234234234278", 434234234278)]
    [InlineData("818181911112111", 888911112111)]
    public void GetJoltageTests(string battery, long expectedResult)
    {
        var result = AnyBatteryChecker.GetJoltage(battery);
        Assert.Equal(expectedResult, result);
    }
}
