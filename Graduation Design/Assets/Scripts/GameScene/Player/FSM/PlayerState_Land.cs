using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class PlayerState_Land : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Land";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.SetVelocity(Vector3.zero);
        GameObject vfxObj = PoolMgr.Instance.GetObj("VFX_Jump", "Prefabs/VFX");
        vfxObj.transform.position = transform.position;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.HasJumpInputBuffer || player.IsJump)
        {
            fsm.SwitchState<PlayerState_Jump>();
        }
        if (CurrentAnimationTime < player.stiffTime)
        {
            return;
        }
        if (player.IsMove)
        {
            fsm.SwitchState<PlayerState_Run>();
        }
        if (IsAnimationFinished)
        {
            fsm.SwitchState<PlayerState_Idle>();
        }
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}