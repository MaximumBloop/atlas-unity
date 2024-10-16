using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool jumpHeld = false;
    public float SPEED = 3.0F;
    public float JUMP = 3.0F;
    public float GRAVITY = -9.81F;
    public float DeathPlane = -90F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0F;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * SPEED;
        

        controller.Move(movement * Time.deltaTime * SPEED);

        // Sets direction that we are moving in (if at all)
        if (movement != Vector3.zero)
        {
            gameObject.transform.forward = movement;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpHeld = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;
        }
        if (groundedPlayer && jumpHeld)
        {
            playerVelocity.y += Mathf.Sqrt(JUMP * -3.0F * GRAVITY);
        }

        playerVelocity.y += GRAVITY * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (this.transform.position.y < DeathPlane)
        {
            this.transform.position = new Vector3(0, 120f, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
