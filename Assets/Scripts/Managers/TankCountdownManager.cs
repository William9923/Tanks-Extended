using System;
using UnityEngine;

[Serializable]
public class TankCountdownManager
{
    [HideInInspector] public Color m_PlayerColor;    
    [HideInInspector] public int m_InitialSpawnPointIdx;         
    [HideInInspector] public Transform[] m_SpawnPoint;         
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
        m_PlayerColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Weapon = m_Instance.GetComponent<TankWeapon>();
        m_Respawn = m_Instance.GetComponent<TankRespawn>();

        m_Respawn.m_RespawnPoint = m_SpawnPoint;    

        m_Weapon.m_CurrentWeapon = Weapon.AMMO; 

        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Weapon.m_PlayerNumber = m_PlayerNumber;
        

        playerName = m_PlayerNumber == 1 ? PlayerPrefs.GetString("playerOneName") : PlayerPrefs.GetString("playerTwoName");

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">" + playerName + "</color>";

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
        m_Instance.transform.position = m_SpawnPoint[m_InitialSpawnPointIdx].position;
        m_Instance.transform.rotation = m_SpawnPoint[m_InitialSpawnPointIdx].rotation;

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
