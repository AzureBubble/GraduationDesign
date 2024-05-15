using UnityEngine;

public class PlayerState_Idle : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Idle";
    }

    public override void OnEnter()
    {
        base.OnEnter();

        curSpeed = player.MoveSpeed;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (player.IsMove)
        {
            fsm.SwitchState<PlayerState_Run>();
        }
        if (player.IsJump)
        {
            fsm.SwitchState<PlayerState_Jump>();
        }
        if (!player.IsGrounded)
        {
            fsm.SwitchState<PlayerState_Fall>();
        }

        curSpeed = Mathf.MoveTowards(curSpeed, 0f, player.deceleration * Time.deltaTime);
    }

    public override void OnFixedUpdate()
    {
        player.SetVelocityX(curSpeed * transform.localScale.x);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}