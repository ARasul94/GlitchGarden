using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class QuitButton : BaseLoaderButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(Application.Quit);
        }
    }
}