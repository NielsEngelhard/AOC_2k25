using AdventOfCodeCSharp.Day05.P1;
using AdventOfCodeCSharp.Day05.P2;

namespace AOCTests.Day05;

public class RangeCombinerTests
{
    [Fact]
    public void CombineRanges_NothingToCombine()
    {
        List<RangeRecord> ranges = [
            new RangeRecord { Start = 3, End = 10 },
            new RangeRecord { Start = 15, End = 20 }
        ];

        var combinedResult = RangeCombiner.MergeOverlappingRanges(ranges);

        Assert.Equal(3, combinedResult[0].Start);
        Assert.Equal(10, combinedResult[0].End);

        Assert.Equal(15, combinedResult[1].Start);
        Assert.Equal(20, combinedResult[1].End);
    }

    [Fact]
    public void CombineRanges_CombineOne_ShouldResultIntoOneRange()
    {
        List<RangeRecord> ranges = [
            new RangeRecord { Start = 3, End = 10 },
            new RangeRecord { Start = 8, End = 20 }
        ];

        var combinedResult = RangeCombiner.MergeOverlappingRanges(ranges);

        Assert.Equal(3, combinedResult[0].Start);
        Assert.Equal(20, combinedResult[0].End);
    }

    [Fact]
    public void RangeHasOverlap_Tests_Has_Overlap()
    {
        var range1 = new RangeRecord { Start = 3, End = 10 };
        var range2 = new RangeRecord { Start = 3, End = 10 };


        var result = RangeCombiner.RangeHasOverlap(range1, range2);

        Assert.True(result);
    }

    [Fact]
    public void RangeHasOverlap_Tests_Has_OverlapOnThreshold()
    {
        var range1 = new RangeRecord { Start = 10, End = 20 };
        var range2 = new RangeRecord { Start = 20, End = 30 };

        var result = RangeCombiner.RangeHasOverlap(range1, range2);

        Assert.True(result);
    }

    [Fact]
    public void RangeHasOverlap_Tests_Has_No_Overlap()
    {
        var range1 = new RangeRecord { Start = 10, End = 20 };
        var range2 = new RangeRecord { Start = 21, End = 30 };

        var result = RangeCombiner.RangeHasOverlap(range1, range2);

        Assert.False(result);
    }

    [Fact]
    public void CombineRangesTests()
    {
        var range1 = new RangeRecord { Start = 10, End = 20 };
        var range2 = new RangeRecord { Start = 21, End = 30 };

        var result = RangeCombiner.CombineRanges(range1, range2);

        Assert.Equal(10, result.Start);
        Assert.Equal(30, result.End);
    }

    [Fact]
    public void MergeOverlappingRangesTests()
    {
        var range1 = new RangeRecord { Start = 10, End = 20 };
        var range2 = new RangeRecord { Start = 21, End = 30 };

        var result = RangeCombiner.CombineRanges(range1, range2);

        Assert.Equal(10, result.Start);
        Assert.Equal(30, result.End);
    }

    [Fact]
    public void CombineRanges_TheTestCase()
    {
        List<RangeRecord> ranges = [
            new RangeRecord { Start = 3, End = 5 },
            new RangeRecord { Start = 10, End = 14 },
            new RangeRecord { Start = 12, End = 18 },
            new RangeRecord { Start = 16, End = 20 }
        ];

        var combinedResult = RangeCombiner.MergeOverlappingRanges(ranges);

        Assert.Equal(2, combinedResult.Count());

        Assert.Equal(3, combinedResult[0].Start);
        Assert.Equal(5, combinedResult[0].End);

        Assert.Equal(10, combinedResult[1].Start);
        Assert.Equal(20, combinedResult[1].End);
    }

    [Fact]
    public void CombineRanges_TheTestCasePlusEndExtra()
    {
        List<RangeRecord> ranges = [
            new RangeRecord { Start = 3, End = 5 },
            new RangeRecord { Start = 10, End = 14 },
            new RangeRecord { Start = 12, End = 18 },
            new RangeRecord { Start = 16, End = 20 },
            new RangeRecord { Start = 21, End = 22 }
        ];

        var combinedResult = RangeCombiner.MergeOverlappingRanges(ranges);

        Assert.Equal(3, combinedResult.Count());

        Assert.Equal(3, combinedResult[0].Start);
        Assert.Equal(5, combinedResult[0].End);

        Assert.Equal(10, combinedResult[1].Start);
        Assert.Equal(20, combinedResult[1].End);

        Assert.Equal(21, combinedResult[2].Start);
        Assert.Equal(22, combinedResult[2].End);
    }

    [Fact]
    public void CombineRanges_TheTestCasePlusStartExtra()
    {
        List<RangeRecord> ranges = [
            new RangeRecord { Start = 1, End = 2 },
            new RangeRecord { Start = 2, End = 5 },
            new RangeRecord { Start = 5, End = 100 },
            new RangeRecord { Start = 16, End = 20 },
            new RangeRecord { Start = 21, End = 22 }
        ];

        var combinedResult = RangeCombiner.MergeOverlappingRanges(ranges);

        Assert.Equal(1, combinedResult.Count());

        Assert.Equal(1, combinedResult[0].Start);
        Assert.Equal(100, combinedResult[0].End);
    }
}
