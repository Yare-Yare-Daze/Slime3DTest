using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public Action OnMoneyChange;

    private int _money = 0;

    public int Money
    {
        get { return _money; }
        set 
        { 
            _money = value;
            OnMoneyChange?.Invoke();
        }
    }
}
