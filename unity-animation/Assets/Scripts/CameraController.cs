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
        // pivot.transform.parent = player.transform;
        pivot.transform.position = player.transform.position;
        pivot.transform.parent = null;
        CameraOffset = pivot.position - new Vector3(0, 2.5f, -6.25f);

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = player.transform.position;

        // Get x position of mouse
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // Rotate pivot
        pivot.Rotate(-vertical, 0, 0);
        pivot.Rotate(0, horizontal, 0);

        // Limit vertical camera rotation
        if (pivot.rotation.eulerAngles.x > 50f && pivot.rotation.eulerAngles.x < 180)
        {
            pivot.rotation = Quaternion.Euler(50f, pivot.rotation.eulerAngles.y, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 335f)
        {
            pivot.rotation = Quaternion.Euler(335f, pivot.rotation.eulerAngles.y, 0);
        }
        
        // Move camera around pivot with offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        // Move camera based on player's movement
        transform.position = pivot.position - (rotation * CameraOffset);

        // Ensures camera never goes below the player
        if (transform.position.y < player.position.y - 0.5f)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - 0.5f, transform.position.z);
        }

        this.transform.LookAt(pivot);
    }
}
