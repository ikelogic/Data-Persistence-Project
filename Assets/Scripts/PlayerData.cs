#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[DefaultExecutionOrder(1000)]
public class PlayerData : MonoBehaviour
{

    public string playerName;

    public static PlayerData instance;
    private void Awake()
    {
        IntializeSingleton();

    }
    public void SaveName(string name)
    {
        playerName = name;
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
