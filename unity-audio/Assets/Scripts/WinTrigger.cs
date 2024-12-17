using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Timer TimerScript;
    public Canvas winCanvas;
    public Canvas pauseCanvas;
    public GameObject gameManager;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            TimerScript.TimerText.color = Color.green;
            TimerScript.TimerText.fontSize = 60;
            TimerScript.enabled = false;
            winCanvas.gameObject.SetActive(true);
            pauseCanvas.gameObject.SetActive(false);
            gameManager.SetActive(false);
            camera.GetComponent<AudioSource>().Stop();
            this.GetComponent<AudioSource>().Play();
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Cursor locked: " + Cursor.lockState + ", Cursor visible: " + Cursor.visible);
        }
    }
}
