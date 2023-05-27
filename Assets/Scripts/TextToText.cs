using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fromText;
    [SerializeField] private TextMeshProUGUI _toText;

    private void Update()
    {
        _toText.text = _fromText.text;
    }
}
