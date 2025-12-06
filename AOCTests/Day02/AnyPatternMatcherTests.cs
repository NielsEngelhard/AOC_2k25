using AdventOfCodeCSharp.Day02;
using AdventOfCodeCSharp.Day02.Part1;

namespace AOCTests.Day02;

public class AnyPatternMatcherTests
{
    [Theory]
    [InlineData(11, 22, 33)]
    [InlineData(95, 115, 210)]
    [InlineData(998, 1012, 2009)]
    [InlineData(1188511880, 1188511890, 1188511885)]
    [InlineData(222220, 222224, 222222)]
    [InlineData(1698522, 1698528, 0)]
    [InlineData(446443, 446449, 446446)]
    [InlineData(565653, 565659, 565656)]
    [InlineData(824824821, 824824827, 824824824)]
    [InlineData(2121212118, 2121212124, 2121212121)]
    public void MatchAndCountPatterns(long start, long end, long expectedResult)
    {
        var actualResult = AnyPatternMatcher.MatchAndCountPatterns(start, end);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("22", "222222", true)]
    [InlineData("22", "22222", false)]
    [InlineData("1", "111111111", true)]
    [InlineData("123", "123123123", true)]
    public void IsMatchTests(string pattern, string input, bool expectedResult)
    {
        var actualResult = AnyPatternMatcher.IsMatch(pattern, input);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(222220, false)]
    [InlineData(222221, false)]
    [InlineData(222222, true)]
    [InlineData(222223, false)]
    public void HasPatternInItTests(long number, bool hasPattern)
    {
        var actualResult = AnyPatternMatcher.HasPatternInIt(number);
        Assert.Equal(hasPattern, actualResult);
    }
}
