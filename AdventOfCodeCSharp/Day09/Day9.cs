using AdventOfCodeCSharp.Day08;

namespace AdventOfCodeCSharp.Day09;

public class Day9
{
    const string FileName = $"Day09/test-input.txt";

    public static long ExecutePart1()
    {
        var inputCoords = GetInputCoords();
        var highestCoords = GetHighestXAndYCoords(inputCoords);

        var inputGrid = CreateCharGridOfDots(highestCoords.X, highestCoords.Y);
        MarkRedTiles(inputGrid, inputCoords);
        PrintGrid(inputGrid);

        FirstTryPatternFinder.FindPatterns(inputGrid);

        return 10;
    }

    public static long ExecutePart2()
    {
        throw new NotImplementedException();
    }

    public static void MarkRedTiles(char[][] grid, IList<Coords> redTiles)
    {
        for(var i=0; i<redTiles.Count; i++)
        {
            var currentTile = redTiles[i];

            grid[currentTile.Y][currentTile.X] = '#';
        }
    }

    public static char[][] CreateCharGridOfDots(long x, long y)
    {
        char[][] grid = new char[y][];

        for (int i = 0; i < y; i++)
        {
            grid[i] = new char[x];
            for (int j = 0; j < x; j++)
            {
                grid[i][j] = '.';
            }
        }

        return grid;
    }

    public static Coords GetHighestXAndYCoords(IList<Coords> coords)
    {
        var highestX = coords.OrderByDescending(c => c.X).First().X;
        var highestY = coords.OrderByDescending(c => c.Y).First().Y;

        return new Coords
        {
            X = highestX + 1,
            Y = highestY + 1
        };
    }

    public static IList<Coords> GetInputCoords()
    {
        var lines = File.ReadLines(FileName);
        return [.. lines.Select(l => MapStringToCoords(l))];
    }

    private static Coords MapStringToCoords(string input)
    {
        var parts = input.Split(',');

        return new Coords
        {
            X = long.Parse(parts[0]),
            Y = long.Parse(parts[1])
        };
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

public record Coords() {
    public long X { get; init; }
    public long Y { get; init; }
}