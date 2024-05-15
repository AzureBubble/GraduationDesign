using UnityEngine;

public class PlayerState_Run : PlayerState
{
    public override void Init()
    {
        base.Init();
        animationName = "Run";
    }

    public override void OnEnter()
    {
        base.OnEnter();
        curSpeed = player.MoveSpeed;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!player.IsMove)
        {
            fsm.SwitchState<PlayerState_Idle>();
        }
        if (player.IsJump)
        {
            fsm.SwitchState<PlayerState_Jump>();
        }

        if (!player.IsGrounded)
        {
            fsm.SwitchState<PlayerState_CoyoteTime>();
        }

        curSpeed = Mathf.MoveTowards(curSpeed, player.runSpeed, player.acceleration * Time.deltaTime);
    }

    public override void OnFixedUpdate()
    {
        player.Move(curSpeed);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}