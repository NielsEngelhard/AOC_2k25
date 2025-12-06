using AdventOfCodeCSharp.Day06.P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOCTests.Day06;

public class ColumnReaderTests
{
    [Fact]
    public void MapRowsToColumnsTest()
    {
        string[] rows = [
            "123 328   51  64",
            "1 2 3 4",
            "* + + *",
        ];


        var columns = ColumnReader.MapRowsToColumns(rows);
    
        Assert.Equal("123 1 *", columns[0]);
        Assert.Equal("328 2 +", columns[1]);
        Assert.Equal("51 3 +", columns[2]);
        Assert.Equal("64 4 *", columns[3]);
    }
}
