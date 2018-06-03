using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchHistoryItem : MonoBehaviour {
    [SerializeField] private Text date = null;
    [SerializeField] private Text moves = null;
    [SerializeField] private Text time = null;

    public void SetMatch(LevelMatchHistory match) {
        date.text = match.StartDate.ToString("yyyy-MM-dd hh:mm");
        moves.text = match.Moves.ToString();
        time.text = match.ElapsedSeconds.ToString();
    }
}
