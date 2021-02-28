using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gun;

    private Spawner _myLaneSpawner;
    private Animator _animator;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private void Awake()
    {
        SetMyLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(_isAttacking, IsAnyAttackerOnLine());
    }

    private void SetMyLaneSpawner()
    {
        var spawners = FindObjectsOfType<Spawner>();
        foreach (var spawner in spawners)
        {
            if ((int) spawner.transform.position.y != (int) transform.position.y) 
                continue;
            
            _myLaneSpawner = spawner;
            return;
        }
    }

    private bool IsAnyAttackerOnLine()
    {
        return _myLaneSpawner.transform.childCount > 0;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.position, gun.rotation);
        return;
    }
}
