using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButtonIncreaseMaxHP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private EntityHealth playerHealth;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private int cost;
    [SerializeField] private float increaseValue;

    private int _cost;
    private float _increaseValue;

    private void Awake()
    {
        _cost = cost;
        _increaseValue = increaseValue;
        textMoney.text = _cost.ToString();
    }

    public void OnClickIncreaseMaxHp()
    {
        if (MoneyManager.S.MoneyValue >= _cost)
        {
            MoneyManager.S.MoneyValue -= _cost;
            playerHealth.MaxHealth += _increaseValue;
            _cost += 5;
            _increaseValue += 100f;
            textMoney.text = _cost.ToString();
        }
    }
}
