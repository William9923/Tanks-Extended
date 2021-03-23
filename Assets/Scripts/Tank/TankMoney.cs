using UnityEngine;
using UnityEngine.UI;
using System;

public class TankMoney : MonoBehaviour
{
    public int m_StartingMoney =  0;          
    private int m_CurrentMoney; 
    private bool m_CanExchange;     

    // punya UI buat nampilin jumlah duit, ntar diattach di scriptnya 

    private void Awake()
    {
        m_CurrentMoney = m_StartingMoney;
    }

    public void ReceiveMoney(int amount) 
    {
        if (amount > 0) 
        {
            m_CurrentMoney += amount;
        }

        Debug.Log($"Current Money: {m_CurrentMoney}");
    }

    public void BuyItem(int price) 
    {
        if (price > m_CurrentMoney)
        {
            throw new Exception("Not enough money to buy items!");
        }

        if (price > 0 && m_CanExchange)
        {
            Debug.Log($"But item with price : {price}");
            m_CurrentMoney -= price;
        }
    }

    private void OnEnable()
    {
        m_CanExchange = true;
    }

    public int GetMoney()
    {
        return m_CurrentMoney;
    }
}