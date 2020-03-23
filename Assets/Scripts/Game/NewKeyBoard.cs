using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NewKeyBoard : MonoBehaviour
{
	[SerializeField] private Game game = null;
    [SerializeField] private MistakeChecker mistakeChecker = null;

	private BoardTile activeTile = null;
	private bool readyToPress = false;
    private List<BoardTile> hightlightedTiles = new List<BoardTile>();
    private AudioManager audioManager = null;

    private void Awake(){
        audioManager = AudioManager.Instance;
    }

	private void Update() {
        //Debug
        if(gameObject.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.Keypad0)) ClearButtonPressed();
            if (Input.GetKeyDown(KeyCode.Keypad1)) NumericButtonPressed(1);
            if (Input.GetKeyDown(KeyCode.Keypad2)) NumericButtonPressed(2);
            if (Input.GetKeyDown(KeyCode.Keypad3)) NumericButtonPressed(3);
            if (Input.GetKeyDown(KeyCode.Keypad4)) NumericButtonPressed(4);
            if (Input.GetKeyDown(KeyCode.Keypad5)) NumericButtonPressed(5);
            if (Input.GetKeyDown(KeyCode.Keypad6)) NumericButtonPressed(6);
            if (Input.GetKeyDown(KeyCode.Keypad7)) NumericButtonPressed(7);
            if (Input.GetKeyDown(KeyCode.Keypad8)) NumericButtonPressed(8);
            if (Input.GetKeyDown(KeyCode.Keypad9)) NumericButtonPressed(9);
        }
    }

    public void TilePressed(BoardTile pressedTile) {
        if (game.Playing) {
            Debug.Log("Display keyboard", pressedTile);
            if(activeTile != null)
                ResetActiveTile();    	
            activeTile = pressedTile;
            activeTile.TileBackgroundColor = BoardTile.pressedBackgroundColor;
            readyToPress = false;
            MarkHnVTileLines();
            mistakeChecker.MakeTileValuesHighlighted(pressedTile.Value);
            WaitToReleaseButton();
            audioManager.PlaySFX(0);
        }
    }

    public void NumericButtonPressed(int value) {
        if (readyToPress) {
        	if(activeTile != null && !activeTile.Constant)
            {
	            Debug.Log($"Pressed {value} button");
                
                mistakeChecker.AddTileValue(activeTile, value);
                game.Moves++;
                activeTile.Value = value;
                mistakeChecker.MakeTileValuesHighlighted(value);
                audioManager.PlaySFX(0);
	        }
        }
    }

    public void ClearButtonPressed() {
        if (readyToPress) {
            if(activeTile != null && !activeTile.Constant)
            {
            	Debug.Log("Pressed CLEAR button");
                mistakeChecker.RemoveTileValue(activeTile);
            	activeTile.Value = 0;
	            game.Moves++;
	        }
            ResetActiveTile();
            activeTile = null;
            audioManager.PlaySFX(0);
        }
    }

    private void ResetActiveTile(){
        activeTile.TileBackgroundColor = BoardTile.defaultBackgroundColor;
        HideHnVMarkTileLines();
        mistakeChecker.MakeTileValuesDefaultColor();
    }

    private void MarkHnVTileLines() {
        Vector3 origin = activeTile.transform.position - new Vector3(5f, 0f, 0f);
        Vector3 direction = transform.right;
        LayerMask mask = LayerMask.GetMask("BoardTile");
        Debug.DrawRay(origin, direction * 10f, Color.yellow);

        var multipleHits = Physics2D.RaycastAll(origin, direction, 10, mask);
        foreach (var raycastHit in multipleHits){
            var hitTile = raycastHit.collider.GetComponent<BoardTile>();
            hightlightedTiles.Add(hitTile);
            hitTile.TileBackgroundColor -= BoardTile.highlighterBackgroundColor;
        }

        origin = activeTile.transform.position - new Vector3(0f, 5f, 0f);
        direction = transform.up;
        Debug.DrawRay(origin, direction * 10f, Color.yellow);

        multipleHits = Physics2D.RaycastAll(origin, direction, 10, mask);
        foreach (var raycastHit in multipleHits){
            var hitTile = raycastHit.collider.GetComponent<BoardTile>();
            hightlightedTiles.Add(hitTile);
            hitTile.TileBackgroundColor -= BoardTile.highlighterBackgroundColor;
        }
    }

    private void HideHnVMarkTileLines()
    {
        foreach (BoardTile tempTile in hightlightedTiles) {
            tempTile.TileBackgroundColor = BoardTile.defaultBackgroundColor;
        }
        hightlightedTiles.Clear();
    }

    private async void WaitToReleaseButton() {
        while (Input.anyKey || Input.touchCount != 0) {
            await Task.Delay(100);
        }

        Debug.Log("Button/touch released");
        await Task.Delay(50);
        readyToPress = true;
    }
}
