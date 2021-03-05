using UnityEngine;

namespace Buttons
{
    public class BackToStartButton : BaseLoaderButton
    {
        private void Start()
        {
            ButtonComponent.onClick.AddListener(() => SceneLoader.LoadStartScene());
        }
    }
}
