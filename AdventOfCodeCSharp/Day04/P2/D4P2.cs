namespace AdventOfCodeCSharp.Day04.P2;

public class D4P2
{
    const string FileName = "Day04/real-input.txt";

    public long Execute()
    {
        var grid = GetParsedGrid();

        var result = AdvancedPaperAccessCalculator.Execute(grid);

        return result;
    }

    public char[][] GetParsedGrid()
    {
        var rows = File.ReadLines(FileName).ToArray();
        return rows.Select(c => c.ToCharArray()).ToArray();
    }
}
