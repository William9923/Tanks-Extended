using UnityEngine;
using System;

public class CoinEffect : MonoBehaviour
{
    public LayerMask m_TankMask;       

    public AudioSource m_CoinsAudio;

    public int m_Money = 100;  
    public float m_HitRadius = 2f;                  
            

    private void OnTriggerEnter (Collider other)
    {
        // .. check if it was ground
        if (other.gameObject.layer == 8) // ground
        {
            Rigidbody target = gameObject.GetComponent<Rigidbody>();
            target.constraints = RigidbodyConstraints.FreezePosition;
            return;
        }

        // .. check if it was obstacle
        if (other.gameObject.layer == 11)
        {
            // Reposition
            transform.position = GetRandomInField();
            return;
        }

        // ... and find their rigidbody.
        Rigidbody targetRigidbody = other.GetComponent<Rigidbody> ();

        // If they don't have a rigidbody, go on to the next collider.
        if (!targetRigidbody)
            return;

        // Find the TargetMoney script associated with the rigidbody.
        TankMoney targetMoney = targetRigidbody.GetComponent<TankMoney> ();

        // Find any NPCFinder Item
        NPCAgentFinder finder = targetRigidbody.GetComponent<NPCAgentFinder>();

        if (!targetMoney && finder == null)
            return;

        if (targetMoney)
            targetMoney.ReceiveMoney(m_Money);

        if (finder != null) 
            finder.m_Player.GetComponent<TankMoney>().ReceiveMoney(m_Money);
        
        // Play audio effect for getting money
        m_CoinsAudio.Play();
        Destroy (gameObject);
    }

    public void ChangeValue(int value)
    {
        if (value < 0)
        {
            throw new Exception("Cannot use negative value for bonus reward");
        }
        m_Money = value;
    }

    private Vector3 GetRandomInField() 
    {
        return new Vector3(UnityEngine.Random.Range(-20, 20), 6f, UnityEngine.Random.Range(-20, 20));
    }
}