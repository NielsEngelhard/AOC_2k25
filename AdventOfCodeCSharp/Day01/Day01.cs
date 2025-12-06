namespace AdventOfCodeCSharp.Day01;

public class Day01
{
    const int StartPosition = 50;

    public int Execute()
    {
        string[] lines = GetInput();
        // Tried 2 fancy at first - brute force won for part2 within 3 minutes haha
        //string[] lines = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];

        var currentPosition = StartPosition;

        var currentNumberOfZeros = 0;

        for(var i=0; i<lines.Length; i++)
        {
            var rawLine = lines[i];
            var parsedLine = SafeDial.ParseLine(rawLine);

            if (parsedLine.Direction == RotationDirection.Left)
            {
                var dialResult = BruteForceSafeDial.DialToLeft(currentPosition, parsedLine.DialSize);
                currentNumberOfZeros += dialResult.TotalClicks;
                currentPosition = dialResult.NewPosition;
            } else if (parsedLine.Direction == RotationDirection.Right)
            {
                var dialResult = BruteForceSafeDial.DialToRight(currentPosition, parsedLine.DialSize);
                currentNumberOfZeros += dialResult.TotalClicks;
                currentPosition = dialResult.NewPosition;
            } else
            {
                throw new Exception("INVALID INPUT");
            }
        }

        return currentNumberOfZeros;
    }

    public string[] GetInput()
    {
        return [.. File.ReadLines("./Day01/real-input.txt")];
    }
}
