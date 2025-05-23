using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;

    public MoveState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.SetAnimationBool("IsJumping", false);
    }

    public void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        player.Move(move);
        player.SetAnimationFloat("Speed", Mathf.Abs(move));

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
        if (move == 0)
        {
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
    }

    public void Exit() { }
}
