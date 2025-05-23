using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;

    public JumpState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.Jump();
        player.SetAnimationBool("IsJumping", true);
    }

    public void Update()
    {
        if (player.IsGrounded())
        {
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
    }

    public void Exit() { }
}
