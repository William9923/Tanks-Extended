﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class NPCMoving : MonoBehaviour
{
       
    // Target to detect
    [HideInInspector] public GameObject m_Player; // TODO : Dijadiin private, instantiate on runtime [HideOnInspector]
    
    // NPC properties
    public float m_AllowedDistance;

    // NPC Component
    public NavMeshAgent m_NPCAgent;
    public Animator m_NPCAnimation;
    public RaycastHit m_Shot;
    
    void Start () {
        m_NPCAgent = GetComponent<NavMeshAgent>();
        m_NPCAgent.enabled = true;

        m_NPCAnimation = GetComponent<Animator>();
        m_NPCAnimation.SetTrigger("moving");
    }

    protected virtual void Update() 
    {

        transform.LookAt(m_Player.transform);

        // Check if too far ...
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out m_Shot ))
        {
            // if out of range
            if (m_Shot.distance >= m_AllowedDistance)
            {
                m_NPCAgent.SetDestination(m_Player.transform.position);
                m_NPCAnimation.SetTrigger("moving");

            }
            else 
            {
                // Set destination to current location
                m_NPCAgent.SetDestination(transform.position);

                // Play Idle Animation
                m_NPCAnimation.ResetTrigger("moving");
            }
        }

    }
    
}
