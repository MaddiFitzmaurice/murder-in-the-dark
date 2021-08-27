using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    // Menu items
    public GameObject mainMenu;
    public GameObject highScoreMenu;
    public GameObject controlsMenu;
    public GameObject warningMenu;
    public GameObject altPlayButton;
    public GameObject areYouSureText;
    public GameObject resetButton;

    public Text[] highScoreLevelTexts;

    private DataManager dataManager;

    private bool warningActive = false;

    public void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
        dataManager.LoadHighScores();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void SeeHighScore()
    {
        altPlayButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        highScoreMenu.gameObject.SetActive(true);
        DisplayHighScoreTable();
    }

    public void SeeControls()
    {
        altPlayButton.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(true);
        highScoreMenu.gameObject.SetActive(false);
    }

    // Toggle yes/no confirmation on or off
    public void ShowHideResetWarning()
    {
        warningActive = !warningActive;
        areYouSureText.gameObject.SetActive(warningActive);
        warningMenu.gameObject.SetActive(warningActive);
        resetButton.gameObject.SetActive(!warningActive);
    }

    // Press yes to reset save data for high scores
    public void ResetHighScores()
    {
        for (int i = 0; i < dataManager.levelHS.Length; i++)
        {
            dataManager.levelHS[i] = 0;
        }
        dataManager.SaveHighScores();
        dataManager.LoadHighScores();
        ShowHideResetWarning();
        DisplayHighScoreTable();
    }

    // Show each level best attempt number
    public void DisplayHighScoreTable()
    {
        for (int i = 0; i < highScoreLevelTexts.Length; i++)
        {
            highScoreLevelTexts[i].text = dataManager.levelHS[i].ToString();
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }    
}
