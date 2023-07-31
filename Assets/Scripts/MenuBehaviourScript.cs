using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviourScript : MonoBehaviour
{
    public void OnClicInStartButton()
    {
        SceneManager.LoadScene("Level-1-School");
    }
    public void OnClicInBackMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClicExitGame()
    {
        Application.Quit();
    }
}
