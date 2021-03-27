using UnityEngine;

public class Ammo : MonoBehaviour
{
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;
    public float m_Damage = 50f;                  
    public float m_ExplosionRadius = 2f;        
      
    public float m_ProjSpeed = 7.5f;
    public float m_AmmoLifetime = 2.0f; 

    private void Start()
    {
        // please destroy this after few second
        Destroy(gameObject, m_AmmoLifetime);

    }

    private void Update() 
    {
        transform.position += transform.forward * m_ProjSpeed*Time.deltaTime;
    }

    private void OnTriggerEnter (Collider other)
    {
        // ... and find their rigidbody.
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody> ();
        // If they don't have a rigidbody, go on to the next collider.
        if (!targetRigidbody)
            return;

        targetRigidbody.AddExplosionForce (10.0f, transform.position, m_ExplosionRadius);

        // Find the TankHealth script associated with the rigidbody.
        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();

        // Check also if it a trooper
        NPCHealth npcHealth = targetRigidbody.GetComponent<NPCHealth> (); 

        // If there is no TankHealth script attached to the gameobject, go on to the next collider.
        if (!targetHealth && !npcHealth)
            return;
        
        // Calculate the amount of damage the target should take based on it's distance from the shell.
        float damage = CalculateDamage (targetRigidbody.position);

        // Deal this damage to the tank.
        if (targetHealth)
            targetHealth.TakeDamage (damage);

        // Deal this damage to the npc.
        if (npcHealth)
            npcHealth.TakeDamage (damage);

        m_ExplosionParticles.transform.parent = null;

        // Play the particle system.
        m_ExplosionParticles.Play();


        // // Once the particles have finished, destroy the gameobject they are on.
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);


        // Destroy the shell.
        Destroy(gameObject);
    }


    private float CalculateDamage (Vector3 targetPosition)
    {
        // Create a vector from the shell to the target.
        Vector3 explosionToTarget = targetPosition - transform.position;

        // Calculate the distance from the shell to the target.
        float explosionDistance = explosionToTarget.magnitude;

        // Calculate the proportion of the maximum distance (the explosionRadius) the target is away.
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

        // Calculate damage as this proportion of the maximum possible damage.
        float damage = relativeDistance * m_Damage;

        // Make sure that the minimum damage is always 0.
        damage = Mathf.Max (0f, damage);

        return damage;
    } 
}
