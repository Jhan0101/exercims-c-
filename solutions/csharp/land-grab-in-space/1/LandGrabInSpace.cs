public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}


public struct Plot : IEquatable<Plot>
{
    private readonly Coord c1;
    private readonly Coord c2;
    private readonly Coord c3;
    private readonly Coord c4;

    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        this.c1 = c1;
        this.c2 = c2;
        this.c3 = c3;
        this.c4 = c4;
    }

    public int LongestSide()
    {
        int minX = Math.Min(Math.Min(c1.X, c2.X), Math.Min(c3.X, c4.X));
        int maxX = Math.Max(Math.Max(c1.X, c2.X), Math.Max(c3.X, c4.X));
        int minY = Math.Min(Math.Min(c1.Y, c2.Y), Math.Min(c3.Y, c4.Y));
        int maxY = Math.Max(Math.Max(c1.Y, c2.Y), Math.Max(c3.Y, c4.Y));

        return Math.Max(maxX - minX, maxY - minY);
    }

    public bool Equals(Plot other)
    {
        return c1.Equals(other.c1)
            && c2.Equals(other.c2)
            && c3.Equals(other.c3)
            && c4.Equals(other.c4);
    }

    public override bool Equals(object obj)
    {
        return obj is Plot other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(c1, c2, c3, c4);
    }
}

public class ClaimsHandler
{
    private readonly HashSet<Plot> claims = new HashSet<Plot>();
    private Plot lastClaim;
    private Plot longestClaim;
    private int longestSide = -1;

    public void StakeClaim(Plot plot)
    {
        claims.Add(plot);
        lastClaim = plot;

        int side = plot.LongestSide();
        if (side > longestSide)
        {
            longestSide = side;
            longestClaim = plot;
        }
    }

    public bool IsClaimStaked(Plot plot)
    {
        return claims.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return lastClaim.Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        return longestClaim;
    }
}