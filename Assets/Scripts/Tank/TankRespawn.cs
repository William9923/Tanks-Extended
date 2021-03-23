using UnityEngine;
using UnityEngine.UI;
using System;

public class TankRespawn : TankHealth
{
    public Transform[] m_RespawnPoint;

    public float m_RespawnTimer = 5f;

    protected override void OnDeath()
    {
        base.OnDeath();
        Debug.Log("Respawn OnDeath activated");

        Invoke("Respawn", m_RespawnTimer);
    }

    private void Respawn()
    {
        m_Dead = true;
        gameObject.SetActive(true);

        Transform newSpawnPoint = m_RespawnPoint[UnityEngine.Random.Range(0, m_RespawnPoint.Length - 1)];
        gameObject.transform.position = newSpawnPoint.position;
        gameObject.transform.rotation = newSpawnPoint.rotation;
    }
}