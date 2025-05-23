using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;

    public IdleState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.SetAnimationFloat("Speed", 0f);
        player.SetAnimationBool("IsJumping", false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(new DashState(player, stateMachine));
            return;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            stateMachine.ChangeState(new ComboAttackState(player, stateMachine));
            return;
        }
        if (Input.GetButtonDown("Jump") && player.IsGrounded())
        {
            stateMachine.ChangeState(new JumpState(player, stateMachine));
            return;
        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            stateMachine.ChangeState(new MoveState(player, stateMachine));
        }
    }

    public void Exit() { }
}
