using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private TextMeshProUGUI _levelText;

    public static UIManager Instance;
    private UIManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    private void Update()
    {
        LevelUpdate();
    }

    // pause menu
    public void OnClickPauseButton()
    {
        // pause pannel active
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        // game should pause untile unpause
    }

    // resume button
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
    }

    // restart button
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Rocket._fuelCount = 100;
    }

    //exit to main menu button
    public void OnClickExitButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Rocket._fuelCount = 100;


    }

    public void LevelUpdate()
    {
        _levelText.text = "Level - " + (SceneManager.GetActiveScene().buildIndex).ToString();
    }

}
