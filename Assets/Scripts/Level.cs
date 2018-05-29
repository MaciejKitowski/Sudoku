using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level {
    private int[,] board = new int[9, 9];
    private bool[,] displayable = new bool[9, 9];
    private List<LevelMatchHistory> history = new List<LevelMatchHistory>();
}

public class LevelMatchHistory {
    private bool wasWon = false;
    private bool finished = true;
    private int moves = 0;
    DateTimeOffset startDate = new DateTimeOffset();
    int elapsedSeconds = 0;
}
