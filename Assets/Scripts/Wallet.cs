using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _cash = 19999.99f;
    [SerializeField] private TextMeshProUGUI _money;

    private void Awake()
    {
        SetMoneyValue();
    }

    public bool ByeItem(float coast)
    {
        if (_cash<coast)
        {
            return false;
        }

        else
        {
            _cash -= coast;
            SetMoneyValue();
            return true;
        }
    }

    private void SetMoneyValue()
    {
        _money.text = _cash.ToString();
    }
}
