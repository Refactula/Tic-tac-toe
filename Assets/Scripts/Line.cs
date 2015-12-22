using System;

public class Line {
    
    public readonly int FromColumn;
    public readonly int FromRow;

    public readonly int ToColumn;
    public readonly int ToRow;

    public readonly int ColumnStep;
    public readonly int RowStep;

    public readonly int Size;

    public Line(int fromColumn, int fromRow, int toColumn, int toRow)
    {
        int width = Math.Abs(toColumn - fromColumn);
        int height = Math.Abs(toRow - fromRow);
        if (width > 0 && height > 0 && width != height)
        {
            throw new ArgumentException("Not an actual line");
        }
        this.Size = Math.Max(width, height) + 1;
        this.FromColumn = fromColumn;
        this.FromRow = fromRow;
        this.ToColumn = toColumn;
        this.ToRow = toRow;
        this.ColumnStep = Math.Sign(ToColumn - FromColumn);
        this.RowStep = Math.Sign(ToRow - FromRow);
    }

}
