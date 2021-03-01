using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField][Range(0,3)] private float moveSpeed;

    private Defender _currentTarget;
    private Animator _animator;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void Attack(Defender target)
    {
        _animator.SetBool(_isAttacking, true);
        _currentTarget = target;
    }
}
