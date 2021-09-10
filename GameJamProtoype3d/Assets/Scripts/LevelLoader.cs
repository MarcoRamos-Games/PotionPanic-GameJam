using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentScene;

   
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

   public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        AudioManager.instance.PlayBackgrounMusic();
        Time.timeScale = 1;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }
    public void LoadNextScene()
    {
        Debug.Log("simon");
        SceneManager.LoadScene(currentScene + 1);
        AudioManager.instance.PlayBackgrounMusic();
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayMenuMusic();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
