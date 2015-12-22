using UnityEngine;
using System.Collections;

public class MarkView : MonoBehaviour
{

    public Sprite CrossSpite;
    public Sprite NoughtSprite;

    public int Column;
    public int Row;

    private BoardView BoardView;
    private SpriteRenderer Renderer;
    private BoxCollider2D Collider;

    // Use this for initialization
    void Start()
    {
        this.BoardView = GetComponentInParent<BoardView>();
        this.Renderer = GetComponent<SpriteRenderer>();
        this.Collider = GetComponent<BoxCollider2D>();
        BoardView.Register(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (BoardView.OnPutMarkRequested(Column, Row))
        {
            Become(BoardView.GetGame().GetMark(Column, Row));
        }
    }

    public void Become(Mark mark)
    {
        Renderer.sprite = SpriteOf(mark);
        Renderer.enabled = mark != Mark.Unmarked;
        Collider.enabled = mark == Mark.Unmarked;
    }

    private Sprite SpriteOf(Mark mark)
    {
        if (mark == Mark.Cross)
        {
            return CrossSpite;
        }
        if (mark == Mark.Nought)
        {
            return NoughtSprite;
        }
        return null;
    }

}
