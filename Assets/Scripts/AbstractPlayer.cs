using UnityEngine;
using System.Collections;

public abstract class AbstractPlayer {

    private Mark Mark;

    public void SetPlayingWith(Mark mark)
    {
        this.Mark = mark;
    }

    public Mark GetMark()
    {
        return Mark;
    }

}
