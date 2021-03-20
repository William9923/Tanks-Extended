using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public LayerMask m_TankMask;       
    // public AudioSource m_GetCoinsAudio;  --> cari assetnya ntar             
    public int m_Money = 100;  
    public float m_HitRadius = 10f;                  
            

    private void Start()
    {
        Debug.Log("Coins created");
    }


    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("Hid OnTriggerEnter!");
        // Collect all the colliders in a sphere from the shell's current position to a radius of the explosion radius.
        Collider[] colliders = Physics.OverlapSphere (transform.position, m_HitRadius, m_TankMask);

        if (colliders.Length > 0) 
        {
            Debug.Log("Coins is being hit by tanks");
        }

        // Go through all the colliders...
        for (int i = 0; i < colliders.Length; i++)
        {
            // ... and find their rigidbody.
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();

            // If they don't have a rigidbody, go on to the next collider.
            if (!targetRigidbody)
                continue;

            // ngerubah state disini supaya si tank punya duit nambah... 
            Debug.Log("Should add money, not implemented");
            // Play audio effect for getting money
            // m_GetCoinsAudio.Play();     
            Destroy (gameObject);
        }

           
    }
}