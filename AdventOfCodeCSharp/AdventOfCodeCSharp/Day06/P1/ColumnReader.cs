namespace AdventOfCodeCSharp.Day06.P1;

public class ColumnReader
{
    public static long ProcessColumns(string[] columns)
    {
        long count = 0;

        foreach (var column in columns)
        {
            var parsedColumn = ParseColumn(column);
            count += ProcessColumn(parsedColumn);
        }

        return count;
    }

    public static string[] MapRowsToColumns(string[] rows)
    {
        var amountOfColumns = rows.First().Split().Count(x => !string.IsNullOrWhiteSpace(x));

        string[] columns = new string[amountOfColumns];

        for(var i=0; i<rows.Length; i++)
        {
            var rowItems = rows[i].Split().Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            
            for(var j=0; j<amountOfColumns; j++)
            {
                var isLastItem = i == rows.Length - 1;
                var lastChar = isLastItem ? "" : " ";
                columns[j] += $"{rowItems[j]}{lastChar}";
            }
        }

        return columns;
    }

    public static string[] ParseColumn(string column)
    {
        return column.Split(" ");
    }

    public static long ProcessColumn(string[] rawColumn)
    {
        var lastSymbol = rawColumn[rawColumn.Length - 1];
        List<string> numbers = rawColumn.ToList().Slice(0, rawColumn.Length-1);

        CountMode countMode = DetermineCountMode(lastSymbol);

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

public enum CountMode {
    Multiply,
    Plus
}
