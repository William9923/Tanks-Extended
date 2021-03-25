using UnityEngine;
using UnityEngine.UI;

public class TankNewShooting : MonoBehaviour
{
    public int m_PlayerNumber = 1;
    public string m_CurrentWeapon;

    private ShootingShell m_ShootingShell;
    private ShootingAmmo m_ShootingAmmo; 

    private string m_ToggleWeaponButton;   
                
    private void Start ()
    {
        m_ShootingShell = GetComponentInParent<ShootingShell>();
        m_ShootingAmmo = GetComponentInParent<ShootingAmmo>();

        m_ShootingShell.m_PlayerNumber = m_PlayerNumber;
        m_ShootingAmmo.m_PlayerNumber = m_PlayerNumber;

        m_ToggleWeaponButton = "Weapon" + m_PlayerNumber;

        EquipWeapon();
    } 

    private void OnEnable()
    {
        // Enable each weapon
        m_ShootingShell.OnEnable();
        m_ShootingAmmo.OnEnable();

        EquipWeapon();
    }

    private void Update() 
    {
        if (Input.GetButtonDown(m_ToggleWeaponButton)) 
        {
            Debug.Log("Change Weapon");
            ChangeWeapon();
            EquipWeapon();
        }
            
    }

    private void ChangeWeapon()
    {
        switch(m_CurrentWeapon)
        {
            case "shell":
                m_CurrentWeapon = "ammo";
                break;
            case "ammo":
                m_CurrentWeapon = "shell";
                break;
        }
    }

    private void EquipWeapon()
    {
        m_ShootingShell.enabled = false;
        m_ShootingAmmo.enabled = false;
        switch(m_CurrentWeapon)
        {
            case "shell":
                m_ShootingShell.enabled = true;
                break;
            case "ammo":
                m_ShootingAmmo.enabled = true;
                break;
        }
    }

}