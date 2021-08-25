using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public Text attemptsText;
    public Text levelText;
    public Button hintButton;
    public GameObject endGameScreen;

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

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
