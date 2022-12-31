using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WininngScene : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene("Start Scene");
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene("Space Shooter");
    }
    public void ExitButton()
    {
        Application.Quit(); 
    }
}
