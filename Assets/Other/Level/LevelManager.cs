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

    public static void tests()
    {
        easyLevels.Add(new Level());

        easyLevels[easyLevels.Count - 1].bestMoves = easyLevels.Count * 2;
        easyLevels[easyLevels.Count - 1].bestTime = easyLevels.Count * 5F;

        //easyLevels[easyLevels.Count - 1].test = "1111111111111111";

        easyLevels[easyLevels.Count - 1].value = "123456789123456789123456789123456789123456789123456789123456789123456789123456789";
        easyLevels[easyLevels.Count - 1].display = "TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTFFFTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT";

        /*for (int i = 0; i < 81; ++i)
        {
            easyLevels[easyLevels.Count - 1].arena[i].display = true;
            easyLevels[easyLevels.Count - 1].arena[i].value = easyLevels.Count * 2 + 1;
        }*/
    }

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
        else
        {
            //There should be creating new XML file
            Save();
        }
    }



	void Start () 
    {
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
