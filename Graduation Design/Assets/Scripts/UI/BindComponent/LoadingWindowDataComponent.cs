using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
    public class LoadingWindowDataComponent : MonoBehaviour
    {
        [ReadOnly] public Slider LoadingBarSlider;
        [ReadOnly] public GameObject player;

        public void InitUIComponent(WindowBase target)
        {
            // 组件事件绑定
            LoadingWindow mWindow = target as LoadingWindow;
        }
    }
}