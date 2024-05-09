using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2f; // New crouch speed
    public float turnSpeed = 20f;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity;
    private bool isRunning;
    private bool isCrouching = false;
    private bool toggleCrouch = false;

    public Transform Cam;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = Cam.forward;
        camForward.y = 0f; // Set the y-component to zero to eliminate vertical rotation.
        camForward.Normalize();

        Vector3 camRight = Cam.right;
        camRight.y = 0f;
        camRight.Normalize();

        m_Movement = camForward * vertical + camRight * horizontal;
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
        }

        isRunning = Input.GetKey(KeyCode.LeftShift);
        m_Animator.SetBool("IsRunning", isRunning);

        // Check for crouch input toggle
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleCrouch = !toggleCrouch;
            m_Animator.SetBool("IsCrouching", toggleCrouch);

            // Reset crouch walk animation
            if (!toggleCrouch)
            {
                m_Animator.SetBool("IsCrouchWalking", false);
            }
        }

        // Set crouching state based on toggle
        if (toggleCrouch)
        {
            isCrouching = true;
            m_Animator.SetBool("IsCrouching", isCrouching);
        }
        else
        {
            isCrouching = false;
            m_Animator.SetBool("IsCrouching", isCrouching);
        }

        // Set crouch walk animation
        if (isWalking && isCrouching)
        {
            m_Animator.SetBool("IsCrouchWalking", true);
        }
        else
        {
            m_Animator.SetBool("IsCrouchWalking", false);
        }

        // Transition to idle if running in place
        if (!isWalking && isRunning)
        {
            m_Animator.SetBool("IsRunning", false);
            m_Animator.SetBool("IsWalking", false);
            m_Animator.SetBool("IsIdle", true);
        }
    }

    private void OnAnimatorMove()
    {
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        if (isCrouching)
        {
            currentSpeed = crouchSpeed; // Use crouch speed when crouching
        }

        Vector3 movement = m_Movement * currentSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}