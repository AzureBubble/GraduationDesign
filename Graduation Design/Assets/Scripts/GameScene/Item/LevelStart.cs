using QZGameFramework.AutoUIManager;
using QZGameFramework.GFEventCenter;
using QZGameFramework.MusicManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public void LevelStartFunction()
    {
        EventCenter.Instance.EventTrigger(E_EventType.LevelStart);
        UIManager.Instance.HideWindow<ReadyWindow>();
    }

    public void PlayStartVoice()
    {
        MusicMgr.Instance.PlaySoundMusic("univ1016", path: "Music/Sound/Player/");
    }
}