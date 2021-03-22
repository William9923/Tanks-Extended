using UnityEngine;
using System;

[Serializable]
public class CoinManager
{
    [HideInInspector] public GameObject m_Instance;                          

    private int m_CoinId;
    private CoinEffect m_Effect;        

    public void Setup(int id, int numberOfRound)
    {
        m_CoinId = id;
        m_Effect = m_Instance.GetComponent<CoinEffect>();

        m_Effect.ChangeValue(m_Effect.m_Money * numberOfRound); // can use more complicated logic
    }

    public void Reset()
    {
        if (m_Instance == null) 
        {
            Debug.Log("Coin had beed picked up!");
            return;
        }

        // For remaining coins after a round, the remaining not destroyed but added for future
        m_Instance.transform.position = GetRandomInField();

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }

    public Vector3 GetRandomInField() 
    {
        return new Vector3(UnityEngine.Random.Range(-20, 20), 0f, UnityEngine.Random.Range(-20, 20));
    }
}