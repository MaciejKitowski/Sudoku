using UnityEngine;
using System.Collections;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Level
{
    [XmlElement(ElementName = "MovesRecord")]
    public int bestMoves = 0;
    [XmlElement(ElementName = "TimeRecord")]
    public float bestTime = 0;

    public struct Line
    {
        [XmlAttribute("number")]
        public int lineNumber;
        public string value;
        public string display; // T - display, F - not display
    }

    [XmlArray("ArenaHorizontalLines")]
    public Line[] lines = new Line[9];

    public int getValue(int pos)
    {
        if (pos <= 8) return int.Parse(lines[0].value[pos].ToString());
        else if (pos > 8 && pos <= 17) return int.Parse(lines[1].value[pos - 9].ToString());
        else if (pos > 17 && pos <= 26) return int.Parse(lines[2].value[pos - 18].ToString());
        else if (pos > 26 && pos <= 35) return int.Parse(lines[3].value[pos - 27].ToString());
        else if (pos > 35 && pos <= 44) return int.Parse(lines[4].value[pos - 36].ToString());
        else if (pos > 44 && pos <= 53) return int.Parse(lines[5].value[pos - 45].ToString());
        else if (pos > 53 && pos <= 62) return int.Parse(lines[6].value[pos - 54].ToString());
        else if (pos > 62 && pos <= 71) return int.Parse(lines[7].value[pos - 63].ToString());
        else if (pos > 71 && pos <= 80) return int.Parse(lines[8].value[pos - 72].ToString());

        Debug.LogError("Level get value ERROR");
        return 999;
    }

    public bool getDisplay(int pos)
    {
        if (pos <= 8) return checkStringDisplay(lines[0], pos);
        else if (pos > 8 && pos <= 17) return checkStringDisplay(lines[1], pos - 9);
        else if (pos > 17 && pos <= 26) return checkStringDisplay(lines[2], pos - 18);
        else if (pos > 26 && pos <= 35) return checkStringDisplay(lines[3], pos - 27);
        else if (pos > 35 && pos <= 44) return checkStringDisplay(lines[4], pos - 36);
        else if (pos > 44 && pos <= 53) return checkStringDisplay(lines[5], pos - 45);
        else if (pos > 53 && pos <= 62) return checkStringDisplay(lines[6], pos - 54);
        else if (pos > 62 && pos <= 71) return checkStringDisplay(lines[7], pos - 63);
        else if (pos > 71 && pos <= 80) return checkStringDisplay(lines[8], pos - 72);

        Debug.LogError("Level get display ERROR");
        return false;
    }

    private bool checkStringDisplay(Line lin, int pos)
    {
        switch(lin.display[pos].ToString())
        {
            case "T":
                return true;
            case "F":
                return false;
        }
        return false;
    }
}
