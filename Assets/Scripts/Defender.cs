using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour
{
    [SerializeField] private int cost = 100;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public int GetCost()
    {
        return cost;
    }

    public void GetDamage(int damage)
    {
        _health.GetDamage(damage);
    }
}
