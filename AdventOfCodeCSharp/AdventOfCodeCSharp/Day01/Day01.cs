namespace AdventOfCodeCSharp.Day01;

public class Day01
{
    const int StartPosition = 50;

    public int Execute()
    {
        string[] lines = GetInput();

        var currentPosition = StartPosition;

        var currentNumberOfZeros = 0;

        for(var i=0; i<lines.Length; i++)
        {
            var rawLine = lines[i];
            var parsedLine = SafeDial.ParseLine(rawLine);

            if (parsedLine.Direction == RotationDirection.Left)
            {
                var dialResult = SafeDial.DialToLeft(currentPosition, parsedLine.DialSize);
                currentNumberOfZeros += dialResult.TotalClicks;
                currentPosition = dialResult.NewPosition;
            } else if (parsedLine.Direction == RotationDirection.Right)
            {
                var dialResult = SafeDial.DialToRight(currentPosition, parsedLine.DialSize);
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
