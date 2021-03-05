using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Buttons
{
    [RequireComponent(typeof(Button))]
    public class BaseLoaderButton : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        private Button _buttonComponent;
        protected SceneLoader SceneLoader => _sceneLoader;

        protected Button ButtonComponent => _buttonComponent;

        public void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
            _buttonComponent = GetComponent<Button>();
        }

        public void Start()
        {
            if (_sceneLoader == null)
                throw new Exception($"No SceneLoader Object on {SceneManager.GetActiveScene().name} scene");
        }
    }
}
