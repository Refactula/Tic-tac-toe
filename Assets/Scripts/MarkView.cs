using UnityEngine;
using System.Collections;

public class MarkView : MonoBehaviour {

    public Sprite CrossSprite;
    public Sprite NoughtSprite;

    public int Column;
    public int Row;

    private GameController gameController;

    void Awake()
    {
        gameController = GetComponentInParent<GameController>();
    }

}
