using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;
    private float timer;
    private float hurtDuration = 0.5f;

    public HurtState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        timer = 0f;
        player.TriggerAnimation("IsHurt");
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= hurtDuration)
        {
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
    }

    public void Exit() { }
}
