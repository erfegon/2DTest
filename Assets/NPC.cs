using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private GameObject m_question, m_heart;

    private void Start()
    {
        m_question.SetActive(false);
        m_heart.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.OnInteract += Talk;
            m_question.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.OnInteract -= Talk;
            m_question.SetActive(false);
            m_heart.SetActive(false);
        }
    }

    private void Talk()
    {
        m_heart.SetActive(true);
    }
}
