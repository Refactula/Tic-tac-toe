using UnityEngine;
using System.Collections;
using System;

public class MarkView : MonoBehaviour, IGameListener {

    public Sprite CrossSprite;
    public Sprite NoughtSprite;

    public int Column;
    public int Row;

    private GameController gameController;

    void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }

    void Start()
    {
        gameController.RegisterMarkView(this);
    }

    void OnMouseDown()
    {
        gameController.OnClicked(Column, Row);
    }

    public void OnPutMark(IGame game, int column, int row, Mark mark)
    {
        if (column == Column && row == Row)
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = mark == Mark.Cross ? CrossSprite : NoughtSprite;
            renderer.enabled = true;
            DisableCollider();
        }
    }

    private void DisableCollider()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    public void OnGameOver(IGame game, Line winnerLine, Mark mark)
    {
        DisableCollider();
    }

    public void OnNextPlayerTurn(IGame game, Mark mark)
    {

    }
}
