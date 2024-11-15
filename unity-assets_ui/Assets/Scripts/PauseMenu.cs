using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Canvas PauseCanvas;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
                paused = false;
            } else
            {
                Pause();
                paused = true;
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseCanvas.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseCanvas.gameObject.SetActive(false);
    }
}
