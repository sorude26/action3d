using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LegAnimationController : MonoBehaviour
{
    [Header("各StateTypeごとのアニメーションの名称を設定する")]
    [SerializeField]
    private string[] _animationNames = default;
    [SerializeField]
    private float _defaultChangeTime = 0.2f;
    private Animator _animator = default;
    public event Action OnStop = default;
    public event Action OnMove = default;
    public event Action OnTurn = default;
    public event Action OnJump = default;
    public event Action OnBoost = default;
    public event Action OnBrake = default;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void ChangeAnimation(string changeTarget, float changeTime)
    {
        _animator.CrossFadeInFixedTime(changeTarget, changeTime);
    }
    #region AnimatorEvent
    private void Walk()
    {
        OnMove?.Invoke();
    }
    private void Run()
    {
        OnMove?.Invoke();
    }
    private void Move()
    {
        OnMove?.Invoke();
    }
    private void AttackMove()
    {
        OnMove?.Invoke();
    }
    private void AttackMoveStrong()
    {
        OnMove?.Invoke();
    }
    private void Shake()
    {
    }
    private void SmokeEffect()
    {
    }
    private void TurnLeft()
    {
        OnTurn?.Invoke();
    }
    private void TurnRight()
    {
        OnTurn?.Invoke();
    }
    private void Jump()
    {
        OnJump?.Invoke();
    }
    private void Landing()
    {
    }
    private void Jet()
    {
        OnBoost?.Invoke();
    }
    private void Stop()
    {
        OnStop?.Invoke();
    }
    private void Brake()
    {
        OnBrake?.Invoke();
    }
    #endregion
    public void ChangeAnimation(LegStateType type) 
    {
       ChangeAnimation(_animationNames[(int)type], _defaultChangeTime);
    }
}
