using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject murderLight;
    public Light worldLight;

    public bool isGameActive;
    public bool isViewing;
    public bool isAiming;

    public UIManager uiManager;
    public LevelData[] levels;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GetComponent<UIManager>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void StartGame()
    {
        isGameActive = true;
        isViewing = true;
        isAiming = false;
        UpdateUI(1);
        StartCoroutine(ViewTargetsTimer());
    }

    // Viewing time for the player to see where the targets are
    IEnumerator ViewTargetsTimer()
    {
        yield return new WaitForSeconds(3);
        isViewing = false;
        isAiming = true;
        worldLight.gameObject.SetActive(false);
        murderLight.gameObject.SetActive(true);
    }

    // If the player has exceeded a certain amount of attempts,
    // Briefly show them the scene again.
    public void ViewHint()
    {
        
    }

    private void UpdateUI(int levelNum)
    {
        uiManager.UpdateAttemptsText(levelNum);
        uiManager.UpdateLevelText(levels[levelNum - 1].levelNumber);
        uiManager.UpdateToBeatText(levels[levelNum - 1].attemptToBeat);
    }
}

