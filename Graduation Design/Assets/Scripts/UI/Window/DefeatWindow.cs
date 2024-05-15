using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using QZGameFramework.GFSceneManager;
using QZGameFramework.MusicManager;
using UnityEngine.SceneManagement;

public class DefeatWindow : WindowBase
{
    // UI面板的组件类
    public DefeatWindowDataComponent dataCompt;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<DefeatWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        base.OnAwake();
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        Cursor.lockState = CursorLockMode.None;
        int index = Random.Range(4, 7);
        MusicMgr.Instance.PlaySoundMusic("univ102" + index.ToString(), path: "Music/Sound/Player/");
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

    public void OnRetryButtonClick()
    {
        SceneMgr.LoadSceneAsync(SceneManager.GetActiveScene().name);
        HideWindow();
    }

    public void OnQuitButtonClick()
    {
        SceneMgr.LoadSceneAsync(dataCompt.sceneName);
        HideWindow();
    }

    #endregion
}