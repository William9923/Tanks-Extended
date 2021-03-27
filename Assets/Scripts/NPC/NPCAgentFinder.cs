using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAgentFinder : NPCMoving {

    public LayerMask m_CoinMask;
    public float m_NPCRadius = 1000f;

    

    public override void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_NPCRadius, m_CoinMask);
        
        float nearestCoinDistance = 999f;
        CoinEffect nearestCoin = null;

        for (int i = 0; i < colliders.Length; i++)
        {
            float coinDistance;
            CoinEffect coin = colliders[i].GetComponent<CoinEffect>();
            if (!coin) continue;

            coinDistance = Vector3.Distance(transform.position, coin.transform.position);

            if ((coinDistance < nearestCoinDistance))
            {
                nearestCoin = coin;
                nearestCoinDistance = coinDistance;
            }            
      
        }

        float playerDistance = Vector3.Distance(transform.position, m_Player.transform.position);

        // If no coin is in radius
        if ((nearestCoinDistance == 999f) || (nearestCoin == null))
        {
            if (playerDistance >= 1)
            {
                transform.LookAt(m_Player.transform);
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
        //If there is a coin in radius
        else
        {
            // Set destination to current location
            m_NPCAgent.SetDestination(nearestCoin.transform.position);

            // Play Idle Animation
            m_NPCAnimation.SetTrigger("moving");
        }

    }
    // TODO : Create best path action (to find target)
    // -> Find nearest location, get to there
}
//TODO : override Update
