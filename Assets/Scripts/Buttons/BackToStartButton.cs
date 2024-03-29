﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class BackToStartButton : BaseLoaderButton
    {
        private OptionsController _optionsController;
        private void Awake()
        {
            base.Awake();
            _optionsController = FindObjectOfType<OptionsController>();
            if (_optionsController == null)
                throw new Exception($"No OptionController Object on {SceneManager.GetActiveScene().name} scene");
        }
        
        private void Start()
        {
            base.Start();
            ButtonComponent.onClick.AddListener(BackToStart);
        }

        private void BackToStart()
        {
            SceneLoader.LoadStartScene();
        }
    }
}
