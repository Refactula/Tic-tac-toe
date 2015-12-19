using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour
{

    public int Column;
    public int Row;

    public GameObject Scripts;
    public Sprite CrossSprite;
    public Sprite NoughtSprite;

    private GameView GameView;

    // Use this for initialization
    void Start()
    {
        GameView = Scripts.GetComponent("GameView") as GameView;
        GameView.RegisterCell(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameView.OnPutMarkRequested(Column, Row);
    }

    public void Become(TicTacToeGame.Mark mark)
    {
        SpriteRenderer renderer = GetComponent("SpriteRenderer") as SpriteRenderer;
        renderer.sprite = SpriteOf(mark);
    }

    private Sprite SpriteOf(TicTacToeGame.Mark mark)
    {
        switch (mark)
        {
            case TicTacToeGame.Mark.Cross:
                return CrossSprite;
            case TicTacToeGame.Mark.Nought:
                return NoughtSprite;
        }
        return null;
    }

}
