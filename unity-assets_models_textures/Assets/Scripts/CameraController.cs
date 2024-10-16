using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 CameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        CameraOffset = new Vector3(0, 2.5f, -6.25f);
        this.transform.rotation = Quaternion.Euler(9, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position + CameraOffset;
    }
}
