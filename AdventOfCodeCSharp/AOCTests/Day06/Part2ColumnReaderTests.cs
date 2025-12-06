using AdventOfCodeCSharp.Day06.P1;

namespace AOCTests.Day06;

public class Part2ColumnReaderTests
{
    [Fact]
    public void Test_ProcessColumn_ForDay2()
    {
        string[] input = ["123", "45", "6", "*"];

        var result = Day2ColumnReader.ProcessColumn(input);

        Assert.Equal(8544, result);
    }

    [Fact]
    public void Test_ConvertToRightToLeftColumn()
    {
        string[] input = ["123", "45", "6", "*"];

        var result = Day2ColumnReader.ConvertToRightToLeftColumn(input);

        Assert.Equal(4, result.Length);
        Assert.Contains("1", result);
        Assert.Contains("24", result);
        Assert.Contains("356", result);
        Assert.Contains("*", result);
    }

    [Fact] // Deze ging nog niet goed
    public void Test_ConvertToRightToLeftColumn_RechtsLinkMoetOok()
    {
        string[] input = ["328", "64", "98", "+"];

        var result = Day2ColumnReader.ConvertToRightToLeftColumn(input);

        Assert.Equal(4, result.Length);
        Assert.Contains("8", result);
        Assert.Contains("248", result);
        Assert.Contains("369", result);
        Assert.Contains("+", result);
    }
}
