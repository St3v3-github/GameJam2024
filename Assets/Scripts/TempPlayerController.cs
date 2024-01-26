using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpForce = 8f;
    public float gravity = 30f;

    private CharacterController characterController;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontal, 0f, vertical));
        characterController.SimpleMove(moveDirection * speed);

        // Jumping
        if (characterController.isGrounded)
        {
            velocity.y = -2f; // Reset velocity when grounded

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(2f * jumpForce * gravity);
            }
        }

        // Apply gravity
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

        float verticalRotation = transform.eulerAngles.x + mouseY * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.eulerAngles = new Vector3(verticalRotation, transform.eulerAngles.y, 0f);
    }
}
