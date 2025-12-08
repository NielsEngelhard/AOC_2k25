namespace AdventOfCodeCSharp.Day06.P1;

public class Day2ColumnReader
{
    public static long ProcessGrid(char[][] grid)
    {
        long count = 0;

        var xIndexes = GetXIndexesForCuts(grid);
        var columns = GetColumnsBasedOnColumnCuts(grid, xIndexes.ToArray());

        foreach (var column in columns)
        {
            var parseColumn = ParseColumn(column); // Zet om naar het "oude formaat"
            count += ProcessColumnLikeBefore(parseColumn);
        }

        return count;
    }

    public static string[] ParseColumn(char[][] column)
    {
        var numberOfItems = column.First().Length; // Dit kan
        string[] parsedColumn = new string[numberOfItems + 1]; // plus 1 voor action symbol

        // Reverse loop through the column
        for (int x = 0; x < column.First().Length; x++)
        {
            for (int y = 0; y < column.Length; y++)
            {
                if (y == column.Length-1) // Laatste symbool pakken we later wel
                {
                    continue;
                }

                var currentX = column.First().Length - 1 - x; // van RECHTS naar LINKS <-- omgedraaid tov normaal lmz
                var currentY = y; // van boven naar beneden

                var currentChar = column[y][x];
                parsedColumn[x] += currentChar;
            }
        }

        // Voeg laatste symbool nog even toe, die zit altijd rechtsonder
        var actionSymbol = column[column.Length - 1][0];
        parsedColumn[numberOfItems] += actionSymbol;
        return parsedColumn;
    }

    public static List<char[][]> GetColumnsBasedOnColumnCuts(char[][] grid, int[] columnXAxisCuts)
    {
        var splittedColumns = new List<char[][]>();

        var previousXCut = -1;

        // Om laatste case ook te supporten, voeg "denkbeeldige xcut toe helemaal rechts
        columnXAxisCuts = [.. columnXAxisCuts, grid.First().Length];

        for (var i=0; i<columnXAxisCuts.Length; i++) // Voor elke column cut 
        {
            int xCut = columnXAxisCuts[i];

            var xStart = previousXCut + 1;
            var xEnd = xCut - 1;
            var yStart = 0;
            var yEnd = grid.Length - 1;

            var columnFromGrid = GetSubset(grid, xStart, yStart, xEnd, yEnd);

            splittedColumns.Add(columnFromGrid);

            previousXCut = xCut;
        }

        return splittedColumns;
    }

    public static char[][] GetSubset(char[][] source, int xStart, int yStart, int xEnd, int yEnd)
    {
        // Calculate dimensions of the subset
        int height = yEnd - yStart + 1;
        int width = xEnd - xStart + 1;

        // Create the result array
        char[][] subset = new char[height][];

        // Extract the subset
        for (int y = 0; y < height; y++)
        {
            subset[y] = new char[width];
            for (int x = 0; x < width; x++)
            {
                subset[y][x] = source[yStart + y][xStart + x];
            }
        }

        return subset;
    }

    public static List<int> GetXIndexesForCuts(char[][] grid)
    {
        List<int> xIndexesVoorCuts = new List<int>();

        // Vind alle lines met alleen maar whitespace - daar moet ie gecut worden
        for (int x = 0; x < grid.First().Length; x++)
        {
            var isEmptyColumn = AllYValuesContainWhiteSpace(grid, x);
            if (isEmptyColumn)
            {
                xIndexesVoorCuts.Add(x);
            }
        }

        return xIndexesVoorCuts;
    }

    public static bool AllYValuesContainWhiteSpace(char[][] grid, int x)
    {
        var maxY = grid.Length - 1;
        for (int y = 0; y < maxY; y++)
        {
            var currentChar = grid[y][x];

            if (currentChar != ' ') // Niet whitespace
            {
                return false;
            }
        }

        return true;
    }

    public static long ProcessColumnLikeBefore(string[] rawColumn)
    {
        var firstSymbol = rawColumn[rawColumn.Length - 1];
        List<string> numbers = rawColumn.ToList().Slice(0, rawColumn.Length - 1);

        CountMode countMode = DetermineCountMode(firstSymbol);

        return ProcessNumbers([.. numbers.Select(long.Parse)], countMode);
    }

    public static long ProcessNumbers(long[] numbers, CountMode mode)
    {
        switch (mode)
        {
            case CountMode.Multiply:
                var count = numbers[0]; 
                for (var i=1; i<numbers.Length; i++) // Skip first so i=0
                {
                    count *= numbers[i];
                };
                return count;
            case CountMode.Plus:
                return numbers.Sum(); ;
            default:
                throw new NotImplementedException();
        }
    }

    public static CountMode DetermineCountMode(string symbol)
    {
        return symbol switch
        {
            ("*") => CountMode.Multiply,
            ("+") => CountMode.Plus,
            _ => throw new Exception("Unknown symbol " + symbol),
        };
    }
}
