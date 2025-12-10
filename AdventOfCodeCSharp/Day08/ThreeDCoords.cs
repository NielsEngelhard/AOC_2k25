namespace AdventOfCodeCSharp.Day08;

public record ThreeDCoords
{
    public int Id { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }

    public ThreeDCoords(int id, int x, int y, int z)
    {
        Id = id;
        X = x;
        Y = y;
        Z = z;
    }
}
