using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Buttons
{
    public class DefaultOptionButton : BaseLoaderButton
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
            ButtonComponent.onClick.AddListener(ResetSettings);
        }

        private void ResetSettings()
        {
            _optionsController.ResetOptions();
        }
    }
}
