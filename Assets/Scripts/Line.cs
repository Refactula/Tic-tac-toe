using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

    public GameObject CellObject0;
    public GameObject CellObject1;
    public GameObject CellObject2;

    private Field Field;
    private SpriteRenderer Renderer;

    private Cell Cell0;
    private Cell Cell1;
    private Cell Cell2;

    void Awake()
    {
        Field = GetComponentInParent<Field>();
        Renderer = GetComponent<SpriteRenderer>();

        Cell0 = CellObject0.GetComponent<Cell>();
        Cell1 = CellObject1.GetComponent<Cell>();
        Cell2 = CellObject2.GetComponent<Cell>();
    }

    void Start()
    {
        Cell0.AddLine(this);
        Cell1.AddLine(this);
        Cell2.AddLine(this);
    }

    public bool DetectGameOver()
    {
        if (Cell0.Mark == Cell1.Mark && Cell1.Mark == Cell2.Mark)
        {
            Debug.Log(Cell0.Mark + " = " + Cell1.Mark + " = " + Cell2.Mark);
            Renderer.enabled = true;
            Field.OnGameOvered();
            return true;
        }
        return false;
    }

}