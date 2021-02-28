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
            StartCoroutine(LoadWithDelay());
        }
    }

    private IEnumerator LoadWithDelay()
    {
        yield return new WaitForSeconds(waitForLoad);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
}
