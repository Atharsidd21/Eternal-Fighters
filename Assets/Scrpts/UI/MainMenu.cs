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
    public GameObject Background1;
    public GameObject Background2;

    void Start()
    {
        Background1.SetActive(true);
        Background2.SetActive(false);
        mainMenu.SetActive(true);
        SelectCharacterAndStageMenu.SetActive(false);
        optionMenu.SetActive(false);
        controlMenu.SetActive(false);
    }

    public void PlayButtonClicked()
    {
         Background1.SetActive(false);
        Background2.SetActive(true);
        mainMenu.SetActive(false);
        SelectCharacterAndStageMenu.SetActive(true);
      
    }
    public void OptionButtonClicked()
    {
         Background1.SetActive(false);
        Background2.SetActive(true);
         mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
     public void ControlsButtonClicked()
    {
         Background1.SetActive(false);
        Background2.SetActive(true);
         optionMenu.SetActive(false);
        controlMenu.SetActive(true);
    }
    public void ExitButtonClicked()
    {
        Application.Quit();

    }
    public void BackButtonClicked()
    {
         Background1.SetActive(true);
        Background2.SetActive(false);
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
