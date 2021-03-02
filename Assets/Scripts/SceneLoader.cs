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
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadSameScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }
}
