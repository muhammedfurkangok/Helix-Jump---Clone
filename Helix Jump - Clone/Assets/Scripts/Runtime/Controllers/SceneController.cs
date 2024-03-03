using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
        
        Time.timeScale = 1f;
    }

    public void Shop()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }
}
