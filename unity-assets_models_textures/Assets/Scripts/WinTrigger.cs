using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Timer TimerScript;
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
        }
    }
}
