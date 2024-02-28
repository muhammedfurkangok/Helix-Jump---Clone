using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private bool _isGameReady;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
        Debug.Log("isgameready");
        _isGameReady = true;
        Time.timeScale = 1f;
    }

    public void Shop()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }
}
