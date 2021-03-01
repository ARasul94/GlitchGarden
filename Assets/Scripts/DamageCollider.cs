using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageCollider : MonoBehaviour
{

    private LivesDisplay _livesDisplay;
    private void Awake()
    {
        _livesDisplay = FindObjectOfType<LivesDisplay>();

        if (_livesDisplay == null)
            throw new Exception($"No LivesDisplayObject on {SceneManager.GetActiveScene().name} scene");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _livesDisplay.LoseLife();
        Destroy(other.gameObject);
    }
}
