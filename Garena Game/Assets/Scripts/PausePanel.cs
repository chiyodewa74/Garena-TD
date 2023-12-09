using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
   [SerializeField] GameObject pausePanel;
   public void activatePanel()
   {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
   }

    public void deactivatePanel() 
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void mainMenu()
    {
        Debug.Log("Back To Menu");
    }
}
