using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text attemptsText;
    public Text levelText;
    public Button hintButton;

    public void UpdateAttemptsText(int attemptNum)
    {
        attemptsText.text = "Attempts\n" + attemptNum.ToString(); 
    }

    public void UpdateLevelText(int levelNum)
    {
        levelText.text = "Level\n" + levelNum.ToString();
    }

    public void ViewHint(bool viewable)
    {
        hintButton.interactable = viewable;
    }
}
