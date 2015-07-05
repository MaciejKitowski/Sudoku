using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Collections;
using System.Xml.Serialization;

public class Statistics
{
    public float time;
    public int moves;
    [XmlIgnore]
    public Text timeTxt, movesTxt;
    
    public struct levelDetail
    {
        public float time;
        public int moves, wins;
        [XmlIgnore]
        public Text timeTxt, winsTxt, movesTxt;
    }
    public levelDetail easy, medium, hard;
}

public class StatisticsController : MonoBehaviour 
{
    public bool active;
    private Statistics stats;
    
	void Awake () 
    {
        stats = new Statistics();

        if (File.Exists(Path.Combine(Application.persistentDataPath, "Statistics.xml"))) Load();

        stats.timeTxt = gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.movesTxt = gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        stats.easy.timeTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.easy.winsTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.easy.movesTxt = gameObject.transform.GetChild(3).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        stats.medium.timeTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.medium.winsTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.medium.movesTxt = gameObject.transform.GetChild(4).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();

        stats.hard.timeTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.hard.winsTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>();
        stats.hard.movesTxt = gameObject.transform.GetChild(5).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<Text>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) setActive(false);
    }

    public void setActive(bool state)
    {
        active = state;
        gameObject.SetActive(state);
        if (state) updateTxt();
    }

    public void updateStats(SelectLevelController.difficult Difficult, bool isWon = false)
    {
        stats.moves += gameManager.moves;
        stats.time += gameManager.timer;

        if (Difficult == SelectLevelController.difficult.DIFFICULT_EASY) updateValues(ref stats.easy, isWon);
        else if (Difficult == SelectLevelController.difficult.DIFFICULT_MEDIUM) updateValues(ref stats.medium, isWon);
        else if (Difficult == SelectLevelController.difficult.DIFFICULT_HARD) updateValues(ref stats.hard, isWon);
    }

    private void updateValues(ref Statistics.levelDetail level, bool isWon)
    {
        level.moves += gameManager.moves;
        level.time += gameManager.timer;
        if (isWon) level.wins++;
    }

    private void updateTxt()
    {
        stats.timeTxt.text = transformToTime(stats.time);
        stats.movesTxt.text = stats.moves.ToString();

        stats.easy.timeTxt.text = transformToTime(stats.easy.time);
        stats.easy.winsTxt.text = stats.easy.wins.ToString();
        stats.easy.movesTxt.text = stats.easy.moves.ToString();

        stats.medium.timeTxt.text = transformToTime(stats.medium.time);
        stats.medium.winsTxt.text = stats.medium.wins.ToString();
        stats.medium.movesTxt.text = stats.medium.moves.ToString();

        stats.hard.timeTxt.text = transformToTime(stats.hard.time);
        stats.hard.winsTxt.text = stats.hard.wins.ToString();
        stats.hard.movesTxt.text = stats.hard.moves.ToString();
    }

    public void buttonBackToMenu()
    {
        Debug.Log("Back to menu button");
        gameManager.audio.play();
        setActive(false);
    }

    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Statistics));
        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "Statistics.xml"), FileMode.Create)) serializer.Serialize(stream, stats);
    }

    private void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Statistics));
        using (FileStream stream = new FileStream(Path.Combine(Application.persistentDataPath, "Statistics.xml"), FileMode.Open)) stats = serializer.Deserialize(stream) as Statistics;
    }

    private string transformToTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
