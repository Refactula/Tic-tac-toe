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
    
    void Start()
    {
        this.BoardView = GetComponentInParent<BoardView>();
        this.Renderer = GetComponent<SpriteRenderer>();
        this.Collider = GetComponent<BoxCollider2D>();
        BoardView.Register(this);
    }
    
    void Update()
    {

    }

    void OnMouseDown()
    {
        BoardView.OnPutMarkRequested(Column, Row);
    }

    public void Become(Mark mark)
    {
        Renderer.sprite = SpriteOf(mark);
        Renderer.enabled = mark != Mark.Unmarked;
        Collider.enabled = mark == Mark.Unmarked;
    }

    private Sprite SpriteOf(Mark mark)
    {
        return (mark == Mark.Cross) ? CrossSpite : (mark == Mark.Nought) ? NoughtSprite : null;
    }

}
