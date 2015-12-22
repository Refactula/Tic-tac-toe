using UnityEngine;
using System.Collections.Generic;

public class Cell : MonoBehaviour {

    public Sprite CrossSprite;
    public Sprite NoughtSprite;

    private Field Field;
    private SpriteRenderer Renderer;

    public Mark Mark;

    private IList<Line> Lines = new List<Line>();

    void Awake()
    {
        this.Field = GetComponentInParent<Field>();
        this.Renderer = GetComponent<SpriteRenderer>();
    }

    public void AddLine(Line line)
    {
        Lines.Add(line);
    }

    void OnMouseDown()
    {
        if (Field.IsGameOvered() || Mark != Mark.Unmarked)
        {
            return;
        }
        Mark = Field.NextMark();
        Renderer.sprite = (Mark == Mark.Cross) ? CrossSprite : NoughtSprite;
        Renderer.enabled = true;
        foreach (var line in Lines)
        {
            if (line.DetectGameOver())
            {
                // Only one line should apper even if multiple are possible
                return;
            }
        }
        Field.OnCellMarked();
    }

}
