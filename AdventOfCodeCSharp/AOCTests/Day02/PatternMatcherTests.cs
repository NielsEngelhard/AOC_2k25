using AdventOfCodeCSharp.Day02.Part1;

namespace AOCTests.Day02;

public class PatternMatcherTests
{
    [Theory]
    [InlineData(11, 22, 33)]
    [InlineData(95, 115, 99)]
    [InlineData(998, 1012, 1010)]
    [InlineData(1188511880, 1188511890, 1188511885)]
    [InlineData(222220, 222224, 222222)]
    [InlineData(1698522, 1698528, 0)]
    [InlineData(446443, 446449, 446446)]
    [InlineData(38593856, 38593862, 38593859)]
    public void MatchAndCountPatterns(long start, long end, long expectedResult)
    {
        var actualResult = PatternMatcher.MatchAndCountPatterns(start, end);
        Assert.Equal(expectedResult, actualResult);
    }
}
