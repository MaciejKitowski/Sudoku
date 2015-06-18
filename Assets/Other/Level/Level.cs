using UnityEngine;
using System.Collections;

public class Level
{
    public int bestMoves = 0;
    public float bestTime = 0;

    public struct areaField
    {
        public bool display;
        public int value;
    }

    public areaField[] arena = new areaField[81];
}
