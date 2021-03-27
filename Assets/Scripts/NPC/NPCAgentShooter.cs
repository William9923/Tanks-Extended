using UnityEngine;

public class NPCAgentShooter : NPCMoving 
{

    public LayerMask m_TargetPrefab;
    public float m_RadiusRangeDistance;

    public override void Update() 
    {
        // Default Look At ...
        transform.LookAt(m_Player.transform);

        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere (transform.position, m_RadiusRangeDistance, m_TargetPrefab);
        float distance;

        // if no target acquired ...
        distance = Vector3.Distance(transform.position, m_Player.transform.position);

        // if out of range... find the player
        if (distance >= m_AllowedDistance)
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

        NPCShooting shootingComponent = GetComponent<NPCShooting>();;
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;
            
            // Find the TankHealth script associated with the rigidbody.
            TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();

            if (!targetHealth)
                continue;

            // Bypass player...
            TankMovement targetMovement = targetRigidbody.GetComponent<TankMovement> ();
            TankMovement playerMovement = m_Player.GetComponent<TankMovement>();
            if (targetMovement.m_PlayerNumber == playerMovement.m_PlayerNumber)
                continue;

            // if not in range ... find other
            distance = Vector3.Distance(transform.position, targetHealth.transform.position);
            if (distance >= m_RadiusRangeDistance)
                continue;

            // Find the location, and then fire the target ...
            transform.LookAt(targetHealth.transform.position);
            if (!shootingComponent.isShooting)
            {
                shootingComponent.StartFire();
                m_NPCAnimation.SetTrigger("shooting");
            } 
                
            return;            
        }
        
        if (shootingComponent.isShooting)
        {
            GetComponent<NPCShooting>().StopFire();
            m_NPCAnimation.ResetTrigger("shooting");
        }
            

        
    }
}