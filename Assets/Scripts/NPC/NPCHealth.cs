using UnityEngine;

[RequireComponent (typeof (Animator))]
public class NPCHealth : MonoBehaviour
{
    public Animator m_NPCAnimation;

    public float m_StartingHealth = 50f;             
    protected float m_CurrentHealth;  
    protected bool m_Dead;            

    private void Start()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;

        m_NPCAnimation = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;

        if (m_CurrentHealth <= 0f && !m_Dead) {
            OnDeath();
        }
    
    }

    protected virtual void OnDeath()
    {
        // Play the effects for the death of the tank and deactivate it.
        // Set the flag so that this function is only called once.
        m_Dead = true;

        // Play the animation
        m_NPCAnimation.SetTrigger("dead");

        // Destroy this game object
        Destroy(gameObject, 0.75f);
    }


}