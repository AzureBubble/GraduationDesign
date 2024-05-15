using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
    public class DefeatWindowDataComponent : MonoBehaviour
    {
        [ReadOnly] public Button RetryButton;
        [ReadOnly] public Button QuitButton;
        [SceneName] public string sceneName;

        public void InitUIComponent(WindowBase target)
        {
            // 组件事件绑定
            DefeatWindow mWindow = target as DefeatWindow;
            target.AddButtonClickListener(RetryButton, mWindow.OnRetryButtonClick);
            target.AddButtonClickListener(QuitButton, mWindow.OnQuitButtonClick);
        }
    }
}