using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CinemachineController : MonoBehaviour
{
    [SerializeField]  private GameObject vcam1;
    [SerializeField]  private GameObject vcam2;
    [SerializeField] private GameObject selectMenu;
    [SerializeField] private GameObject mainMenu;


    public void ChangeButton()
    {
        vcam1.SetActive(false);
        mainMenu.SetActive(false);
        StartCoroutine(bekle());
        
        
    }

    public void MainMenu()
    {
        selectMenu.SetActive(false);
        vcam1.SetActive(true);
        StartCoroutine(bekle2());
        mainMenu.SetActive(false);
    }

    IEnumerator bekle()
    {
        yield return new WaitForSecondsRealtime(2);
        selectMenu.SetActive(true);
    }
    IEnumerator bekle2()
    {
        yield return new WaitForSecondsRealtime(2);
        mainMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
    
}
