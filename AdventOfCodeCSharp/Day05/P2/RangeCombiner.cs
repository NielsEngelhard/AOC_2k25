using AdventOfCodeCSharp.Day05.P1;

namespace AdventOfCodeCSharp.Day05.P2;

public class RangeCombiner
{
    public static IList<RangeRecord> KeepIteratingUntillNoMore(IList<RangeRecord> rawRanges)
    {
        //bool stop = false;
        //int previousNRanges = -1;

        //var currentRanges = rawRanges;

        //while (!stop)
        //{
        //    var orderedRanges = currentRanges.OrderBy(r => r.Start).ToList();
        //    currentRanges = RangeCombiner.MergeOverlappingRanges(orderedRanges);

        //    if (currentRanges.Count() == previousNRanges)
        //    {
        //        stop = true;
        //    }
        //    else
        //    {
        //        previousNRanges = currentRanges.Count();
        //    }
        //}

        var orderedRanges = rawRanges.OrderBy(r => r.Start).ToList();
        var currentRanges = RangeCombiner.MergeOverlappingRanges(orderedRanges);

        return currentRanges;
    }

    // Step 2: Merge overlapping/adjacent ranges SOMEHOW?!
    public static IList<RangeRecord> MergeOverlappingRanges(IList<RangeRecord> sortedRanges)
    {
        // sortedRanges so already sorted

        var mergedRanges = new List<RangeRecord>();

        var currentRange = sortedRanges.First();

        for(var i=1; i<sortedRanges.Count(); i++)
        {
            var rangeToCheck = sortedRanges[i];

            var rangesOverlap = RangeHasOverlap(currentRange, rangeToCheck);
            if (rangesOverlap)
            {
                // Combine them and then go on
                currentRange = CombineRanges(currentRange, rangeToCheck);
            } else // not overlapping
            {
                mergedRanges.Add(currentRange); // This is done
                currentRange = rangeToCheck;    // And then go on
            }

            var isLastIteration = i == sortedRanges.Count() - 1;
            if (isLastIteration)
            {
                if (rangesOverlap)
                {
                    mergedRanges.Add(currentRange);
                } else
                {
                    mergedRanges.Add(rangeToCheck);
                }
            }
        }

        return mergedRanges;
    }

    public static RangeRecord CombineRanges(RangeRecord first, RangeRecord second)
    {
        var endRange = second.End > first.End
            ? second.End
            : first.End;

        return new RangeRecord
        {
            Start = first.Start,
            End = endRange
        };
    }

    public static bool RangeHasOverlap(RangeRecord first, RangeRecord second)
    {
        return first.End >= second.Start;
    }
}
