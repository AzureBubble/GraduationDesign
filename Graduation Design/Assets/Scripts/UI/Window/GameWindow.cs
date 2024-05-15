using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using System;
using QZGameFramework.GFEventCenter;

public class GameWindow : WindowBase
{
    // UI面板的组件类
    public GameWindowDataComponent dataCompt;

    private float clearTime;
    private bool isStart;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<GameWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        clearTime = 0;
        dataCompt.TimeTMP_Text.text = "00:00:00";
        SingletonManager.AddFixedUpdateListener(OnUpdate);
        EventCenter.Instance.AddEventListener(E_EventType.LevelStart, StartClearTime);
        EventCenter.Instance.AddEventListener(E_EventType.Victory, StopClearTime);
        EventCenter.Instance.AddEventListener(E_EventType.PlayerDefeated, StopClearTime);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (isStart)
        {
            clearTime += Time.deltaTime;
            dataCompt.TimeTMP_Text.text = TimeSpan.FromSeconds(clearTime).ToString(@"mm\:ss\:ff");
        }
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
        SingletonManager.RemoveFixedUpdateListener(OnUpdate);
        EventCenter.Instance.RemoveEventListener(E_EventType.LevelStart, StartClearTime);
        EventCenter.Instance.RemoveEventListener(E_EventType.Victory, StopClearTime);
        EventCenter.Instance.RemoveEventListener(E_EventType.PlayerDefeated, StopClearTime);
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

    public void StartClearTime()
    {
        this.isStart = true;
    }

    public void StopClearTime()
    {
        this.isStart = false;
        EventCenter.Instance.EventTrigger(E_EventType.VictoryTime, dataCompt.TimeTMP_Text.text);
        HideWindow();
    }

    #endregion

    #region UI组件事件

    #endregion
}