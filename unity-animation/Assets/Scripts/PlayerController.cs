using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform pivot;
    public GameObject gameModel;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool jumpHeld = false;
    public float MOVEMENT_SPEED = 2.0F;
    public float ROTATION_SPEED = 0.5F;
    public float JUMP = 4.0F;
    public float GRAVITY = -54F;
    private float DeathPlane = -90F;

    private PlayerAnimController animatorController;

    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<PlayerAnimController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grab player WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Grounded gravity
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = GRAVITY / 10;
        }
        
        // Horizontal movement
        Vector3 movementVector = ((transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal")));
        
        if (movementVector.magnitude >= 0.1f)
        {
            if (groundedPlayer)
            {
                animatorController.AnimateRun();
            }
            movementVector = movementVector.normalized * MOVEMENT_SPEED;
            controller.Move(movementVector * Time.deltaTime);
        } else
        {
            animatorController.AnimateIdle();
        }

        // Jumping Logic
        if (Input.GetButtonDown("Jump"))
        {
            jumpHeld = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;
            playerVelocity.y = playerVelocity.y > 0 ? 0 : playerVelocity.y;
        }

        if (groundedPlayer && jumpHeld)
        {
            playerVelocity.y += Mathf.Sqrt(JUMP * -3.0F * GRAVITY);
        }

        // Applies Velocity + Gravity
        playerVelocity.y += GRAVITY * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Check if we should be playing Jump animation
        if (jumpHeld && playerVelocity.y > 0)
        {
            animatorController.AnimateJump();
        }

        // If you're below the Death Plane, respawn
        if (this.transform.position.y < DeathPlane)
        {
            this.transform.position = new Vector3(0, 120f, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // rotation logic
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(movementVector.x, 0, movementVector.z));
            gameModel.transform.rotation = Quaternion.Slerp(gameModel.transform.rotation, newRotation, ROTATION_SPEED * Time.deltaTime);
        }
    }
}
