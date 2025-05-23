using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;
    private float timer;
    private float direction;

    public DashState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        timer = 0f;
        direction = Input.GetAxisRaw("Horizontal");
        player.TriggerAnimation("Dash");
        player.Dash(direction);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= player.dashDuration)
        {
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
    }

    public void Exit() { }
}
