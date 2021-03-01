using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int damage = 50;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.gameObject.GetComponent<Health>();
        var attacker = other.gameObject.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
