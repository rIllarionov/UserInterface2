using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [SerializeField] internal string _name;
    [SerializeField] internal int _health;
    [SerializeField] internal int _atack;
    [SerializeField] internal int _defense;
    [SerializeField] internal int _speed;
    [SerializeField] internal float _price;
    internal bool _isAwailable;
}
