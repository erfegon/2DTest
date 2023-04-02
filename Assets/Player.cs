using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private float m_acceleration = 1f;

    [SerializeField]
    private float m_maxSpeed = 1f;

    [SerializeField]
    private float m_jumpForce = 10f;

    private float m_horizontalVelocity;

    public event Action OnInteract;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            m_rigidBody.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            //m_rigidBody.velocity = new(m_rigidBody.velocity.x, m_jumpForce);
        }

        if (m_horizontalVelocity > 0f)
            m_spriteRenderer.flipX = false;
        else if(m_horizontalVelocity < 0f)
            m_spriteRenderer.flipX = true;

        m_animator.SetFloat("HorizontalSpeed", m_rigidBody.velocity.x);
        m_animator.SetFloat("VerticalSpeed", m_rigidBody.velocity.y);

        if(Input.GetButtonDown("Fire1"))
        {
            OnInteract?.Invoke();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_horizontalVelocity = Mathf.MoveTowards(m_horizontalVelocity, Input.GetAxis("Horizontal") * m_maxSpeed, m_acceleration * Time.deltaTime);
        m_rigidBody.velocity = new(m_horizontalVelocity, m_rigidBody.velocity.y);
    }
}
