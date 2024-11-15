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
    void LateUpdate()
    {
        // Get x position of mouse
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Rotate player and pivot
        player.Rotate(0, horizontal, 0);
        pivot.Rotate(-vertical, 0, 0);

        // Limit vertical camera rotation
        if (pivot.rotation.eulerAngles.x > 50f && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(50f, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 335f)
        {
            pivot.rotation = Quaternion.Euler(335f, 0, 0);
        }
        
        // Move camera around pivot with offset
        float desiredYAngle = player.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        // Move camera based on player's movement
        transform.position = pivot.position - (rotation * CameraOffset);

        // this.transform.position = pivot.position - CameraOffset;

        // Ensures camera never goes below the player
        if (transform.position.y < player.position.y - 0.5f)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - 0.5f, transform.position.z);
        }

        this.transform.LookAt(pivot);
    }
}
