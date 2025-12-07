namespace AdventOfCodeCSharp.Day07;

public record BeamStream
{
    public int Value { get; set; }
    public Coordinate CurrentCoordinate { get; set; }

    public BeamStream(int x, int y, int value)
    {
        CurrentCoordinate = new Coordinate(x, y);
        Value = value;
    }

    public BeamStream(Coordinate coordinate, int value = 1)
    {
        CurrentCoordinate = coordinate;
        Value = value;
    }

}
