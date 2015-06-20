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

    public struct areaField
    {
        public bool display;
        public int value;
    }

    [XmlArray("ArenaValues"), XmlArrayItem("Area")]
    public areaField[] arena = new areaField[81];
}
