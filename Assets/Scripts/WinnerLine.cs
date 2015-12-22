using UnityEngine;
using System.Collections;

public class WinnerLine : MonoBehaviour {
    
    private BoardView BoardView;
    
    void Start ()
    {
        this.BoardView = GetComponentInParent<BoardView>();
    }
	
	void Update () {
	
	}

}
