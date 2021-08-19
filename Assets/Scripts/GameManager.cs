using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text killCountText;
    public Text attemptCountText;
    public GameObject murderLight;
    public Light worldLight;

    public bool isGameActive;
    public bool isViewing;
    public bool isAiming;

    public int killCount = 0;
    public int attemptCount = 0;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Will fix later
        if (killCount == 1)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void UpdateScore(int amount)
    {
        killCount += amount;
        killCountText.text = "Kills: " + killCount;
    }

    public void UpdateAttempts(int amount)
    {
        attemptCount += amount;
        attemptCountText.text = "Attempts: " + attemptCount;
    }

    public void StartGame()
    {
        isGameActive = true;
        isViewing = true;
        isAiming = false;
        UpdateScore(0);
        UpdateAttempts(0);
        StartCoroutine(ViewTargetsTimer());
    }

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
}

