using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QZGameFramework.AutoUIManager
{
	public class ReadyWindowDataComponent : MonoBehaviour
	{

		public void InitUIComponent(WindowBase target)
		{
			// 组件事件绑定
			ReadyWindow mWindow=target as ReadyWindow;
		}
	}
}
