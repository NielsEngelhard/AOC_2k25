using AdventOfCodeCSharp.Day06.P1;

namespace AdventOfCodeCSharp.Day07;

public static class D7P1
{
    const string FileName = $"Day07/real-input.txt";

    public static long Execute()
    {
        var grid = GetGrid();

        PrintGrid(grid);

        LaserBeam.Beam(grid);

        return 0;

    }

    public static char[][] GetGrid()
    {
        var lines = File.ReadLines(FileName);
        return lines.Select(l => l.ToCharArray()).ToArray();
    }

    public static void PrintGrid(char[][] grid)
    {
        for (int y = 0; y < grid.Length; y++)
        {
            Console.WriteLine("");
            for (int x = 0; x < grid.First().Length; x++) // Kan wel want toch even lang allemaal (zie input)
            {
                Console.Write(grid[y][x]);
            }
        }
    }
}
