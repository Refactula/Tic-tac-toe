using UnityEngine;
using System.Collections;

public class MarkView : MonoBehaviour {

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
        var renderer = GetComponent("SpriteRenderer") as SpriteRenderer;
        var collider = GetComponent("BoxCollider2D") as BoxCollider2D;
        renderer.sprite = CrossSpite;
        renderer.enabled = true;
        collider.enabled = false;
    }

}
