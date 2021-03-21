using UnityEngine;
using System;

public class CoinEffect : MonoBehaviour
{
    public LayerMask m_TankMask;       
    // public AudioSource m_GetCoinsAudio;  --> cari assetnya ntar             
    public int m_Money = 100;  
    public float m_HitRadius = 10f;                  
            

    private void OnTriggerEnter (Collider other)
    {
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere (transform.position, m_HitRadius, m_TankMask);

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // Find the TargetMoney script associated with the rigidbody.
            TankMoney targetMoney = targetRigidbody.GetComponent<TankMoney> ();

            if (!targetMoney)
                continue;

            targetMoney.ReceiveMoney(m_Money);
            
            // Play audio effect for getting money
            // m_GetCoinsAudio.Play();     
            Destroy (gameObject);
        }

    
    }
    public void ChangeValue(int value)
    {
        if (value < 0)
        {
            throw new Exception("Cannot use negative value for bonus reward");
        }
        m_Money = value;
    }
}