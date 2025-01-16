using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstagramButton : URLButton
{
    [SerializeField]
    string instagramURL;   
    void Start()
    {
        url = instagramURL;
    }
}
