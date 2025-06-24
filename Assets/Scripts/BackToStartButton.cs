using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToStartButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}