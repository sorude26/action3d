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
    [SerializeField]
    private ParticleSystem _walkEffect = default;
    [SerializeField]
    private ParticleSystem _landingEffect = default;
    private Animator _animator = default;
    private LegStateType _currentAnime = default;
    public event Action OnStop = default;
    public event Action OnMove = default;
    public event Action OnTurn = default;
    public event Action OnJump = default;
    public event Action OnBoost = default;
    public event Action OnBrake = default;

    private void Awake()
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
        OnTurn?.Invoke();
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
        if (_walkEffect)
        {
            _walkEffect.Play();
        }
    }
    private void SmokeEffect()
    {
        if (_landingEffect)
        {
            _landingEffect.Play();
        }
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
        Shake();
        OnJump?.Invoke();
    }
    private void Landing()
    {
        SmokeEffect();
    }
    private void GroundCheck()
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
        if(type == _currentAnime)
        {
            return;
        }
        _currentAnime = type;
       ChangeAnimation(_animationNames[(int)type], _defaultChangeTime);
    }
    public void SetAnimationSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
