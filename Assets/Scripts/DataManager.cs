using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Singleton to save player data
    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Data persistence between sessions
    [System.Serializable]
    class SaveData
    {
        public int hsLevel1;
        public int hsLevel2;
        public int hsLevel3;
        public int hsLevel4;
        public int hsLevel5;
        public int hsLevel6;
        public int hsLevel7;
        public int hsLevel8;
        public int hsLevel9;
        public int hsLevel10;
    }

    public void SaveHighScores()
    {

    }

    public void LoadHighScores()
    {

    }
}
