using UnityEngine;

public enum Weapon 
{
    AMMO,
    SHELL
}

public class TankWeapon : MonoBehaviour {
    
    // TODO : Update logic of changing weapon and add constraint for buying item in shop
    public int m_PlayerNumber = 1;
    public Weapon m_CurrentWeapon;

    private ShootingShell m_Shell;
    private ShootingAmmo m_Ammo; 

    private string m_ToggleWeaponButton;   
                
    private void Start ()
    {
        m_Shell = GetComponentInParent<ShootingShell>();
        m_Ammo = GetComponentInParent<ShootingAmmo>();

        m_Shell.m_PlayerNumber = m_PlayerNumber;
        m_Ammo.m_PlayerNumber = m_PlayerNumber;

        m_ToggleWeaponButton = "Weapon" + m_PlayerNumber;

        EquipWeapon();
    } 

    private void OnEnable()
    {
        // Enable each weapon
        m_Shell.OnEnable();
        m_Ammo.OnEnable();

        EquipWeapon();
    }

    private void Update() 
    {
        m_ToggleWeaponButton = "Weapon" + m_PlayerNumber;
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
            case Weapon.SHELL:
                m_CurrentWeapon = Weapon.AMMO;
                break;
            case Weapon.AMMO:
                m_CurrentWeapon = Weapon.SHELL;
                break;
        }
    }

    private void EquipWeapon()
    {
        m_Shell.enabled = false;
        m_Ammo.enabled = false;
        switch(m_CurrentWeapon)
        {
            case Weapon.SHELL:
                m_Shell.enabled = true;
                break;
            case Weapon.AMMO:
                m_Ammo.enabled = true;
                break;
        }
    }
}