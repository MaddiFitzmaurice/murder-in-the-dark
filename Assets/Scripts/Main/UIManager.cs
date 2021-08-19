using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text attemptsText;
    public Text levelText;
    public Text toBeatText;

    public void UpdateAttemptsText(int amount)
    {
        attemptsText.text = "Attempts\n" + amount; 
    }

    public void UpdateLevelText(int levelNum)
    {
        levelText.text = "Level\n" + levelNum.ToString();
    }

    public void UpdateToBeatText(int toBeat)
    {
        toBeatText.text = "To Beat\n" + toBeat.ToString();
    }
}
