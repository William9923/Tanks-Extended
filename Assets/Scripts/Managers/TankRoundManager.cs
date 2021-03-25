using System;
using UnityEngine;

[Serializable]
public class TankRoundManager
{
    public Color m_PlayerColor;            
    public Transform m_SpawnPoint;         
    [HideInInspector] public int m_PlayerNumber;             
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;          
    [HideInInspector] public int m_Wins;                     


    private TankMovement m_Movement;
    private TankRespawn m_Respawn;       
    private TankWeapon m_Weapon;
    private GameObject m_CanvasGameObject;
    private int m_CurrMoney;
    private string playerName;


    public void Setup()
    {
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Weapon = m_Instance.GetComponent<TankWeapon>();
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Weapon.m_PlayerNumber = m_PlayerNumber;

        playerName = m_PlayerNumber == 1 ? PlayerPrefs.GetString("playerOneName") : PlayerPrefs.GetString("playerTwoName");

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + playerName + "</color>";


        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Weapon.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Weapon.enabled = true;

        m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}