using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    
    public GameObject m_ShopMenu;
    public GameObject m_ShootingTroopPrefab;
    public GameObject m_CollectorTroopPrefab;

    private Button upgradeWeaponBtn, buyShellsBtn, buyChar1Btn, buyChar2Btn;
    private Text moneyAmount;
    private GameObject myEventSystem;
    private bool isOpened;
    [HideInInspector] public GameObject m_Instance;
    private TankMoney money;
    private TankWeapon weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
        m_ShopMenu.SetActive(isOpened);
        myEventSystem = GameObject.Find("EventSystem");
    }

    void Setup() 
    {
        upgradeWeaponBtn = GameObject.Find("UpgradeWeaponButton").GetComponent<Button>();
        buyShellsBtn = GameObject.Find("BuyShellsButton").GetComponent<Button>();
        buyChar1Btn = GameObject.Find("BuyChar1Button").GetComponent<Button>();
        buyChar2Btn = GameObject.Find("BuyChar2Button").GetComponent<Button>();
        moneyAmount = GameObject.Find("MoneyText").GetComponent<Text>();

        upgradeWeaponBtn.onClick.AddListener(UpgradeWeapon);
        buyShellsBtn.onClick.AddListener(BuyShells);
        buyChar1Btn.onClick.AddListener(BuyCollectorTroop);
        buyChar2Btn.onClick.AddListener(BuyShootingTroop);

        if (!weapon.IsUpgraded()) buyShellsBtn.interactable = false;
    }

    void DestroySetup()
    {
        upgradeWeaponBtn.onClick.RemoveListener(UpgradeWeapon);
        buyShellsBtn.onClick.RemoveListener(BuyShells);
        buyChar1Btn.onClick.RemoveListener(BuyCollectorTroop);
        buyChar2Btn.onClick.RemoveListener(BuyShootingTroop);
    }

    public void Toggle(GameObject tank)
    {
        m_ShopMenu.SetActive(!isOpened);
        isOpened = !isOpened;
        if (isOpened)
        {
            m_Instance = tank;
            money = m_Instance.GetComponent<TankMoney>();
            weapon = m_Instance.GetComponent<TankWeapon>();
            Setup();

            moneyAmount.text = money.GetMoney().ToString();
        }
        if (!isOpened)
        {
            DestroySetup();
        }
    }

    void UpgradeWeapon()
    {
        money.BuyItem(100);
        weapon.UpgradeWeapon();
        upgradeWeaponBtn.interactable = false;
        buyShellsBtn.interactable = true;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Menghapus state selected
        
    }

    void BuyShells()
    {
        money.BuyItem(100);
        weapon.BuyShell();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void BuyCollectorTroop()
    {
        // TODO : Implement harga once done debugging
        // money.BuyItem(1000);
        Debug.Log("Buy Collector Troop");
        InitCollectorTroop();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void BuyShootingTroop()
    {
        // TODO : Implement harga once done debugging
        // money.BuyItem(1500);
        Debug.Log("Buy Shooting Troop");
        InitShootingTroop();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    // Update is called once per frame
    void Update()
    {
        if (isOpened)
        {
            money = m_Instance.GetComponent<TankMoney>();
            moneyAmount.text = money.GetMoney().ToString();
        }
    }

    void InitShootingTroop()
    {
        GameObject shooterTroop = Instantiate(m_ShootingTroopPrefab, m_Instance.GetComponent<TankNPCHandler>().m_TroopLocation.position, m_Instance.transform.rotation) as GameObject;
        shooterTroop.GetComponent<NPCAgentShooter>().m_Player = m_Instance;
    }

    void InitCollectorTroop()
    {
         GameObject shooterTroop = Instantiate(m_CollectorTroopPrefab, m_Instance.GetComponent<TankNPCHandler>().m_TroopLocation.position, m_Instance.transform.rotation) as GameObject;
        shooterTroop.GetComponent<NPCAgentFinder>().m_Player = m_Instance;
    }
}
