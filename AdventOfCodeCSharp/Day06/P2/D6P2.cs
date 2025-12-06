using System;

namespace AdventOfCodeCSharp.Day06.P1;

internal class D6P2
{
    const string FileName = $"Day06/real-input.txt";

    public static long Execute()
    {
        var grid = GetGrid();

        PrintGrid(grid);

        var result = Day2ColumnReader.ProcessGrid(grid);
        //return Day2ColumnReader.ProcessColumns(columns);

        return result;

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
