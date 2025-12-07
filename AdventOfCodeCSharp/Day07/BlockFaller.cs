using System;

namespace AdventOfCodeCSharp.Day07;

public static class BlockFaller
{
    public static int TotalSplits = 0;

    public static void Beam(string[][] grid)
    {
        var startCoordinates = FindStartCoordinates(grid);
        ProcessBeamStreams(grid, startCoordinates);
    }

    public static void ProcessBeamStreams(string[][] grid, Coordinate start)
    {
        var currentRow = new List<BeamStream> { new(start.X, start.Y, 1) };

        // Boven naar beneden dus 1x loop per ROW
        for(var y=0; y<grid.Length; y++)
        {
            PlotCurrentRow(grid, currentRow);
            currentRow = CreateNewRecordsForRow(grid, y);            
        }

        PrintGrid(grid);

        Console.WriteLine("Total combinations: " + CountLastRowItems(grid));
        Console.WriteLine("Total splits! " + TotalSplits);
    }

    public static List<BeamStream> CreateNewRecordsForRow(string[][] grid, int y)
    {
        var result = new List<BeamStream>();

        for (var x=0; x<grid.First().Length; x++)
        {
            var currentItem = grid[y][x];

            // Dan is het sws een cijfer en dus een stream
            if (currentItem != "." && currentItem != "^" && currentItem != "S")// Lelijk hard code duplicate maarja boeie
            {
                result.Add(new BeamStream(new Coordinate(x, y), int.Parse(currentItem)));
            }
        }
        return result;
    }

    public static void PlotCurrentRow(string[][] grid, List<BeamStream> beamStreams)
    {
        foreach (var beamStream in beamStreams)
        {
            HandleSingleBeamstreamIteration(grid, beamStream);
        }
    }

    public static IList<BeamStream> HandleSingleBeamstreamIteration(string[][] grid, BeamStream beamStream)
    {
        var downPosition = new Coordinate(beamStream.CurrentCoordinate.X, beamStream.CurrentCoordinate.Y + 1);

        // Bottom reached
        if (downPosition.Y >= grid.Length)
        {
            return [];
        }

        var charInGrid = grid[downPosition.Y][downPosition.X];

        if (charInGrid == "^") // Split - go right and left
        {
            TotalSplits++;

            var leftCoords = new Coordinate(downPosition.X - 1, downPosition.Y);
            var rightCoords = new Coordinate(downPosition.X + 1, downPosition.Y);

            var leftBeamStream = new BeamStream(leftCoords, beamStream.Value);
            var rightBeamStream = new BeamStream(rightCoords, beamStream.Value);

            var characterLeft = grid[leftCoords.Y][leftCoords.X];
            var leftAlreadyContainsNumber = characterLeft != "." && characterLeft != "^";
            if (leftAlreadyContainsNumber)
            {
                // OPTELLEN
                var val = int.Parse(characterLeft);
                grid[leftCoords.Y][leftCoords.X] = (val + beamStream.Value).ToString();
                leftBeamStream.Value = val + beamStream.Value;
            } else
            {
                grid[leftCoords.Y][leftCoords.X] = beamStream.Value.ToString();
            }

            var characterRight = grid[rightCoords.Y][rightCoords.X];
            var rightAlreadyContainsNumber = characterRight != "." && characterRight != "^";
            if (rightAlreadyContainsNumber)
            {
                // OPTELLEN
                var val = int.Parse(characterRight);
                grid[rightCoords.Y][rightCoords.X] = (val + beamStream.Value).ToString();
                rightBeamStream.Value = val + beamStream.Value;
            }
            else
            {
                grid[rightCoords.Y][rightCoords.X] = beamStream.Value.ToString();
            }

            return [leftBeamStream, rightBeamStream];
        } else // Not a split always go down
        {
            if (charInGrid == ".")
            {
                grid[downPosition.Y][downPosition.X] = beamStream.Value.ToString();
                return [new(downPosition, beamStream.Value)];
            } else
            {
                // Bij elkaar optellen naar beneden toe ipv overschrijven
                var currentValue = int.Parse(grid[downPosition.Y][downPosition.X]);

                grid[downPosition.Y][downPosition.X] = (beamStream.Value + currentValue).ToString();
                return [new(downPosition, beamStream.Value + currentValue)];
            }
        }

    }

    public static int CountLastRowItems(string[][] grid)
    {
        var result = 0;

        var y = grid.Length - 1; // last row

        for (var x = 0; x < grid.First().Length; x++)
        {
            var currentItem = grid[y][x];

            // Dan is het sws een cijfer en dus een stream
            if (currentItem != "." && currentItem != "^" && currentItem != "S")// Lelijk hard code duplicate maarja boeie
            {
                result += int.Parse(currentItem);
            }
        }
        return result;
    }

    public static Coordinate FindStartCoordinates(string[][] grid)
    {
        var firstRow = grid.First();

        for (var x = 0; x < firstRow.Length; x++)
        {
            var currentChar = firstRow[x];

            if (currentChar != "S") continue;

            return new Coordinate(x, 0);
        }

        throw new Exception("START NOT FOUND");
    }

    public static void PrintGrid(string[][] grid)
    {
        for (int y = 0; y < grid.Length; y++)
        {
            Console.WriteLine("");
            for (int x = 0; x < grid.First().Length; x++) // Kan wel want toch even lang allemaal (zie input)
            {
                Console.Write(grid[y][x]);
            }
        }
    }
}