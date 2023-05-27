using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        SetValue();
    }

    public void SetValue()
    {
        var value = _slider.value;
        _textMeshProUGUI.text = value.ToString("0")+ "/" + _slider.maxValue;
    }
}
