namespace AdventOfCodeCSharp.Day04.P1;

public static class PaperAccessCalculator
{
    const int CountThreshold = 4;
    const char PaperRollChar = '@';


    public static long Calculate(char[][] paperStack)
    {        
        var nAvailableRolls = 0;

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
                    var nAdjecentRolls = CountAdjecentRollsForIndex(paperStack, new Position { X = x, Y = y });
                    if (nAdjecentRolls < CountThreshold) // Threshold of 4
                    {
                        //paperStack[y][x] = 'X'; // Dit werkt niet want dan gaat ie de rollen weghalen
                        nAvailableRolls += 1;
                    }
                }

                //Console.Write(paperStack[y][x]);
            }
        }

        return nAvailableRolls;
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

