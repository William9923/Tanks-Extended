using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ShopManager
{
    private Button upgradeWeaponBtn, buyShellsBtn, buyChar1Btn, buyChar2Btn;
    private Text moneyAmount;
    private GameObject myEventSystem;

    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance; 
    private TankMoney m_Money;
    private bool isOpened;
    
    // Start is called before the first frame update
    public void Setup()
    {        
        upgradeWeaponBtn = GameObject.Find("UpgradeWeaponButton").GetComponent<Button>();
        buyShellsBtn = GameObject.Find("BuyShellsButton").GetComponent<Button>();
        buyChar1Btn = GameObject.Find("BuyChar1Button").GetComponent<Button>();
        buyChar2Btn = GameObject.Find("BuyChar2Button").GetComponent<Button>();

        upgradeWeaponBtn.onClick.AddListener(upgradeWeapon);
        buyShellsBtn.onClick.AddListener(buyShells);
        buyChar1Btn.onClick.AddListener(buyChar1);
        buyChar2Btn.onClick.AddListener(buyChar2);

        myEventSystem = GameObject.Find("EventSystem");

        moneyAmount = GameObject.Find("MoneyText").GetComponent<Text>();
        Update();
    }

    public void Toggle ()
    {
        m_Menu.SetActive(!isOpened);
        isOpened = !isOpened;
    }

    public void Update()
    {
        moneyAmount.text = m_Money.GetMoney().ToString();
    }



    void upgradeWeapon()
    {
        Debug.Log("Upgrade gan");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null); //Menghapus state selected
    }

    void buyShells()
    {
        Debug.Log("Buy Shells");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void buyChar1()
    {
        Debug.Log("Buy Character 1");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }

    void buyChar2()
    {
        Debug.Log("Buy Character 2");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
}
