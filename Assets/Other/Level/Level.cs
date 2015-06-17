using UnityEngine;
using System.Collections;

public class Level
{
    public int bestMoves = 0;
    public float bestTime = 0;

    public bool[] displayValue = new bool[81];
    public int[] arenaValue = new int[81];
}
