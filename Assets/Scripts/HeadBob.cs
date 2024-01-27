using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Transform headTransform; // Reference to the head bone or object
    public float bobbingSpeed = 1f; // Speed of the bobbing motion
    public float bobbingAmount = 0.05f; // Amount of bobbing motion
    public float bobbingDuration = 3f; // Duration of head bobbing in seconds

    private float midpointY; // Midpoint position of the head
    private float timer = 0f;

    private Animator animator; // Reference to the Animator component

    void Start()
    {
        midpointY = headTransform.localPosition.x;
        animator = GetComponent<Animator>(); // Get the Animator component attached to the same GameObject
    }

    void Update()
    {
        if (animator != null)
            animator.enabled = !enabled; // Disable animator when head bob is active

        // Calculate the vertical bobbing motion using sine function
        float bobbingValue = Mathf.Sin(timer) * bobbingAmount;

        // Update the head's position
        Vector3 newPos = headTransform.localPosition;
        newPos.x = midpointY + bobbingValue;
        headTransform.localPosition = newPos;

        // Increment the timer based on speed
        timer += bobbingSpeed * Time.deltaTime;
    }

    void OnEnable()
    {
        StartCoroutine(ReactivateAnimator());
    }

    // Coroutine to reactivate the Animator after bobbing duration
    private System.Collections.IEnumerator ReactivateAnimator()
    {
        yield return new WaitForSeconds(bobbingDuration);
        if (animator != null)
            animator.enabled = true; // Re-enable animator
        enabled = false; // Disable head bob script
    }
}




