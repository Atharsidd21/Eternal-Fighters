using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject SelectCharacterAndStageMenu;
    public GameObject optionMenu;
    public GameObject controlMenu;

    void Start()
    {
        mainMenu.SetActive(true);
        SelectCharacterAndStageMenu.SetActive(false);
        optionMenu.SetActive(false);
        controlMenu.SetActive(false);
    }

    public void PlayButtonClicked()
    {
        mainMenu.SetActive(false);
        SelectCharacterAndStageMenu.SetActive(true);
    }
    public void OptionButtonClicked()
    {
         mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
     public void ControlsButtonClicked()
    {
         optionMenu.SetActive(false);
        controlMenu.SetActive(true);
    }
    public void ExitButtonClicked()
    {
        Application.Quit();

    }
    public void BackButtonClicked()
    {
         mainMenu.SetActive(true);
        SelectCharacterAndStageMenu.SetActive(false);
        optionMenu.SetActive(false);
        controlMenu.SetActive(false);
    }

    public void SelectCharacterClicked(string sceneName)
    {
      SceneManager.LoadScene(sceneName);
    }
    public void SelectStageClicked(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    

}
