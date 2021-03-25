using System;
using UnityEngine;

[Serializable]
public class TankNewCountdownManager
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
    private TankNewShooting m_Shooting;
    private GameObject m_CanvasGameObject;
    private int m_CurrMoney;

    public void Setup()
    {
        m_PlayerColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankNewShooting>();
        m_Respawn = m_Instance.GetComponent<TankRespawn>();

        m_Respawn.m_RespawnPoint = m_SpawnPoint;    

        m_Shooting.m_CurrentWeapon = "ammo"; 

        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;

        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;

        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";

        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;

        m_CanvasGameObject.SetActive(false);
    }


    public void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;

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
