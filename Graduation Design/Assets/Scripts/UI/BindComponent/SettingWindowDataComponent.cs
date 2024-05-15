using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
	public class SettingWindowDataComponent : MonoBehaviour
	{
		[ReadOnly] public Button CloseButton;
		[ReadOnly] public Toggle MusicToggle;
		[ReadOnly] public Slider MusicSlider;
		[ReadOnly] public Toggle SoundToggle;
		[ReadOnly] public Slider SoundSlider;

		public void InitUIComponent(WindowBase target)
		{
			// 组件事件绑定
			SettingWindow mWindow=target as SettingWindow;
			target.AddButtonClickListener(CloseButton,mWindow.OnCloseButtonClick);
			target.AddToggleClickListener(MusicToggle,mWindow.OnMusicToggleChange);
			target.AddToggleClickListener(SoundToggle,mWindow.OnSoundToggleChange);
		}
	}
}
