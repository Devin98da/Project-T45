using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // play game
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    //quit game
    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    //exit to main menu button
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Rocket._fuelCount = 100;


    }
}
