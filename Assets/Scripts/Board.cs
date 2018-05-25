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
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) CheckBoard();
	}

    public void CheckBoard() {
        if (!CheckRows()) return;
        if (!CheckCols()) return;
        if (!CheckGroups()) return;
        
        Debug.LogWarning("Sudoku correct!");
    }

    private bool CheckRows() {
        int currentY = 0;

        for(int y = 0; y < 3; ++y) {
            for (int i = 0; i < 3; ++i, ++currentY) {
                int sum = 0;

                for (int x = 0; x < 3; ++x) {
                    var group = tileGroups[x, y];
                    sum += group.SumRow(i);
                }

                if (sum != 45) {
                    Debug.Log($"Incorrect row on y={currentY}");
                    return false;
                }
            }
        }

        return true;
    }

    private bool CheckCols() {
        int currentX = 0;

        for (int x = 0; x < 3; ++x) {
            for (int i = 0; i < 3; ++i, ++currentX) {
                int sum = 0;

                for (int y = 0; y < 3; ++y) {
                    var group = tileGroups[x, y];
                    sum += group.SumCol(i);
                }

                if (sum != 45) {
                    Debug.Log($"Incorrect row on x={currentX}");
                    return false;
                }
            }
        }

        return true;
    }

    private bool CheckGroups() {
        for (int y = 0; y < 3; ++y) {
            for (int x = 0; x < 3; ++x) {

                if(!tileGroups[x, y].CheckGroup()) {
                    Debug.Log($"Incorrect tile group [{x}, {y}]", tileGroups[x, y]);
                    return false;
                }
            }
        }

        return true;
    }
}
