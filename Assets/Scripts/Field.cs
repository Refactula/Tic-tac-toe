using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {
    private static readonly Mark[] MoveSequence = { Mark.Cross, Mark.Nought };

    public bool GameOver = false;

    private int MoveNumber = 0;

    public Mark NextMark()
    {
        return MoveSequence[MoveNumber++ % MoveSequence.Length];
    }
}
