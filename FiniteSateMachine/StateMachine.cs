using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �޲z�Ҧ����A�����P��s�����A���֤����O
public class StateMachine
{
    private IState currentState; // ��e���檺���A

    // ��l�ƪ��A���A���w�_�l���A
    public void Initialize(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    // �����ܷs���A
    public void ChangeState(IState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // �C�V�����e���A����s��k
    public void Update()
    {
        currentState?.Update();
    }
}
