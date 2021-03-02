using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Attacker : MonoBehaviour
{
    [SerializeField][Range(0,3)] private float moveSpeed;
    [SerializeField] private int damage;
    

    private Defender _currentTarget;
    private Animator _animator;
    private LevelController _levelController;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _levelController = FindObjectOfType<LevelController>();
        if (_levelController == null)
            throw new Exception($"No LevelController Object on {SceneManager.GetActiveScene().name} scene");
    }

    private void Start()
    {
        _levelController.EnemySpawned();
    }

    private void OnDestroy()
    {
        _levelController.EnemyKilled();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (!_currentTarget)
            _animator.SetBool(_isAttacking, false);
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

    public void StrikeTheTarget()
    {
        if (!_currentTarget)
            return;
        
        _currentTarget.GetDamage(damage);
    }
}
