using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private Button upgradeWeaponBtn, buyShellsBtn, buyChar1Btn, buyChar2Btn;
    private Text moneyAmount;
    private GameObject myEventSystem;
    private int tankMoney;
    
    // Start is called before the first frame update
    void Start()
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

        //tankMoney = gameObject.GetComponent<TankMoney>().m_StartingMoney;

        // moneyAmount = GameObject.Find("MoneyText").GetComponent<Text>();
        // moneyAmount.text = tankMoney.ToString();
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
