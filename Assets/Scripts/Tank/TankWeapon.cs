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

    public int ShellCount;
    private bool Upgraded = false;
                
    private void Start ()
    {
        m_Shell = GetComponentInParent<ShootingShell>();
        m_Ammo = GetComponentInParent<ShootingAmmo>();

        m_Shell.m_PlayerNumber = m_PlayerNumber;
        m_Ammo.m_PlayerNumber = m_PlayerNumber;

        m_ToggleWeaponButton = "Weapon" + m_PlayerNumber;

        ShellCount = 0;

        EquipWeapon();
    } 

    private void OnEnable()
    {
        // Enable each weapon
        if (m_Shell == null)
            m_Shell = GetComponentInParent<ShootingShell>();

        m_Shell.OnEnable();

        if (m_Ammo == null)
            m_Ammo = GetComponentInParent<ShootingAmmo>();

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
        if (!Upgraded) 
        {
            Debug.Log("Need Upgrade");
            return;
        }
        
        // Changing weapon logic
        switch (m_CurrentWeapon)
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

    public void BuyShell()
    {
        ShellCount += 1;
        Debug.Log("Current Shell : " + ShellCount);
    }

    public void UpgradeWeapon()
    {
        Debug.Log("Weapon Upgraded, Press " + m_ToggleWeaponButton + " button to change Weapon");
        Upgraded = true;
    }

    public bool IsUpgraded()
    {
        return Upgraded;
    }
}