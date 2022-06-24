using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public static Data Instance; // added
    public InputField playerName; // added
    public Text bestScore; // added

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadPlayerName();
    }

    [System.Serializable]
    class SaveData
    {
        public InputField playerName; // added
        public Text ScoreText; // the one we want to save and load
        public Text bestScore; // added
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();
        
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }
}
