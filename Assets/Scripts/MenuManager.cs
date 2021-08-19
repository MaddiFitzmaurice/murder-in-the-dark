using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    // Menu items
    public GameObject mainMenu;
    public GameObject highScoreMenu;
    public GameObject controlsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void SeeHighScore()
    {
        mainMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        highScoreMenu.gameObject.SetActive(true);
    }

    public void SeeControls()
    {
        mainMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(true);
        highScoreMenu.gameObject.SetActive(false);
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
