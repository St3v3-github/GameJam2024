using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sensitivity = 2f;

    void Update()
    {
        // Camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * sensitivity;
        transform.Rotate(rotation);

        // Clamp vertical rotation to avoid flipping
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, 0f, 0f);
        transform.eulerAngles = currentRotation;
    }
}
