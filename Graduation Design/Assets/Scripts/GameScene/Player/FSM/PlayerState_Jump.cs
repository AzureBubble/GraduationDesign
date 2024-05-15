using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class PlayerState_Jump : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Jump";
        animationTransitionTime = 0;
        player.IsJump = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.HasJumpInputBuffer = false;

        player.Jump(player.jumpSpeed);
        MusicMgr.Instance.PlaySoundMusic("univ0001", path: "Music/Sound/Player/");

        GameObject vfxObj = PoolMgr.Instance.GetObj("VFX_Jump", "Prefabs/VFX");
        vfxObj.transform.position = transform.position;
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
        player.StopJump = false;
    }
}