using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ShootingAmmo : MonoBehaviour
{
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Ammo;            
    public Transform m_FireTransform;    

    private string m_FireButton;          
    public float m_DelayAmmo = 0.2f; 
       
    public void OnEnable()
    {
        // The fire axis is based on the player number.
        m_FireButton = "Fire" + m_PlayerNumber;
    }

    public void Start ()
    {
        m_FireTransform.rotation = new Quaternion(0,0,0,0);
        this.GetComponent<Rigidbody>().useGravity = false;
    }

    public void Update ()
    {
        m_FireButton = "Fire" + m_PlayerNumber; 
        if (Input.GetButtonDown (m_FireButton))
        {
            InvokeRepeating("Fire", 0.1f, m_DelayAmmo);
            
        } else if (Input.GetButtonUp (m_FireButton))
        {
            CancelInvoke("Fire");
        }

    }

    public void Fire ()
    {        
        Debug.Log("Ammo Fired");
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody ammoInstance =
            Instantiate (m_Ammo, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        
        // Set the shell's velocity to the launch force in the fire position's forward direction.
        ammoInstance.velocity = 30f *  m_FireTransform.forward;
        
    }

}