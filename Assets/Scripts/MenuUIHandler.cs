#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas;
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = mainCanvas.GetComponentInChildren<TMP_InputField>();
        if (!string.IsNullOrEmpty(PlayerData.instance.playerName))
        {
            inputField.text = PlayerData.instance.playerName;
        }
    }
    public void StartGame()
    {
        PlayerData.instance.SaveName(inputField.text);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}