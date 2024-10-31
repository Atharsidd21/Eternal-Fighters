using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public GameObject Players;
    private GameObject[] allCharacters;
  
    private int currentIndex = 0;
    void Start()
    {
       allCharacters = new GameObject[Players.transform.childCount];
       for (int i = 0; i< Players.transform.childCount;i++)
       {
        allCharacters[i]  = Players.transform.GetChild(i).gameObject;
        allCharacters[i].SetActive(false);
        
       }
       if(PlayerPrefs.HasKey("SelectedCharacterIndex"))
       {
        currentIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
       }
       ShowCurrentCharacter();
    }

    void ShowCurrentCharacter()
    {
        foreach(GameObject character in allCharacters)
        {
            character.SetActive(false);
           
        }
        allCharacters[currentIndex].SetActive(true);
  
    }
    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % allCharacters.Length;
        ShowCurrentCharacter();
    }
    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + allCharacters.Length) % allCharacters.Length;
        ShowCurrentCharacter();
    }
    public void OnYesButtonClick( string sceneName)
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex" , currentIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneName);
    }
}
