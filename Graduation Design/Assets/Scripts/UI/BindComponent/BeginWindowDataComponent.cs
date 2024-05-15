using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
    public class BeginWindowDataComponent : MonoBehaviour
    {
        [ReadOnly] public Button StartGameButton;
        [ReadOnly] public Button AboutGameButton;
        [ReadOnly] public Button GameSettingsButton;
        [ReadOnly] public Button QuitGameButton;
        [SceneName] public string sceneName;

        public void InitUIComponent(WindowBase target)
        {
            // 组件事件绑定
            BeginWindow mWindow = target as BeginWindow;
            target.AddButtonClickListener(StartGameButton, mWindow.OnStartGameButtonClick);
            target.AddButtonClickListener(AboutGameButton, mWindow.OnAboutGameButtonClick);
            target.AddButtonClickListener(GameSettingsButton, mWindow.OnGameSettingsButtonClick);
            target.AddButtonClickListener(QuitGameButton, mWindow.OnQuitGameButtonClick);
        }
    }
}