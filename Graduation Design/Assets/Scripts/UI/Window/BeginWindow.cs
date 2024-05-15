using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using QZGameFramework.GFSceneManager;
using QZGameFramework.MusicManager;

public class BeginWindow : WindowBase
{
    // UI面板的组件类
    public BeginWindowDataComponent dataCompt;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<BeginWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
        SceneMgr.AddBeforeSceneUnloadedUniTaskEvent(BeforeSceneUnloaded);
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// 在物体隐藏时执行一次，与Mono OnDisable 一致
    /// </summary>
    public override void OnHide()
    {
        base.OnHide();
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// 在当前界面被销毁时调用一次
    /// </summary>
    public override void OnDestroy()
    {
        base.OnDestroy();
        SceneMgr.RemoveBeforeSceneUnloadedUniTaskEvent(BeforeSceneUnloaded);
    }

    #endregion

    #region Custom API Function

    private void BeforeSceneUnloaded()
    {
        UIManager.Instance.ShowWindow<LoadingWindow>();
        HideWindow();
    }

    #endregion

    #region UI组件事件

    public void OnStartGameButtonClick()
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        SceneMgr.LoadSceneAsync(dataCompt.sceneName);
    }

    public void OnAboutGameButtonClick()
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        UIManager.Instance.ShowWindow<AboutWindow>();
    }

    public void OnGameSettingsButtonClick()
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        UIManager.Instance.ShowWindow<SettingWindow>();
    }

    public void OnQuitGameButtonClick()
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    #endregion
}