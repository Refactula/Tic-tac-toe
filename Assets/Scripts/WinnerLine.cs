using UnityEngine;
using System.Collections;
using System;

public class WinnerLine : MonoBehaviour, TicTacToeGame.IListener {

    public GameObject Scripts;

    public Sprite HorizontalLineSprite;
    public Sprite VertinalLineSprite;
    public Sprite DiagonalLineSprite;

    private GameView GameView;

	// Use this for initialization
	void Start () {
        GameView = Scripts.GetComponent("GameView") as GameView;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPutSucceeded(int column, int row, TicTacToeGame.Mark mark)
    {

    }

    public void OnPutFailed(int column, int row, string reason)
    {

    }

    public void OnGameOver(TicTacToeGame.Mark winnerMark, int variant)
    {
        SpriteRenderer renderer = GetComponent("SpriteRenderer") as SpriteRenderer;
        int column = TicTacToeGame.GameOverVariants[variant, 1, 0];
        int row = TicTacToeGame.GameOverVariants[variant, 1, 1];
        GameObject centerCell = GameView.GetCell(column, row).gameObject;
        gameObject.transform.position = centerCell.transform.position;
        switch (variant)
        {
            case 0: case 1: case 2:
                renderer.sprite = VertinalLineSprite;
                break;
            case 3: case 4: case 5:
                renderer.sprite = HorizontalLineSprite;
                break;
            case 6:
                renderer.sprite = DiagonalLineSprite;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;
            case 7:
                renderer.sprite = DiagonalLineSprite;
                break;
        }
        renderer.enabled = true;
    }
}
