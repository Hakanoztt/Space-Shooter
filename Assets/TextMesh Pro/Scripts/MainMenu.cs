using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
  public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Space Shooter");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Start Scene");
    }
 
}
