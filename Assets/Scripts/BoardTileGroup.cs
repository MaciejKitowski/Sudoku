using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTileGroup : MonoBehaviour {
    private BoardTile[,] tiles = new BoardTile[3, 3];

	void Start () {
        foreach(Transform tile in transform) {
            int x = (int)char.GetNumericValue(tile.name[0]);
            int y = (int)char.GetNumericValue(tile.name[2]);

            tiles[x, y] = tile.GetComponent<BoardTile>();
        }		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
