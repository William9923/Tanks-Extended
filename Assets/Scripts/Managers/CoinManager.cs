using UnityEngine;
using System;

[Serializable]
public class CoinManager
{
    [HideInInspector] public GameObject m_Instance;                          

    private int m_CoinId;
    private CoinEffect m_Effect;        

    public void Setup(int id)
    {
        
        m_CoinId = id;
        m_Effect = m_Instance.GetComponent<CoinEffect>();
        
        Debug.Log($"Setting Up Coin Number: {id}");
    }

    public void Reset()
    {
        m_Instance.transform.position = GetRandomInField();

        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }

    public Vector3 GetRandomInField() 
    {
        return new Vector3(UnityEngine.Random.Range(-20, 20), -0.42f, UnityEngine.Random.Range(-20, 20));
    }
}
