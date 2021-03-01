using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject deathVFX;


    public void GetDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            PlayDeathVFX();
        }
    }

    private void PlayDeathVFX()
    {
        if (!deathVFX)
            return;

        var deathVfxObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVfxObj, 2f);
    }
}
