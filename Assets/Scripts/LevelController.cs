using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public readonly UnityEvent AllEnemiesKilled = new UnityEvent();
    public readonly UnityEvent LevelTimeFinished = new UnityEvent();

    private int _numbersOfEnemies;
    private bool _isTimeFinished;

    public void EnemySpawned()
    {
        _numbersOfEnemies++;
    }

    public void EnemyKilled()
    {
        _numbersOfEnemies--;
        if (_numbersOfEnemies <= 0 && _isTimeFinished)
        {
            AllEnemiesKilled.Invoke();
            Debug.Log("All enemies killed");
            Debug.Log("Level finished");
        }
    }

    public void SetTimeAsFinished()
    {
        _isTimeFinished = true;
        LevelTimeFinished.Invoke();
    }
}
