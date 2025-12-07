namespace AdventOfCodeCSharp.Day07;

public record BeamStream
{
    public BeamStream(int x, int y)
    {
        CurrentCoordinate = new Coordinate(x, y);
    }

    public BeamStream(Coordinate coordinate)
    {
        CurrentCoordinate = coordinate;
    }

    public Coordinate CurrentCoordinate { get; set; }
}
