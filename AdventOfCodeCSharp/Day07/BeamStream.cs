namespace AdventOfCodeCSharp.Day07;

public record BeamStream
{
    public long Value { get; set; }
    public Coordinate CurrentCoordinate { get; set; }

    public BeamStream(int x, int y, long value)
    {
        CurrentCoordinate = new Coordinate(x, y);
        Value = value;
    }

    public BeamStream(Coordinate coordinate, long value = 1)
    {
        CurrentCoordinate = coordinate;
        Value = value;
    }

}
