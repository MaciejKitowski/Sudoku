using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeChecker : MonoBehaviour
{
	[SerializeField] private GameObject[] keyButtons = null;

    private Dictionary<int, List<BoardTile>> tileValues = new Dictionary<int, List<BoardTile>>();
    private int lastKey = 1;

    public void SetTileValues(BoardTile[,] tiles){
    	for(int i = 1; i <= 9; ++i)
    	{
    		tileValues.Add(i, new List<BoardTile>());
    	}

    	for(int y = 0; y < 9; ++y)
		{
			for(int x = 0; x < 9; ++x)
			{
				if(tiles[x, y].Value != 0)
				{
					tileValues[tiles[x, y].Value].Add(tiles[x, y]);
				}
			}
		}
		SetHiddenButtons();
    }

    public void AddTileValue(BoardTile boardTile, int value){
    	if(boardTile.Value == 0) {
            boardTile.Value = value;
    		tileValues[boardTile.Value].Add(boardTile);
    		HideButton(boardTile.Value);
    	}
        else {
            if(boardTile.Value != value) {
                tileValues[boardTile.Value].Remove(boardTile);
                ShowButton(boardTile.Value);
                boardTile.Value = value;
                tileValues[boardTile.Value].Add(boardTile);
                HideButton(boardTile.Value);
            }
        }
    }

    public void RemoveTileValue(BoardTile boardTile){
    	if(boardTile.Value != 0){
    		tileValues[boardTile.Value].Remove(boardTile);
    		ShowButton(boardTile.Value);
    	}
    }

    public void MakeTileValuesHighlighted(int key){
    	if(key != 0) {
    		MakeTileValuesDefaultColor();
    		foreach (var list in tileValues[key]) 
	    	{
	    		list.TileColor = BoardTile.pressedColor;
	    	}
	    	lastKey = key;
    	}
    }

    public void MakeTileValuesDefaultColor()
    {
    	foreach (var list in tileValues[lastKey]) 
    	{
    		if(list.Constant)
    			list.TileColor = BoardTile.constantBackground;
    		else 
    			list.TileColor = BoardTile.defaultColor; 
    	}
    }

    private void SetHiddenButtons(){
    	for(int i = 1; i <= 9; i++){
    		HideButton(i);
    	}
    }

    private void HideButton(int index){
    	if(tileValues[index].Count >= 9){
    		keyButtons[index-1].SetActive(false);
    	}
    }

    private void ShowButton(int index){
    	if(tileValues[index].Count < 9){
    		keyButtons[index-1].SetActive(true);
    	}
    }
}
