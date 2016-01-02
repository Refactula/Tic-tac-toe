using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Line
{

    public const int Size = 3;

    public static readonly Line[] AllPossibleLines =
    {
        // Horizontal
        new Line(0, 0, 1, 0),
        new Line(0, 1, 1, 0),
        new Line(0, 2, 1, 0),

        // Vertical 
        new Line(0, 0, 0, 1),
        new Line(1, 0, 0, 1),
        new Line(2, 0, 0, 1),

        // Diagonal
        new Line(0, 0, 1, 1),
        new Line(2, 0, -1, 1),
    };

    private int column;
    private int columnStep;

    private int row;
    private int rowStep;

    public int ColumnStep { get { return columnStep; } }
    public int RowStep { get { return rowStep; } }

    public Line(int column, int row, int columnStep, int rowStep)
    {
        this.column = column;
        this.row = row;
        this.columnStep = columnStep;
        this.rowStep = rowStep;
    }

    public int GetColumn(int index)
    {
        return column + index * columnStep;
    }

    public int GetRow(int index)
    {
        return row + index * rowStep;
    }

}
