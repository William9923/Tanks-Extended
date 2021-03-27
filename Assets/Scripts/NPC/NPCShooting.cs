using UnityEngine;

[RequireComponent (typeof (Animator))]
public class NPCShooting : MonoBehaviour
{     
    public Animator m_NPCAnimation;
    public Rigidbody m_Ammo; 
    public Transform m_FireTransform;      

    public float m_DelayAmmo = 0.4f; 
    [HideInInspector] public bool isShooting;
       
    void Start () 
    {
        m_NPCAnimation = GetComponent<Animator>();
        
    }

    public void StartFire()
    {
        InvokeRepeating("Fire", m_DelayAmmo, m_DelayAmmo);
        isShooting = true;
    }

    public void StopFire()
    {
        CancelInvoke("Fire");
        isShooting = false;
    }

    private void Fire ()
    {
        m_NPCAnimation.SetTrigger("shooting");

        Rigidbody ammoInstance =
            Instantiate (m_Ammo, m_FireTransform.position, new Quaternion(0,0,0,0)) as Rigidbody;
        
        // Set the shell's velocity to the launch force in the fire position's forward direction.
        ammoInstance.velocity = 30f *  transform.forward;
        m_NPCAnimation.ResetTrigger("shooting");
    }

}