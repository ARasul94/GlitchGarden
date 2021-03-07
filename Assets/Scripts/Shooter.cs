using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform gun;

    private Spawner _myLaneSpawner;
    private Animator _animator;
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");
    private Transform _projectilesParent;
    private const string PROJECTILES_PARENT_NAME = "Projectile";

    private void Awake()
    {
        SetMyLaneSpawner();
        _animator = GetComponent<Animator>();
        
        var parent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (parent == null)
            parent = new GameObject(PROJECTILES_PARENT_NAME);

        _projectilesParent = parent.transform;
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
        var projectile = Instantiate(projectilePrefab, gun.position, gun.rotation);
        projectile.transform.parent = _projectilesParent;
    }
}
