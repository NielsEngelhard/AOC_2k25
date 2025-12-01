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
                currentPosition = SafeDial.DialToLeft(currentPosition, parsedLine.DialSize);
            } else if (parsedLine.Direction == RotationDirection.Right)
            {
                currentPosition = SafeDial.DialToRight(currentPosition, parsedLine.DialSize);
            } else
            {
                throw new Exception("INVALID INPUT");
            }

            if (currentPosition == 0) // Hard coded but who cares, me not haha
            {
                currentNumberOfZeros++;
            }
        }

        return currentNumberOfZeros;
    }

    public string[] GetInput()
    {
        return [.. File.ReadLines("./Day01/real-input.txt")];
    }
}
