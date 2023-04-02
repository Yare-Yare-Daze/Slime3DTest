using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButtonIncrease : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private int cost;
    [SerializeField] private int increaseValue;

    private int _cost;
    private int _increaseValue;

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _cost = cost;
        _increaseValue = increaseValue;
        textMoney.text = _cost.ToString();
    }

    public void OnClickIncrease()
    {
        if (MoneyManager.S.MoneyValue >= _cost)
        {
            MoneyManager.S.MoneyValue -= _cost;
            _cost += 5;
            _increaseValue += 5;
            textMoney.text = _cost.ToString();
        }
    }
}
