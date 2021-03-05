using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float waitForLoad; 
    private int _currentSceneIndex;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (_currentSceneIndex == 0)
        {
            LoadNextSceneWithDelay();
        }
    }

    public void LoadNextSceneWithDelay()
    {
        StartCoroutine(LoadWithDelay(waitForLoad));
    }
    private IEnumerator LoadWithDelay(float time)
    {
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        _currentSceneIndex++;
        Load();
    }

    public void LoadGameScene()
    {
        _currentSceneIndex = 2;
        Load();
    }
    
    public void LoadOptionsScene()
    {
        _currentSceneIndex = 4;
        Load();
    }

    public void LoadStartScene()
    {
        _currentSceneIndex = 0;
        Load();
    }
    
    public void LoadSameScene()
    {
        Load();
    }

    private void Load()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
