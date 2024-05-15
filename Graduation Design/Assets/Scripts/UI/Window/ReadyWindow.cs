using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;

public class ReadyWindow : WindowBase
{
    // UI面板的组件类
    public ReadyWindowDataComponent dataCompt;

    private Animator animator;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<ReadyWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
        animator = dataCompt.gameObject.GetComponent<Animator>();
        animator.enabled = false;
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        animator.enabled = true;
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
        animator.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
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

    #endregion
}