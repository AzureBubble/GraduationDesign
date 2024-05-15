using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using QZGameFramework.GFSceneManager;
using System;
using QZGameFramework.MusicManager;
using System.Collections.Generic;
using QZGameFramework.GFInputManager;
using QZGameFramework.ObjectPoolManager;
using QZGameFramework.PackageMgr.ResourcesManager;
using QZGameFramework.GFEventCenter;

public class LoadingWindow : WindowBase
{
    // UI面板的组件类
    public LoadingWindowDataComponent dataCompt;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<LoadingWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
        dataCompt.player.SetActive(false);
        SceneMgr.AddBeforeSceneUnloadedUniTaskEvent(BeforeSceneUnloaded);
        SceneMgr.AddSceneLoadingUniTaskEvent(SceneLoading);
        SceneMgr.AddAfterSceneUnloadedUniTaskEvent(AfterSceneUnloaded);
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        dataCompt.player.SetActive(true);
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
        dataCompt.player.SetActive(false);
    }

    /// <summary>
    /// 在当前界面被销毁时调用一次
    /// </summary>
    public override void OnDestroy()
    {
        base.OnDestroy();
        SceneMgr.RemoveBeforeSceneUnloadedUniTaskEvent(BeforeSceneUnloaded);

        SceneMgr.RemoveAfterSceneUnloadedUniTaskEvent(AfterSceneUnloaded);
        SceneMgr.RemoveSceneLoadingUniTaskEvent(SceneLoading);
    }

    #endregion

    #region Custom API Function

    private void BeforeSceneUnloaded()
    {
        SingletonManager.DestoryAllSingleton(new List<Type> { typeof(MusicMgr), typeof(UIManager), typeof(EventCenter), typeof(InputMgr) });
    }

    private void AfterSceneUnloaded(string sceneName)
    {
        HideWindow();
        switch (sceneName)
        {
            case "Test Ground Scene":
                ResourcesMgr.Instance.LoadResAsync<GameObject>("Prefabs/Player/Player", (obj) =>
                {
                    GameObject playerObj = GameObject.Instantiate(obj);
                    EventCenter.Instance.EventTrigger(E_EventType.PlayerInstantiate, playerObj.transform);
                });
                UIManager.Instance.ShowWindow<GameWindow>();
                UIManager.Instance.ShowWindow<ReadyWindow>();
                UIManager.Instance.DestroyAllWindow(new List<string>() { typeof(LoadingWindow).Name, typeof(GameWindow).Name, typeof(ReadyWindow).Name });
                break;

            default:
                UIManager.Instance.HideWindow<GameWindow>();
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }

    private void SceneLoading(float progress)
    {
        dataCompt.LoadingBarSlider.value = progress;

        if (progress >= 0.9f)
        {
            dataCompt.LoadingBarSlider.value = 1;
        }
    }

    #endregion

    #region UI组件事件

    #endregion
}