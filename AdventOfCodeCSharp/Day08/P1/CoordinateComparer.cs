namespace AdventOfCodeCSharp.Day08.P1;

public static class CoordinateComparer
{
    const int Take = 1000;

    public static long FindAllCoordinateGroups(IList<ThreeDCoords> coords)
    {
        var allDistances = MapAllDistancesBetweenCoords(coords);

        // Only do it for the X lowest distances
        var lowestDistances = allDistances.OrderBy(d => d.Distance).Take(Take).ToList();

        return UnionFindDistances(lowestDistances, coords.Count);
    }

    // https://www.geeksforgeeks.org/dsa/introduction-to-disjoint-set-data-structure-or-union-find-algorithm/
    // Disjoint Set (Union-Find Data Structure)
    public static long UnionFindDistances(IList<DistanceBetweenCoords> distances, int totalCoordinates)
    {
        var unionFind = new UnionFind(totalCoordinates + 1);

        for(var i=0; i<distances.Count; i++)
        {
            var distance = distances[i];

            int id1 = distance.Coords[0].Id;
            int id2 = distance.Coords[1].Id;

            unionFind.Union(id1, id2);
        }

        // Get all groups
        var groups = Enumerable.Range(1, totalCoordinates)
            .GroupBy(i => unionFind.Find(i))
            .Select(g => g.ToList())
            .OrderByDescending(g => g.Count)
            .ToList();

        var multipliedTopThreeResult = groups
            .OrderByDescending(g => g.Count)
            .Take(3) // Top 3
            .Select(g => g.Count)
            .Aggregate((a, b) => a * b);

        return multipliedTopThreeResult;
    }

    public static IList<DistanceBetweenCoords> MapAllDistancesBetweenCoords(IList<ThreeDCoords> coords)
    {
        var distanceList = new List<DistanceBetweenCoords>();

        // For each coordinate
        for(var i = 0; i < coords.Count; i++)
        {
            // Compare to every other coordinate

            // j=i+1 because with an example of 5 items (5x5) you will have all combos with
            // 1 -> 2 3 4 5
            // 2 -> 3 4 5
            // 3 -> 4 5
            // 4 -> 5
            // 5 -> nothing
            for (var j=i+1; j<coords.Count; j++)
            {
                // Is the same
                if (i == j) continue;

                var firstCoords = coords[i];
                var secondsCoords = coords[j];

                var distance = CalculateDistanceBetweenThreeDCoords(firstCoords, secondsCoords);
                distanceList.Add(new DistanceBetweenCoords
                {
                    Distance = distance,
                    Coords = [ firstCoords, secondsCoords ],
                });
            }
        }

        return distanceList;
    }

    //Mathematical equation:
    // distance = sqrt( (x2 - x1)^2 + (y2 - y1)^2 + (z2 - z1)^2 )
    public static double CalculateDistanceBetweenThreeDCoords(ThreeDCoords first, ThreeDCoords second)
    {
        var powerOff = 2;

        var xPart = Math.Pow(second.X - first.X, powerOff);
        var yPart = Math.Pow(second.Y - first.Y, powerOff);
        var zPart = Math.Pow(second.Z - first.Z, powerOff);

        return Math.Sqrt(xPart + yPart + zPart);
    }    
}
