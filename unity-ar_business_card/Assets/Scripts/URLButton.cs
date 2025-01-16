using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class URLButton : MonoBehaviour
{
    protected string url;

    void OnEnable()
    {
        Debug.Log("I, " + this.gameObject.name + " am activating!");
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 desiredPos = rect.anchoredPosition;
        Vector2 desiredScale = rect.localScale;

        rect.anchoredPosition = Vector2.zero;
        rect.localScale = Vector2.zero;

        LeanTween.moveLocal(this.gameObject, desiredPos, 0.1f);
        LeanTween.scale(rect, desiredScale, 0.1f);
    }

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
