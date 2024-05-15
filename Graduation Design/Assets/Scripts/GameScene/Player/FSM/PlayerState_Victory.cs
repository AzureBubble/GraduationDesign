using QZGameFramework.MusicManager;
using QZGameFramework.PackageMgr.ResourcesManager;
using UnityEngine;

public class PlayerState_Victory : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Victory";
    }

    public override void OnEnter()
    {
        base.OnEnter();

        int index = Random.Range(8, 11);
        MusicMgr.Instance.PlaySoundMusic(index < 10 ? "univ101" + index.ToString() : "univ1020", path: "Music/Sound/Player/");
    }

    public override void OnUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}