using UnityEngine;
using System.Collections;
using System;

public class WinningLineView : ViewComponent {

    /// <summary>
    /// Horizontal line sprite, that will be used to draw horizontal or vertical winning line.
    /// </summary>
    public Sprite HorizontalSprite;
    
    /// <summary>
    /// Diagonal line sprite that represents winning line from 0-2 to 2-0, and will be flipped to draw opposite line.  
    /// Is longer than horizontal line.
    /// </summary>
    public Sprite DiagonalSprite;
    
    /// <summary>
    /// Offset between the marks that will be applied if the line does not cross the center mark.
    /// By default this GameObject should be put in position that corresponds to the center mark.
    /// </summary>
    public float Offset;

    public override void OnGameOver(IGame game, Line winnerLine, Mark mark)
    {
        if (winnerLine == null)
            return;

        updatePosition(winnerLine);
        becomeVisible(winnerLine);
    }

    private void updatePosition(Line winnerLine)
    {
        int dx = winnerLine.GetColumn(1) - 1;
        int dy = winnerLine.GetRow(1) - 1;
        transform.Translate(dx * Offset, dy * Offset, 0);
    }

    private void becomeVisible(Line winnerLine)
    {
        var renderer = GetComponent<SpriteRenderer>();
        if (winnerLine.RowStep == 0)
        {
            // Horizontal line
            renderer.sprite = HorizontalSprite;
        }
        else if (winnerLine.ColumnStep == 0)
        {
            // Vertical line
            renderer.sprite = HorizontalSprite;
            transform.Rotate(0, 0, 90);
        }
        else if (winnerLine.ColumnStep == 1 && winnerLine.RowStep == 1)
        {
            // Diagonal line with flip
            renderer.sprite = DiagonalSprite;
            renderer.flipX = true;
        }
        else
        {
            // Diagonal line without flip
            renderer.sprite = DiagonalSprite;
        }
        renderer.enabled = true;
    }
}
