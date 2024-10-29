using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ResultManager : MonoBehaviour 
{
    public GameObject ResultPanel;
    public Text ResultText;
    public FightingController[] fightingController;
    public EnemyAI[] opponentAI;
   
 

    void Update()
    {
        foreach (FightingController fightingController in fightingController)
        {
            if(fightingController.gameObject.activeSelf && fightingController.currentHealth<=0)
            {
                SetResult("You Lose!");
                return;
            }
        }
        foreach (EnemyAI opponentAI in opponentAI )
        {
            if(opponentAI .gameObject.activeSelf && opponentAI .currentHealth<=0)
            {
                SetResult("You Win!");
                return;
            }
        }
    }

    void SetResult(string result)
    {
        ResultText.text = result;
        ResultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale =1f;
        SceneManager.LoadScene(0);
        
        
    }

   

    


}
