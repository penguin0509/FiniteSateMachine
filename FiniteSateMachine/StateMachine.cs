using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 管理所有狀態切換與更新的狀態機核心類別
public class StateMachine
{
    private IState currentState; // 當前執行的狀態

    // 初始化狀態機，指定起始狀態
    public void Initialize(IState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    // 切換至新狀態
    public void ChangeState(IState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // 每幀執行當前狀態的更新方法
    public void Update()
    {
        currentState?.Update();
    }
}
