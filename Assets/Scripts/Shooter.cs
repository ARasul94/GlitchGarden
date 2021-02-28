using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gun;
    
    
    public void Fire()
    {
        Instantiate(projectile, gun.position, gun.rotation);
        return;
    }
}
