using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCanvas : MonoBehaviour
{
    public Timer TimerScript;
    // Start is called before the first frame update
    void Start()
    {
        TimerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            TimerScript.enabled = true;
        }
    }
}
