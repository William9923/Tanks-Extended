using UnityEngine;

public class AmmoContinuos : MonoBehaviour
{
    public LayerMask m_TankMask;                     
    public float m_Damage = 50f;                  
    public float m_HitForce = 5f;
    public float m_ExplosionRadius = 2f;     
    public float m_ExplosionForce = 5f;      
      
    public float m_ProjSpeed = 12.0f;
    public float m_AmmoLifetime = 2.0f; 

    private void Start()
    {
        // please destroy this after few second
        Destroy(gameObject, m_ProjSpeed);

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

        // Find the TankHealth script associated with the rigidbody.
        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();

        // If there is no TankHealth script attached to the gameobject, go on to the next collider.
        if (!targetHealth)
            return;
        
        // Calculate the amount of damage the target should take based on it's distance from the shell.
        float damage = CalculateDamage (targetRigidbody.position);

        // Deal this damage to the tank.
        targetHealth.TakeDamage (damage);

        // Destroy the shell.
        Destroy (gameObject);
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
