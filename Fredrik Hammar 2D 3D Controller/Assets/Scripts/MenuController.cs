using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject controlsScreen;
    public GameObject continueButton;

    private void Start()
    {
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        controlsScreen.SetActive(false);
        continueButton.SetActive(false);

        //Section below should be activated after a checkpoint system has been created
        //if (Player has a checkpoint)
        //{
        //    continueButton.SetActive(true);
        //}
        //else
        //{
        //    continueButton.SetActive(false);
        //}
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMain();
        }
    }

    public void ContinueGame()
    {
        //load latest checkpoint
    }

    public void StartGame()
    {        
        SceneManager.LoadScene(1);
    }

    public void OptionsScreen()
    {
        optionsScreen.SetActive(true);
    }

    public void ControlsScreen()
    {
        controlsScreen.SetActive(true);
    }

    public void CreditsScreen()
    {
        creditsScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideMenues()
    {
        creditsScreen.SetActive(false);
        optionsScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    //function temporarily replacing a pause function, for the sake of testing
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
}
