using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : MonoBehaviour
{
    [field:SerializeField] public string _name { get; private set; }
    [field:SerializeField] public int _health { get; private set; }
    [field:SerializeField] public int _atack { get; private set; }
    [field:SerializeField] public int _defense { get; private set; }
    [field:SerializeField] public int _speed { get; private set; }
    [field:SerializeField] public float _price { get; private set; }
    public bool IsAvailable { get; private set; }

    public void ChangeAvailable(bool flag)
    {
        IsAvailable = flag;
    }
}
