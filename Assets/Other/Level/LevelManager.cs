using System.IO;
using System.Xml;
using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{
    public static List<Level> easyLevels = new List<Level>();
    public static List<Level> mediumLevels = new List<Level>();
    public static List<Level> hardLevels = new List<Level>();

    public static void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Level>));

        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsEasy.xml"), FileMode.Create)) serializer.Serialize(stream, easyLevels);
        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsMedium.xml"), FileMode.Create)) serializer.Serialize(stream, mediumLevels);
        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsHard.xml"), FileMode.Create)) serializer.Serialize(stream, hardLevels);
    }

    public static void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Level>));

        if (File.Exists(Path.Combine(Application.persistentDataPath, "levelsEasy.xml")))
        {
            using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsEasy.xml"), FileMode.Open)) easyLevels = (List<Level>)serializer.Deserialize(stream);
            using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsMedium.xml"), FileMode.Open)) mediumLevels = (List<Level>)serializer.Deserialize(stream);
            using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "levelsHard.xml"), FileMode.Open)) hardLevels = (List<Level>)serializer.Deserialize(stream);
        }
        else createNewXML();
    }

    private static void createNewXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Level>));

        TextAsset XmlLevelsEasy = Resources.Load("levelsEasyXMLprefab") as TextAsset;
        TextAsset XmlLevelsMedium = Resources.Load("levelsMediumXMLprefab") as TextAsset;
        TextAsset XmlLevelsHard = Resources.Load("levelsHardXMLprefab") as TextAsset;

        using (StringReader reader = new StringReader(XmlLevelsEasy.text)) easyLevels = (List<Level>)serializer.Deserialize(reader);
        using (StringReader reader = new StringReader(XmlLevelsMedium.text)) mediumLevels = (List<Level>)serializer.Deserialize(reader);
        using (StringReader reader = new StringReader(XmlLevelsHard.text)) hardLevels = (List<Level>)serializer.Deserialize(reader);

        Save();
    }
}
