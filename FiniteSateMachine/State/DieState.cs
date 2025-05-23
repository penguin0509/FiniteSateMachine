using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;

    public DieState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        player.TriggerAnimation("Die");
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Update() { }

    public void Exit() { }
}
