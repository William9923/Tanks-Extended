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
    }

    public void Toggle(GameObject tank)
    {
        m_ShopMenu.SetActive(!isOpened);
        isOpened = !isOpened;
        if (isOpened)
        {
            Setup();
            Debug.Log(tank);
            m_Instance = tank;
            TankMoney money = m_Instance.GetComponent<TankMoney>();
            moneyAmount.text = money.GetMoney().ToString();
        }    
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
