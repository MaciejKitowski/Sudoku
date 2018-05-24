using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    private BoardTileGroup[,] tileGroups = new BoardTileGroup[3, 3];

	void Start () {
        foreach (Transform tile in transform) {
            int x = (int)char.GetNumericValue(tile.name[0]);
            int y = (int)char.GetNumericValue(tile.name[2]);

            tileGroups[x, y] = tile.GetComponent<BoardTileGroup>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
