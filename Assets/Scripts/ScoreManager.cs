using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int bestScore;
    public string bestName;
    public string name;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void Start()
    {
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public string BestToText()
    {
        return $"BestScore: {bestName} : {bestScore}";
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = name;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.name;
            bestScore = data.score;
        }
    }

}
