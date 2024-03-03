using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables
    
    public static bool gameOver;
    public static bool levelWin;
    public GameObject gameOverPannel;
    public GameObject levelWinPannel;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public static int CurrentLevelIndex;
    public static int noOfPassingRings;
    
    public Slider uiFillImage;
    public static bool mute;

    #endregion

    #region Private Variables

    public static  bool _isGameReady;

    #endregion


    #endregion
   

    private void Awake()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        noOfPassingRings = 0;
        gameOver = false;
        levelWin = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPannel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
        //update our slider
        float proggress = noOfPassingRings * 12.5f  / FindObjectOfType<HelixManager>().noOfRings;
        uiFillImage.value = proggress;

        currentLevelText.text = CurrentLevelIndex.ToString();
        nextLevelText.text = (CurrentLevelIndex + 1).ToString();
        if (levelWin)
        {
            levelWinPannel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

  
}
