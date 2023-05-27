using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public GameObject[] _heroes { get; private set; }
    [field:SerializeField] public Wallet _wallet { get; private set; }
    public GameObject _currentHero { get; private set; }
    public int _indexCurrentHero { get; private set; }

    public void SetCurrentHero(GameObject hero)
    {
        _currentHero = hero;
    }
    
    public void SetCurrentIndex(int index)
    {
        _indexCurrentHero = index;
    }
}
