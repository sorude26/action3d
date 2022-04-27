using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LegAnimationController : MonoBehaviour
{
    [Header("�eStateType���Ƃ̃A�j���[�V�����̖��̂�ݒ肷��")]
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
    public event Action OnBrake = default;
    public event Action OnJetBoost = default;
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
        OnTurn?.Invoke();
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
        OnJetBoost?.Invoke();
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
        _currentAnime = type;
       ChangeAnimation(_animationNames[(int)type], _defaultChangeTime);
    }
    public bool ChangeAnimation(LegStateType type, bool check)
    {
        if (_currentAnime == type)
        {
            return check;
        }
        _currentAnime = type;
        ChangeAnimation(_animationNames[(int)type], _defaultChangeTime);
        return true;
    }
    public void SetAnimationSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
    public void SetAnimationFloat(bool isFloat)
    {
        _animator.SetBool("Float", isFloat);
    }
}
