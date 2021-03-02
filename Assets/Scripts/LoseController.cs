using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseController : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button menuButton;

    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
        if (_sceneLoader == null)
            throw new Exception($"No SceneLoader Object on {SceneManager.GetActiveScene().name} scene");
    }

    private void Start()
    {
        retryButton.onClick.AddListener(RetryButtonClicked);
        menuButton.onClick.AddListener(MenuButtonClicked);
    }

    private void RetryButtonClicked()
    {
        _sceneLoader.LoadSameScene();
    }

    private void MenuButtonClicked()
    {
        _sceneLoader.LoadStartScene();
    }
}
