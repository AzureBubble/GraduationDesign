using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
	public class AboutWindowDataComponent : MonoBehaviour
	{
		[ReadOnly] public Button CloseButton;

		public void InitUIComponent(WindowBase target)
		{
			// 组件事件绑定
			AboutWindow mWindow=target as AboutWindow;
			target.AddButtonClickListener(CloseButton,mWindow.OnCloseButtonClick);
		}
	}
}
