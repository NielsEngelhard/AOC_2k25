namespace AdventOfCodeCSharp.Day08;

public record DistanceBetweenCoords
{
    public required IList<ThreeDCoords> Coords { get; set; }
    public required double Distance { get; set; }
}
