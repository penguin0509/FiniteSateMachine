using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

// ���b���a����W�A�B�z��J�B�ʵe�P���A����
public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("���ʻP���D")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("�Ĩ�")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;

    [Header("�a������")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [Header("��q�P�ˮ`")]
    public int maxHP = 100;
    private int currentHP;

    [Header("�s�q����")]
    public float comboResetTime = 0.4f;
    [HideInInspector] public int comboStep = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine();
    }

    private void Start()
    {
        currentHP = maxHP;
        stateMachine.Initialize(new IdleState(this, stateMachine));
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void Dash(float direction)
    {
        rb.velocity = new Vector2(direction * dashSpeed, 0);
    }

    public void Die()
    {
        stateMachine.ChangeState(new DieState(this, stateMachine));
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0) Die();
        else stateMachine.ChangeState(new HurtState(this, stateMachine));
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void SetAnimationFloat(string param, float value) => animator.SetFloat(param, value);
    public void SetAnimationBool(string param, bool value) => animator.SetBool(param, value);
    public void TriggerAnimation(string param) => animator.SetTrigger(param);
}
