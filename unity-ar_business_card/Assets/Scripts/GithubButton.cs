using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GithubButton : URLButton
{
    [SerializeField]
    string gitHubURL;   
    void Start()
    {
        url = gitHubURL;
    }
}
