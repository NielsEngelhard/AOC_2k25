namespace AdventOfCodeCSharp.Day04.P2;

public static class AdvancedPaperAccessCalculator
{
    const int CountThreshold = 4;
    const char PaperRollChar = '@';


    public static long Execute(char[][] paperStack)
    {
        var total = 0;
        var stop = false;

        while (!stop)
        {
            var result = CalculateIteration(paperStack);
            total += result.Count; // Total

            if (result.Count == 0)
            {
                stop = true;
            } else
            {
                paperStack = MarkPaperStacks(paperStack, result);
            }
        }

        return total;
    }

    public static char[][] MarkPaperStacks(char[][] paperStack, IList<Position> positions)
    {
        foreach(var position in positions)
        {
            paperStack[position.Y][position.X] = 'X';
        }

        return paperStack;
    }

    public static IList<Position> CalculateIteration(char[][] paperStack)
    {        
        IList<Position> positions = new List<Position>();

        // Vertical
        for(int y=0; y<paperStack.Length; y++)
        {
            //Console.WriteLine("");
            // Horizontal
            for (int x=0; x < paperStack[y].Length; x++)
            {
                var currentSquareIsPaperRoll = paperStack[y][x] == PaperRollChar;
                if (currentSquareIsPaperRoll)
                {
                    var currentPosition = new Position { X = x, Y = y };

                    var nAdjecentRolls = CountAdjecentRollsForIndex(paperStack, currentPosition);
                    if (nAdjecentRolls < CountThreshold) // Threshold of 4
                    {
                        //paperStack[y][x] = 'X'; // Dit werkt niet want dan gaat ie de rollen weghalen
                        positions.Add(currentPosition);
                    }
                }

                //Console.Write(paperStack[y][x]);
            }
        }

        return positions;
    }

    public static long CountAdjecentRollsForIndex(char[][] paperStack, Position centerPosition)
    {
        int paperRollCount = 0;

        int nAdjecentPositionToCheck = 1;

        Position startPosition = new Position { X = centerPosition.X - nAdjecentPositionToCheck, Y = centerPosition.Y - nAdjecentPositionToCheck };
        Position endPosition = new Position { X = centerPosition.X + nAdjecentPositionToCheck, Y = centerPosition.Y + nAdjecentPositionToCheck };

        Position currentPosition = startPosition;

        while (currentPosition.Y != endPosition.Y+1) { // FF checken of de laatste nu wel word meegepakt
            var isOutOfBounds = currentPosition.X < 0 || currentPosition.Y < 0 || currentPosition.X > paperStack.First().Length-1 || currentPosition.Y > paperStack.Length-1;
            var isCurrentPosition = currentPosition == centerPosition;

            // Position should be checked
            if (!isOutOfBounds && !isCurrentPosition)
            {
                var positionContainsPaperRoll = paperStack[currentPosition.Y][currentPosition.X] == PaperRollChar;
                if (positionContainsPaperRoll) paperRollCount++;
            }

            var isEndOfRow = currentPosition.X == centerPosition.X + nAdjecentPositionToCheck;

            // Calculate next position
            currentPosition = new Position
            {
                X = isEndOfRow ? startPosition.X : currentPosition.X + 1,
                Y = isEndOfRow ? currentPosition.Y + 1 : currentPosition.Y
            };
        }

        return paperRollCount;
    }
}
