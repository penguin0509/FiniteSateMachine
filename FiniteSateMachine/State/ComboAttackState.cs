using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttackState : IState
{
    private PlayerController player;
    private StateMachine stateMachine;
    private float timer;

    public ComboAttackState(PlayerController player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        timer = 0f;
        player.comboStep++;
        player.comboStep = Mathf.Clamp(player.comboStep, 1, 3);
        player.TriggerAnimation("Attack" + player.comboStep);
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.J) && timer < player.comboResetTime && player.comboStep < 3)
        {
            stateMachine.ChangeState(new ComboAttackState(player, stateMachine));
        }
        else if (timer >= player.comboResetTime)
        {
            player.comboStep = 0;
            stateMachine.ChangeState(new IdleState(player, stateMachine));
        }
    }

    public void Exit() { }
}
