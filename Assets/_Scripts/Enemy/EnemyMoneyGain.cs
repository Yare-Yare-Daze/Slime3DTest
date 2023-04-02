using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoneyGain : MonoBehaviour
{
    [SerializeField] private int countMoney = 1;
    [SerializeField] private EntityDeath enemyDeath;
    [SerializeField] private GameObject coinsPSPrefab;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        enemyDeath.OnEntityDeath += IncreaseMoney;
    }

    private void IncreaseMoney()
    {
        MoneyManager.S.MoneyValue += countMoney;
        StartCoroutine(CoinsDrop());
    }

    private IEnumerator CoinsDrop()
    {
        float timeSpent = 0;
        ParticleSystem coinsPS = Instantiate(coinsPSPrefab).GetComponent<ParticleSystem>();
        while(timeSpent < coinsPS.main.duration)
        {
            timeSpent += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(coinsPS.gameObject);
    }

}
