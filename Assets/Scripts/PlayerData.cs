#if UNITY_EDITOR
using System.IO;
using TMPro;
using UnityEditor;
using UnityEditor.Overlays;

#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[DefaultExecutionOrder(1000)]
public class PlayerData : MonoBehaviour
{

    public string playerName;
    public int highScore;
    public string highScoreName;

    public static PlayerData instance;
    private void Awake()
    {
        IntializeSingleton();
        LoadHighScore();
    }
    public void SaveName(string name)
    {
        playerName = name;
    }
    public void TrySaveHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            highScoreName = playerName;
            SaveHighScore();
        }
    }

    [System.Serializable]
    public class HighScoreData
    {
        public string playerName;
        public int score;
    }
    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData
        {
            playerName = highScoreName,
            score = highScore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string savePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            highScore = data.score;
            highScoreName = data.playerName;
        }

    }
    private bool IntializeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return false;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        return true;
    }
}
