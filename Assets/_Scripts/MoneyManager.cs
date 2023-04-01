using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    public static MoneyManager S;

    private int _money;

    public int MoneyValue 
    { 
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyText.text = _money.ToString();
        }
    }

    private void Awake()
    {
        S = this;
    }
}
