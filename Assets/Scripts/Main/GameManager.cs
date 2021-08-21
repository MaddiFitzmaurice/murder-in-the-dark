using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    public bool isGameActive;
    public bool isViewing;
    public bool isAiming;
    public bool isTesting;

    public UIManager uiManager;

    public LevelData[] levels;
    
    public int currentLevel;
    public int attemptNum;

    public Light worldLight;
    public GameObject murderLight;
    public GameObject target;
    public GameObject barrierLong;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GetComponent<UIManager>();
        player = FindObjectOfType<PlayerController>();

        if (!isTesting)
        {
            currentLevel = 1;
            StartLevel();
        }
        // Used to test new levels
        else
        {
            isGameActive = true;
            isAiming = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Advance to next level if all targets have been hit
        if (GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            // Check to see if reached end of game
            if (currentLevel != levels.Length)
            {
                currentLevel++;
                StartLevel();
            }
            // End game logic here
            else
            {
                Debug.Log("You Win!");
            }
            
        }
    }

    // Initiate level start-up
    public void StartLevel()
    {
        ClearBarriers();
        player.ResetKnife();
        attemptNum = 0;
        isGameActive = true;
        isViewing = true;
        isAiming = false;
        worldLight.gameObject.SetActive(true);
        murderLight.gameObject.SetActive(false);
        UpdateUI();
        SetUpLevel();
        StartCoroutine(ViewTargetsTimer());
    }

    // Set up level's targets and barriers using data-oriented design principles
    private void SetUpLevel()
    {
        // Instantiate targets
        for (int i = 0; i < levels[currentLevel - 1].numOfTargets; i++)
        {
            Instantiate(target, levels[currentLevel - 1].targetPos[i], Quaternion.identity);
        }

        // Instantiate barriers if any
        if (levels[currentLevel - 1].numOfBarriers != 0)
        {
            for (int i = 0; i < levels[currentLevel - 1].numOfBarriers; i++)
            {
                Instantiate(barrierLong, levels[currentLevel - 1].barrierPos[i], Quaternion.Euler(0, 90, 0));
            }
        }
    }

    private void ClearBarriers()
    {
        var barriers = GameObject.FindGameObjectsWithTag("Barrier");
        if (barriers != null)
        {
            for (int i = barriers.Length - 1; i >= 0; i--)
            {
                Destroy(barriers[i]);
            }
        }
        
    }

    // Viewing time for the player to see where the targets are
    IEnumerator ViewTargetsTimer()
    {
        yield return new WaitForSeconds(levels[currentLevel - 1].viewingTime);
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

    private void UpdateUI()
    {
        uiManager.UpdateAttemptsText(attemptNum);
        uiManager.UpdateLevelText(levels[currentLevel - 1].levelNumber);
        uiManager.UpdateToBeatText(levels[currentLevel - 1].attemptToBeat);
    }
}

