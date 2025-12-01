namespace AdventOfCodeCSharp.Day01;

public static class BruteForceSafeDial
{
    const int MinValue = 0;
    const int MaxValue = 99;

    public static DialResult DialToRight(int currentValue, int valueToAdd)
    {
        var zeroCount = 0;
        var currentNumber = currentValue;

        for(var i=0; i<valueToAdd; i++)
        {
            if (currentNumber == 99)
            {
                currentNumber = 0;
                zeroCount++;
            } else
            {
                currentNumber++;
            }            
        }

        return new DialResult
        {
            NewPosition = currentNumber,
            TotalClicks = zeroCount
        };
    }

    public static DialResult DialToLeft(int currentValue, int valueToAdd)
    {
        var zeroCount = 0;
        var currentNumber = currentValue;

        for (var i = 0; i < valueToAdd; i++)
        {
            Console.WriteLine(currentNumber);
            if (currentNumber == 0)
            {
                currentNumber = 99;
            }
            else
            {
                currentNumber--;
                if (currentNumber == 0)
                {
                    zeroCount++;
                }
            }
        }

        return new DialResult
        {
            NewPosition = currentNumber,
            TotalClicks = zeroCount
        };
    }
}
