using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameController : MonoBehaviour, IGameController, IGameListener {

    private const Mark HumanPlayerMark = Mark.Cross;

    private Game game = new Game();

    public IGame Game
    {
        get
        {
            return game;
        }
    }

    void Awake()
    {
        game.Subscribe(new ComputerPlayer(this, Mark.Nought, new System.Random(), ComputerPlayer.HARDNESS_HARD));
        game.Subscribe(this);
    }

    // Request from human player.
    public void OnClicked(int column, int row)
    {
        game.Put(column, row, HumanPlayerMark);
    }

    // Request from computer player.
    public void RequestPut(int column, int row, Mark mark)
    {
        StartCoroutine("PutLater", new object[3] { column, row, mark });
    }

    public void RegisterMarkView(MarkView markView)
    {
        game.Subscribe(markView);
    }

    public void OnPutMark(IGame game, int column, int row, Mark mark)
    {

    }

    public void OnGameOver(IGame game, Line winnerLine, Mark mark)
    {
        StartCoroutine("RestartLater");
    }

    public void OnNextPlayerTurn(IGame game, Mark mark)
    {

    }

    IEnumerator PutLater(object[] parms)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1F, 0.7F));
        int column = (int) parms[0];
        int row = (int) parms[1];
        Mark mark = (Mark) parms[2];
        game.Put(column, row, mark);
    }

    IEnumerator RestartLater()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
