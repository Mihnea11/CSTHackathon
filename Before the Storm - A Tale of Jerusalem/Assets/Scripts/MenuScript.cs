using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject mainWindow;
    public GameObject aboutWindow;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void About()
    {
        mainWindow.SetActive(false);
        aboutWindow.SetActive(true);
    }

    public void CloseAbout()
    {
        mainWindow.SetActive(true);
        aboutWindow.SetActive(false);
    }
}
