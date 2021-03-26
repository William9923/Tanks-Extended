using UnityEngine;

[RequireComponent (typeof (Animator))]
public class NPCShooting : MonoBehaviour
{     
    public Animator m_NPCAnimation;
    public Rigidbody m_Ammo;       

    public float m_DelayAmmo = 0.4f; 
       
    void Start () 
    {
        m_NPCAnimation = GetComponent<Animator>();
        
    }

    public void Fire ()
    {
        m_NPCAnimation.SetTrigger("shooting");
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody ammoInstance =
            Instantiate (m_Ammo, transform.position, new Quaternion(0,0,0,0)) as Rigidbody;
        
        // Set the shell's velocity to the launch force in the fire position's forward direction.
        ammoInstance.velocity = 30f *  transform.forward;
        m_NPCAnimation.ResetTrigger("shooting");
        
    }

}