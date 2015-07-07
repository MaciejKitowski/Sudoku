using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugAddingLevelsController : MonoBehaviour 
{
    public bool active;
    public bool isConstant;
    public bool canSave;
    public numpadController numpad;

    private Button constantButton;
    private DebugArenaLineController[] line;
    
    void Awake()
    {
        line = new DebugArenaLineController[9];
        for (int i = 0; i < 9; ++i)
        {
            line[i] = gameObject.transform.GetChild(1).gameObject.transform.GetChild(i + 1).GetComponent<DebugArenaLineController>();
        }
        constantButton = gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
        numpad = gameObject.transform.GetComponentInChildren<numpadController>();
        numpad.hide();
    }

    public void setActive(bool state)
    {
        gameObject.SetActive(state);
        active = state;
    }

    public void reset()
    {
        isConstant = false;
        constantButton.image.color = Color.white;
        canSave = false;
        for (int i = 0; i < 9; ++i) line[i].reset();
    }

    public void buttonToggleConstant()
    {
        Debug.LogWarning("[DEBUG] - Toggle constant mode");

        if(!numpad.isDisplayed())
        {
            if (isConstant)
            {
                isConstant = false;
                constantButton.image.color = Color.white;
            }
            else
            {
                isConstant = true;
                constantButton.image.color = Color.red;
            }
        }
    }

    public void buttonBack()
    {
        Debug.LogWarning("[DEBUG] - Back to menu");
        
        if(!numpad.isDisplayed())
        {
            setActive(false);
        }
    }

    public void buttonEasy()
    {
        Debug.LogWarning("[DEBUG] - Save to easy difficult");

        canSave = true;

        for (int i = 0; i < 9; ++i) if (!line[i].checkArea()) canSave = false;

        if(!numpad.isDisplayed() && canSave)
        {
            LevelManager.easyLevels.Add(new Level());

            for (int i = 0; i < 9; ++i)
            {
                LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].bestMoves = 0;
                LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].bestTime = 0F;

                LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].value = null;
                LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].display = null;

                LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].lineNumber = i+1;

                for (int j = 0; j < 9; ++j)
                {
                    LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].value += line[i].area[j].value.ToString();

                    if (line[i].area[j].canEdit == true) LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].display += "F";
                    else LevelManager.easyLevels[LevelManager.easyLevels.Count - 1].lines[i].display += "T";
                }
            }

            reset();
        }
    }

    public void buttonMedium()
    {
        Debug.LogWarning("[DEBUG] - Save to medium difficult");

        canSave = true;

        for (int i = 0; i < 9; ++i) if (!line[i].checkArea()) canSave = false;

        if(!numpad.isDisplayed() && canSave)
        {
            LevelManager.mediumLevels.Add(new Level());

            for (int i = 0; i < 9; ++i)
            {
                LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].bestMoves = 0;
                LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].bestTime = 0F;

                LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].value = null;
                LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].display = null;

                LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].lineNumber = i + 1;

                for (int j = 0; j < 9; ++j)
                {
                    LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].value += line[i].area[j].value.ToString();

                    if (line[i].area[j].canEdit == true) LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].display += "F";
                    else LevelManager.mediumLevels[LevelManager.mediumLevels.Count - 1].lines[i].display += "T";
                }
            }

            reset();
        }
    }

    public void buttonHard()
    {
        Debug.LogWarning("[DEBUG] - Save to hard difficult");

        canSave = true;

        for (int i = 0; i < 9; ++i) if (!line[i].checkArea()) canSave = false;

        if(!numpad.isDisplayed() && canSave)
        {
            LevelManager.hardLevels.Add(new Level());

            for (int i = 0; i < 9; ++i)
            {
                LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].bestMoves = 0;
                LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].bestTime = 0F;

                LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].value = null;
                LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].display = null;

                LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].lineNumber = i + 1;

                for (int j = 0; j < 9; ++j)
                {
                    LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].value += line[i].area[j].value.ToString();

                    if (line[i].area[j].canEdit == true) LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].display += "F";
                    else LevelManager.hardLevels[LevelManager.hardLevels.Count - 1].lines[i].display += "T";
                }
            }

            reset();
        }
    }
}
