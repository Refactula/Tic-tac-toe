using UnityEngine;
using System.Collections;

public class Mark : MonoBehaviour {

    public Sprite CrossSpite;
    public Sprite NoughtSprite;

    public int Column;
    public int Row;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Mark (" + Column + ", " + Row + ") has been clicked");
    }
}
