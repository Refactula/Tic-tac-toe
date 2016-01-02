using UnityEngine;
using System.Collections;
using System;

public class MarkView : ViewComponent {

    public Sprite CrossSprite;
    public Sprite NoughtSprite;

    public int Column;
    public int Row;
    
    void OnMouseDown()
    {
        gameController.OnClicked(Column, Row);
    }

    public override void OnPutMark(IGame game, int column, int row, Mark mark)
    {
        if (column == Column && row == Row)
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = mark == Mark.Cross ? CrossSprite : NoughtSprite;
            renderer.enabled = true;
            DisableCollider();
        }
    }

    public override void OnGameOver(IGame game, Line winnerLine, Mark mark)
    {
        DisableCollider();
    }

    private void DisableCollider()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

}
