using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 CameraOffset;
    public Transform pivot;
    public float mouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        pivot.transform.parent = player.transform;
        pivot.transform.position = player.transform.position;
        CameraOffset = pivot.position - new Vector3(0, 2.5f, -6.25f);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get x position of mouse
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Rotate pivot
        player.Rotate(0, horizontal, 0);
        pivot.Rotate(-vertical, 0, 0);
        
        // Move camera around pivot with offset
        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        // Move camera based on player's movement
        transform.position = pivot.position - (rotation * CameraOffset);

        // this.transform.position = pivot.position - CameraOffset;

        this.transform.LookAt(pivot);
    }
}
