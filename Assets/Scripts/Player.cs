using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] internal GameObject[] _heroes;
    [SerializeField] internal Wallet _wallet;
    internal GameObject _currentHero;
    internal GameObject _startHero;
    internal int _startIndex;
    internal int _indexCurrentHero;
}
