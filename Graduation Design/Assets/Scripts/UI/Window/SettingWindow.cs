using UnityEngine;
using UnityEngine.UI;
using QZGameFramework.AutoUIManager;
using System;
using QZGameFramework.MusicManager;

public class SettingWindow : WindowBase
{
    // UI面板的组件类
    public SettingWindowDataComponent dataCompt;

    private MusicData musicData;

    #region 生命周期函数

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnAwake一致
    /// </summary>
    public override void OnAwake()
    {
        dataCompt = gameObject.GetComponent<SettingWindowDataComponent>();
        dataCompt.InitUIComponent(this);
        dataCompt.MusicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        dataCompt.SoundSlider.onValueChanged.AddListener(OnSoundSliderChange);
        base.OnAwake();
    }

    /// <summary>
    /// 在物体显示时执行一次，与Mono OnEnable一致
    /// </summary>
    public override void OnShow()
    {
        base.OnShow();
        musicData = GameDataMgr.Instance.musicData;
        dataCompt.MusicSlider.value = musicData.musicVolume;
        dataCompt.MusicToggle.isOn = musicData.isMusicOn;
        dataCompt.SoundSlider.value = musicData.soundVolume;
        dataCompt.SoundToggle.isOn = musicData.isSoundOn;
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
        dataCompt.MusicSlider.onValueChanged.RemoveAllListeners();
        dataCompt.SoundSlider.onValueChanged.RemoveAllListeners();
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

    private void OnSoundSliderChange(float value)
    {
        musicData.soundVolume = value;
        MusicMgr.Instance.ChangeSoundMusicVolume(value);
        GameDataMgr.Instance.SaveMusicData(musicData);
    }

    private void OnMusicSliderChange(float value)
    {
        musicData.musicVolume = value;
        MusicMgr.Instance.ChangeGameMusicVolume(value);

        GameDataMgr.Instance.SaveMusicData(musicData);
    }

    public void OnMusicToggleChange(bool state, Toggle toggle)
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        musicData.isMusicOn = state;
        MusicMgr.Instance.SetGameMusicMute(!state);

        GameDataMgr.Instance.SaveMusicData(musicData);
    }

    public void OnSoundToggleChange(bool state, Toggle toggle)
    {
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");

        musicData.isSoundOn = state;
        MusicMgr.Instance.SetSoundMusicMute(!state);
        GameDataMgr.Instance.SaveMusicData(musicData);
    }

    #endregion
}