using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] gameObjects;

    public void OnImageTargetFound()
    {
        foreach (GameObject obj in gameObjects)
        {
            StartCoroutine(Timer(0.1f));
            obj.SetActive(true);
        }
    }

    public void OnImageTargetLost()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
