using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // pause menu
    public void OnClickPauseButton()
    {
        // pause pannel active
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        // game should pause untile unpause
    }

    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
    }
}
