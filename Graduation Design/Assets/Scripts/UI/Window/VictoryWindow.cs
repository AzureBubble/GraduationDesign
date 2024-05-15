using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using QZGameFramework.GFSceneManager;
using QZGameFramework.GFEventCenter;
using System;

public class VictoryWindow : WindowBase
{
    // UI面板的组件类
    public VictoryWindowDataComponent dataCompt;

    private Animator animator;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<VictoryWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();

        animator = dataCompt.gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        animator.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        EventCenter.Instance.AddEventListener<string>(E_EventType.VictoryTime, SetVictoryTime);
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
        animator.enabled = false;
        EventCenter.Instance.RemoveEventListener<string>(E_EventType.VictoryTime, SetVictoryTime);
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

    private void SetVictoryTime(string time)
    {
        dataCompt.TimeTextTMP_Text.text = time;
    }

    #endregion

    #region UI组件事件

    public void OnNextLevelButtonClick()
    {
        HideWindow();
        SceneMgr.LoadSceneAsync(dataCompt.sceneName);
    }

    #endregion
}