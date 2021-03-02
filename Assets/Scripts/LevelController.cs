using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private AudioClip winSound;

    public readonly UnityEvent AllEnemiesKilled = new UnityEvent();
    public readonly UnityEvent LevelTimeFinished = new UnityEvent();

    private int _numbersOfEnemies;
    private bool _isTimeFinished;
    private bool _lose;
    private SceneLoader _sceneLoader;
    private LivesDisplay _livesDisplay;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        if (_sceneLoader == null)
            throw new Exception($"No SceneLoader Object on {SceneManager.GetActiveScene().name} scene");
        
        _livesDisplay = FindObjectOfType<LivesDisplay>();
        if (_livesDisplay == null)
            throw new Exception($"No LivesDisplay Object on {SceneManager.GetActiveScene().name} scene");
    }

    private void Start()
    {
       _livesDisplay.OnLivesEnded.AddListener(LoseGame);
    }

    public void EnemySpawned()
    {
        _numbersOfEnemies++;
    }

    public void EnemyKilled()
    {
        _numbersOfEnemies--;
        if (_numbersOfEnemies <= 0 && _isTimeFinished && !_lose)
        {
            AllEnemiesKilled.Invoke();
            levelCompleteCanvas.SetActive(true);
            PlayWinSFX();
            _sceneLoader.LoadNextSceneWithDelay();
        }
    }

    public void SetTimeAsFinished()
    {
        _isTimeFinished = true;
        LevelTimeFinished.Invoke();
    }

    private void PlayWinSFX()
    {
        AudioSource.PlayClipAtPoint(winSound, Vector3.zero, 1f);
    }

    private void LoseGame()
    {
        loseCanvas.SetActive(true);
        _lose = true;
    }
}
