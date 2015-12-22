using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Field : MonoBehaviour {
    private static readonly Mark[] MoveSequence = { Mark.Cross, Mark.Nought };

    public int UnmarkedCells;

    private bool GameOver = false;

    private int MoveNumber = 0;

    public Mark NextMark()
    {
        return MoveSequence[MoveNumber++ % MoveSequence.Length];
    }

    public void OnGameOvered()
    {
        GameOver = true;
        StartCoroutine("RestartGame");
    }

    public bool IsGameOvered()
    {
        return GameOver;
    }

    public void OnCellMarked()
    {
        UnmarkedCells--;
        if (!GameOver && UnmarkedCells == 0)
        {
            OnGameOvered();
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
