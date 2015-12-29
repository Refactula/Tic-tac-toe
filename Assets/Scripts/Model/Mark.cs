using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Mark
{
    Unmarked,
    Cross,
    Nought,
}

public static class MarkExtensions
{
    public static Mark Opposite(this Mark mark) {
        switch (mark)
        {
            case Mark.Cross: return Mark.Nought;
            case Mark.Nought: return Mark.Cross;
            default: return mark;
        }
    }
}