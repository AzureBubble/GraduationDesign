using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using QZGameFramework.MusicManager;

public class AboutWindow : WindowBase
{
    // UI面板的组件类
    public AboutWindowDataComponent dataCompt;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<AboutWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
    }

    /// <summary>
    /// 在当前界面被销毁时调用一次
    /// </summary>
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    #endregion

    #region Custom API Function

    #endregion

    #region UI组件事件

    public void OnCloseButtonClick()
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        HideWindow();
    }

    #endregion
}