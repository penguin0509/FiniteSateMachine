using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���A���q�Τ����A�Ҧ����A�ݹ�@�i�J�B��s�B���}��k
public interface IState
{
    void Enter();    // ���A��ҥήɩI�s
    void Update();   // �C�@�V���檺�޿�
    void Exit();     // ���}���A�ɩI�s
}
