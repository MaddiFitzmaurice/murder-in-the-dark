using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    // Singleton to save player data
    public static DataManager Instance { get; private set; }

    // Used to figure out size of high score list
    // Adjust if you remove or add levels
    const int numberOfLevels = 10;
    
    public int[] levelHS;

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

            levelHS = new int[numberOfLevels];
        }
    }

    // Class wrapper for data persistence between sessions
    [System.Serializable]
    class SaveData
    {
        public int[] hsLevel;
    }

    // Save high scores to json file
    public void SaveHighScores()
    {
        
        SaveData dataToSave = new SaveData();
        dataToSave.hsLevel = new int[levelHS.Length];

        // Loop through each level high score and save it
        for (int i = 0; i < levelHS.Length; i++)
        {
            dataToSave.hsLevel[i] = levelHS[i];
        }

        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }

    // Load high scores in from json file
    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);

            for (int i = 0; i < levelHS.Length; i++)
            {
                levelHS[i] = loadedData.hsLevel[i];
            }
        }
        
    }
}
