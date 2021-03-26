using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject m_ShopMenu;
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

        upgradeWeaponBtn.onClick.AddListener(upgradeWeapon);
        buyShellsBtn.onClick.AddListener(buyShells);
        buyChar1Btn.onClick.AddListener(buyChar1);
        buyChar2Btn.onClick.AddListener(buyChar2);

        if (!weapon.IsUpgraded()) buyShellsBtn.interactable = false;
    }

    void DestroySetup()
    {
        upgradeWeaponBtn.onClick.RemoveListener(upgradeWeapon);
        buyShellsBtn.onClick.RemoveListener(buyShells);
        buyChar1Btn.onClick.RemoveListener(buyChar1);
        buyChar2Btn.onClick.RemoveListener(buyChar2);
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

    

    void upgradeWeapon()
    {
        
        money.BuyItem(100);
        weapon.UpgradeWeapon();
        upgradeWeaponBtn.interactable = false;
        buyShellsBtn.interactable = true;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Menghapus state selected
        
    }

    void buyShells()
    {
        money.BuyItem(100);
        weapon.BuyShell();
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void buyChar1()
    {
        money.BuyItem(1000);
        Debug.Log("Buy Character 1");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void buyChar2()
    {
        money.BuyItem(1500);
        Debug.Log("Buy Character 2");
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
}
