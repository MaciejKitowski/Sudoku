using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private Board board = null;

	void Start () {
        board.BoardFinishedLoading += BoardFinishedLoading;
	}

    private void BoardFinishedLoading() {
        Debug.Log("Board finished loading, set level on arena");
    }
}
