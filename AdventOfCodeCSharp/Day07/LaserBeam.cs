namespace AdventOfCodeCSharp.Day07;

public static class LaserBeam
{
    public static int TotalSplits = 0;

    public static void Beam(char[][] grid)
    {
        var startCoordinates = FindStartCoordinates(grid);
        ProcessBeamStreams(grid, startCoordinates);
    }

    public static void ProcessBeamStreams(char[][] grid, Coordinate start)
    {
        var beamStreams = new Stack<BeamStream>();
        beamStreams.Push(new(start.X, start.Y, 1));

        while(beamStreams.Count > 0)
        {
            var beamStream = beamStreams.Pop();
            var newBeamStreams = HandleSingleBeamstreamIteration(grid, beamStream);
            AddNewBeamStreams(beamStreams, newBeamStreams);
            //D7P1.PrintGrid(grid);
        }

        Console.WriteLine("Total splits! " + TotalSplits);
    }

    public static void AddNewBeamStreams(Stack<BeamStream> stack, IList<BeamStream> beamStreams)
    {
        foreach (var bs in beamStreams)
        {
            stack.Push(bs);
        }
    }

    public static IList<BeamStream> HandleSingleBeamstreamIteration(char[][] grid, BeamStream beamStream)
    {
        var downPosition = new Coordinate(beamStream.CurrentCoordinate.X, beamStream.CurrentCoordinate.Y + 1);

        // Bottom reached
        if (downPosition.Y >= grid.Length - 1)
        {
            return [];
        }

        var charInGrid = grid[downPosition.Y][downPosition.X];

        if (charInGrid == '.') // Not a split - go down
        {
            grid[downPosition.Y][downPosition.X] = '|';
            return [new (downPosition)];
        } else if (charInGrid == '^') // Split - go right and left
        {
            TotalSplits++;

            var leftCoords = new Coordinate(downPosition.X - 1, downPosition.Y);
            var rightCoords = new Coordinate(downPosition.X + 1, downPosition.Y);

            grid[leftCoords.Y][leftCoords.X] = '|';
            grid[rightCoords.Y][rightCoords.X] = '|';

            return [new (leftCoords), new (rightCoords)];
        }

        return [];
    }

    public static Coordinate FindStartCoordinates(char[][] grid)
    {
        var firstRow = grid.First();

        for (var x=0; x<firstRow.Length; x++)
        {
            var currentChar = firstRow[x];

            if (currentChar != 'S') continue;

            return new Coordinate(x, 0);
        }

        throw new Exception("START NOT FOUND");
    }
}
