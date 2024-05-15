using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
	public class GameWindowDataComponent : MonoBehaviour
	{
		[ReadOnly] public TMP_Text TimeTMP_Text;

		public void InitUIComponent(WindowBase target)
		{
			// 组件事件绑定
			GameWindow mWindow=target as GameWindow;
		}
	}
}
