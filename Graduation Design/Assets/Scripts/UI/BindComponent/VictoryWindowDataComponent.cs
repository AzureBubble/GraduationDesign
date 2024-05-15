using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
    public class VictoryWindowDataComponent : MonoBehaviour
    {
        [ReadOnly] public TMP_Text TimeTextTMP_Text;
        [ReadOnly] public Button NextLevelButton;
        [SceneName] public string sceneName;

        public void InitUIComponent(WindowBase target)
        {
            // 组件事件绑定
            VictoryWindow mWindow = target as VictoryWindow;
            target.AddButtonClickListener(NextLevelButton, mWindow.OnNextLevelButtonClick);
        }
    }
}