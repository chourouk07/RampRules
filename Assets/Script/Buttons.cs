using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject ControlsUI;
    public GameObject MenuUI;
    public static void MoveToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PauseGame()
    {

        Time.timeScale = 0;
        pauseUI.SetActive(true);
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public static void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void MainEnable () 
    { 
        MenuUI.SetActive(true);
        ControlsUI.SetActive(false);
    }

    public void Controls () 
    {
        ControlsUI.SetActive(true);
        MenuUI.SetActive(false);
    }
}
