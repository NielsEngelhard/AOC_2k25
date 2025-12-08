using AdventOfCodeCSharp.Day04;
using AdventOfCodeCSharp.Day04.P2;

namespace AOCTests.Day04;

public class AdvancedPaperAccessCalculatorTests
{
    [Theory]
    [InlineData(0, 0, 2)]
    [InlineData(3, 0, 3)]
    [InlineData(8, 3, 4)]
    [InlineData(9, 0, 3)]
    public void A_CountAdjecentRollsForIndexTests_FirstRow(int x, int y, int expectedCount)
    {
        var grid = A_GetTestGrid();

        var actualResult = AdvancedPaperAccessCalculator.CountAdjecentRollsForIndex(grid, new Position { X = x, Y = y });
        Assert.Equal(expectedCount, actualResult);
    }

    public char[][] A_GetTestGrid()
    {
        return
        [
            "..@@.@@@@.".ToCharArray(),
            "@@@.@.@.@@".ToCharArray(),
            "@@@@@.@.@@".ToCharArray(),
            "@.@@@@..@.".ToCharArray(),
            "@@.@@@@.@@".ToCharArray(),
            ".@@@@@@@.@".ToCharArray(),
            ".@.@.@.@@@".ToCharArray(),
            "@.@@@.@@@@".ToCharArray(),
            ".@@@@@@@@.".ToCharArray(),
            "@.@.@@@.@.".ToCharArray(),
        ];
    }
}
