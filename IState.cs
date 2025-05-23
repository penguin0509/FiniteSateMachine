using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 狀態機通用介面，所有狀態需實作進入、更新、離開方法
public interface IState
{
    void Enter();    // 狀態剛啟用時呼叫
    void Update();   // 每一幀執行的邏輯
    void Exit();     // 離開狀態時呼叫
}
