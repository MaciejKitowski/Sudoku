using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

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

    /*string texture = "Assets/Resources/Textures/Turner.png";
    Texture2D inputTexture = (Texture2D)Resources.LoadAssetAtPath(texture, typeof(Texture2D));*/


    

	void Start () 
    {
        //XmlLevelsEasy = 

        //XmlLevelsEasy = Resources.Load("levelsEasyXMLprefab.xml") as TextAsset;

        //Debug.Log(XmlLevelsEasy.name);

        //string str = "42";

        /*Debug.Log(str);
        Debug.Log(int.Parse(str[0].ToString()));*/
        

       /* mediumLevels.Add(new Level());


        mediumLevels[0].bestMoves = 10;
        mediumLevels[0].bestTime = 600F;

        for (int i = 0; i < 81; ++i)
        {
            mediumLevels[0].arena[i].display = true;
            mediumLevels[0].arena[i].value = i + 15;
        }



        easyLevels.Add(new Level());

        easyLevels[0].bestMoves = 1;
        easyLevels[0].bestTime = 125F;
        
        for(int i = 0; i < 81; ++i)
        {
            easyLevels[0].arena[i].display = true;
            easyLevels[0].arena[i].value = 1;
        }

        easyLevels[0].arena[20].display = false;

        easyLevels.Add(new Level());

        easyLevels[1].bestMoves = 2;
        easyLevels[1].bestTime = 225F;

        for (int i = 0; i < 81; ++i)
        {
            easyLevels[1].arena[i].display = true;
            easyLevels[1].arena[i].value = i + 5;
        }*/

        //Save();
	}
}
