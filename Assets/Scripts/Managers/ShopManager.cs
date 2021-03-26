using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ShopManager
{
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public GameObject m_Instance; 
    public KeyCode m_KeyCode;
}
