using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButtonIncreaseAttack : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private int cost;
    [SerializeField] private int increaseValue;

    private int _cost;
    private int _increaseValue;

    private void Awake()
    {
        _cost = cost;
        _increaseValue = increaseValue;
        textMoney.text = _cost.ToString();
    }

    public void OnClickIncreaseAttack()
    {
        if(MoneyManager.S.MoneyValue >= _cost)
        {
            MoneyManager.S.MoneyValue -= _cost;
            playerAttack.Damage += _increaseValue;
            _cost += 5;
            _increaseValue += 5;
            textMoney.text = _cost.ToString();
        }
    }


}
