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
    public int currentLevel;

    public GameObject target;
    public GameObject barrierLong;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GetComponent<UIManager>();
        
        currentLevel = 1;
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
        UpdateUI(currentLevel);
        StartCoroutine(ViewTargetsTimer());
    }

    // Setting up each level using data-oriented 
    private void SetUpLevel()
    {
        // Instantiate targets
        for (int i = 0; i < levels[currentLevel].numOfTargets; i++)
        {
            Instantiate(target, levels[currentLevel].targetPos[i], Quaternion.identity);
        }

        // Instantiate barriers if any
        if (levels[currentLevel].numOfBarriers != 0)
        {
            for (int i = 0; i < levels[currentLevel].numOfBarriers; i++)
            {
                Instantiate(target, levels[currentLevel].barrierPos[i], Quaternion.identity);
            }
        }
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

