using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject creditsScreen;

    private void Start()
    {
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void ContinueGame()
    {
        //load latest checkpoint
    }

    public void StartGame()
    {
        Debug.Log("Click button");
        SceneManager.LoadScene(1);
    }

    public void OptionsScreen()
    {
        optionsScreen.SetActive(true);
    }

    public void CreditsScreen()
    {
        creditsScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
