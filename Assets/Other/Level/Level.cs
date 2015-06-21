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

    public string value;
    public string display; // T - display, F - not display

    public struct areaField
    {
        public bool display;
        public int value;
    }

    /*[XmlArray("ArenaValues"), XmlArrayItem("Area")]
    public areaField[] arena = new areaField[81];*/



    public int getValue(int pos)
    {
        return int.Parse(value[pos].ToString());
    }

    public bool getDisplay(int pos)
    {
        switch(display[pos].ToString())
        {
            case "T":
                return true;

            case "F":
                return false;

            default:
                Debug.Log("Return bool error");
                return false;
        }
    }
}
