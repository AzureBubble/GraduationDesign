using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class PlayerState_AirJump : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "AirJump";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        PoolMgr.Instance.GetObjAsync("VFX_AirJump", (vfxObj) =>
        {
            vfxObj.transform.position = transform.position;
        }, "Prefabs/VFX");

        MusicMgr.Instance.PlaySoundMusicAsync("univ0002", path: "Music/Sound/Player/");

        player.Jump(player.airJumpSpeed);
        player.CanAirJump = false;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.StopJump || player.IsFalling)
        {
            fsm.SwitchState<PlayerState_Fall>();
        }
    }

    public override void OnFixedUpdate()
    {
        player.Move(player.runSpeed);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}