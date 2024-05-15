using QZGameFramework.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState
{
    protected PlayerObject player;
    protected float curSpeed;

    public override void Init()
    {
        player = this.gameObject.GetComponent<PlayerObject>();
    }

    public override void OnUpdate()
    {
        if (player.Victory && player.IsGrounded)
        {
            fsm.SwitchState<PlayerState_Victory>();
        }

        if (player.Dead)
        {
            fsm.SwitchState<PlayerState_Defeat>();
        }
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
    }
}