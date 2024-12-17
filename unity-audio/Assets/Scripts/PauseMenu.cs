using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public Canvas PauseCanvas;
    private bool paused;
    public AudioMixerSnapshot[] snapshots;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
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
        snapshots[1].TransitionTo(0.0f);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseCanvas.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseCanvas.gameObject.SetActive(false);
        snapshots[0].TransitionTo(0.5f);
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
