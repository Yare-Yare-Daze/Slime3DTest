using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoneyGain : MonoBehaviour
{
    [SerializeField] private int countMoney = 1;
    [SerializeField] private EntityDeath enemyDeath;

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
    }

}
