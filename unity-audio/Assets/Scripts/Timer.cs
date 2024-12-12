using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float _currentTime = 0.0f;
    private TimeSpan _time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        _time = TimeSpan.FromMinutes(_currentTime);

        TimerText.text = string.Format("{0}:{1:00}.{2:00}", _time.Hours, _time.Minutes, _time.Seconds);
    }

    void OnEnable()
    {
        Debug.Log("Enabled/Reset Timer");
        _currentTime = 0.0F;
        TimerText.color = Color.white;
        TimerText.fontSize = 48;
    }
}
