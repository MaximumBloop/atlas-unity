using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedInButton : URLButton
{
    [SerializeField]
    string linkedInURL;   
    void Start()
    {
        url = linkedInURL;
    }
}
