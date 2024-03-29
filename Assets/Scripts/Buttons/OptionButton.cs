﻿using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public class OptionButton : BaseLoaderButton
    {
        private void Start()
        {
            base.Start();
            ButtonComponent.onClick.AddListener(() => SceneLoader.LoadOptionsScene());
        }
    }
}