using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class PlayerState_Defeat : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Defeat";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        //int index = Random.Range(1, 5);
        //MusicMgr.Instance.PlaySoundMusic("univ109" + index.ToString(), path: "Music/Sound/Player/");

        //MusicMgr.Instance.PlaySoundMusic("univ1091", path: "Music/Sound/Player/");
        MusicMgr.Instance.PlayRandomSoundMusic(path: "Music/Sound/Player/Defeat");

        GameObject vfxObj = PoolMgr.Instance.GetObj("VFX_Explosion", "Prefabs/VFX");
        vfxObj.transform.position = transform.position;
    }

    public override void OnUpdate()
    {
        if (IsAnimationFinished)
        {
            fsm.SwitchState<PlayerState_Float>();
        }
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        base.OnExit();
        player.Dead = false;
    }
}