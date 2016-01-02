using UnityEngine;
using System.Collections;
using System;

public class ViewComponent : MonoBehaviour, IGameListener {
    
    protected GameController gameController;

    public void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }

    public void Start()
    {
        gameController.RegisterViewComponent(this);
    }

    public virtual void OnGameOver(IGame game, Line winnerLine, Mark mark)
    {

    }

    public virtual void OnNextPlayerTurn(IGame game, Mark mark)
    {

    }

    public virtual void OnPutMark(IGame game, int column, int row, Mark mark)
    {

    }

}
