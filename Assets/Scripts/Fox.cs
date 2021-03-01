using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker), typeof(Animator))]
public class Fox : MonoBehaviour
{
    private Attacker _attacker;
    private Animator _animator;
    private readonly int _isJumping = Animator.StringToHash("IsJumping");

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var defender = other.GetComponent<Defender>();

        if (!defender)
            return;

        var gravestone = other.GetComponent<Gravestone>();
        if (gravestone)
        {
            _animator.SetTrigger(_isJumping);
        }
        else
        {
            _attacker.Attack(defender);
        }
        
    }
}