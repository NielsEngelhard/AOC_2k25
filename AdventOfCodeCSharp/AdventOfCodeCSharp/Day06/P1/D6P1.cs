using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeCSharp.Day06.P1;

internal class D6P1
{
    const string FileName = $"Day06/real-input.txt";

    public static long Execute()
    {
        var rows = GetRows();
        var columns = ColumnReader.MapRowsToColumns(rows.ToArray());
        return ColumnReader.ProcessColumns(columns);

    }

    public static IEnumerable<string> GetRows()
    {
        return File.ReadLines(FileName);
    }
}
