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

    private int Column;
    private int ColumnStep;

    private int Row;
    private int RowStep;

    public Line(int column, int row, int columnStep, int rowStep)
    {
        this.Column = column;
        this.Row = row;
        this.ColumnStep = columnStep;
        this.RowStep = rowStep;
    }

    public int GetColumn(int index)
    {
        return Column + index * ColumnStep;
    }

    public int GetRow(int index)
    {
        return Row + index * RowStep;
    }

}
