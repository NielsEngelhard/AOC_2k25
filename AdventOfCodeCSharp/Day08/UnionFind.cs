namespace AdventOfCodeCSharp.Day08;

public class UnionFind
{
    private int[] parent;
    private int[] rank;

    // Small bug in this method because I use the 0 index as a dummy and ignore it, so only if 1 is different it is ok
    public bool AllConnected()
    {        
        var firstParent = Find(1);

        // Skip 0 index
        for (var i =1; i< parent.Length; i++)
        {
            if (firstParent != Find(i))
            {
                return false;
            }
        }

        return true;
    }

    public UnionFind(int size)
    {
        parent = new int[size];
        rank = new int[size];

        // Initially, each element is its own parent
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }

    // Find with path compression
    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]); // Path compression
        }
        return parent[x];
    }

    // Union by rank
    public bool Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX == rootY)
            return false; // Already in same set

        // Union by rank
        if (rank[rootX] < rank[rootY])
        {
            parent[rootX] = rootY;
        }
        else if (rank[rootX] > rank[rootY])
        {
            parent[rootY] = rootX;
        }
        else
        {
            parent[rootY] = rootX;
            rank[rootX]++;
        }

        return true;
    }

    // Check if two elements are in the same set
    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
