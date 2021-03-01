using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var defender = other.GetComponent<Defender>();

        if (!defender)
            return;
        
        _attacker.Attack(defender);
    }
}
