using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ToggleStart()
    {
        SceneManager.LoadScene("Pre-Game Cut Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

