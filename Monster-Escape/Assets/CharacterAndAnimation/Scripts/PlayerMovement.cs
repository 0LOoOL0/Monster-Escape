using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float turnSpeed = 10f;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private Vector3 m_Movement;
    private Quaternion m_Rotation;
    private bool m_IsRunning = false;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool isWalking = m_Movement.magnitude > 0f;

        if (Input.GetKey(KeyCode.LeftShift) && isWalking)
        {
            m_IsRunning = true;
            m_Animator.SetBool("IsRunning", true);
        }
        else
        {
            m_IsRunning = false;
            m_Animator.SetBool("IsRunning", false);
        }

        m_Animator.SetBool("IsWalking", isWalking);
        m_Animator.SetFloat("Speed", m_Movement.magnitude);
        m_Animator.SetFloat("Direction", horizontal);

        if (m_Movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(m_Movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, turnSpeed * Time.fixedDeltaTime);
        }

        float currentSpeed = m_IsRunning ? runSpeed : walkSpeed;
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * currentSpeed * Time.fixedDeltaTime);
    }
}
