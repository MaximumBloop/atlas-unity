using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailButton : URLButton
{
    [SerializeField]
    string email;
    [SerializeField]
    string subject;
    [SerializeField]
    string body;
    
    void Start()
    {
        url = $"mailto:{email}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
    }
}
