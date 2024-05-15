using UnityEngine;

public class PlayerState_CoyoteTime : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "CoyoteTime";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        player.SetUseGravity(false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.IsJump)
        {
            fsm.SwitchState<PlayerState_Jump>();
        }

        if (CurrentAnimationTime > player.coyoteTime || !player.IsMove)
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
        player.SetUseGravity(true);
    }
}