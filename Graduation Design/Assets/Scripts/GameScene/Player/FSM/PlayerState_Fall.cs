using UnityEngine;

public class PlayerState_Fall : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Fall";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.IsGrounded)
        {
            fsm.SwitchState<PlayerState_Land>();
        }

        if (player.IsJump)
        {
            if (player.CanAirJump)
            {
                fsm.SwitchState<PlayerState_AirJump>();
                return;
            }

            player.JumpInputBufferAsync().Forget();
        }
    }

    public override void OnFixedUpdate()
    {
        player.Move(player.runSpeed);
        player.SetVelocityY(player.speedCurve.Evaluate(CurrentAnimationTime));
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}