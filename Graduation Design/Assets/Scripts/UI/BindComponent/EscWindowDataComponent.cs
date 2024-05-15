using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
    public class EscWindowDataComponent : MonoBehaviour
    {
        [ReadOnly] public Button CloseButton;
        [ReadOnly] public Button GameSettingsButton;
        [ReadOnly] public Button BackButton;
        [SceneName] public string sceneName;

        public void InitUIComponent(WindowBase target)
        {
            // 组件事件绑定
            EscWindow mWindow = target as EscWindow;
            target.AddButtonClickListener(CloseButton, mWindow.OnCloseButtonClick);
            target.AddButtonClickListener(GameSettingsButton, mWindow.OnGameSettingsButtonClick);
            target.AddButtonClickListener(BackButton, mWindow.OnBackButtonClick);
        }
    }
}