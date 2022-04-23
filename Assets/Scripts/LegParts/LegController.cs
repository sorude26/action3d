using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController : MonoBehaviour
{
    private enum StateType
    {
        Idle,
        Fall,
        Walk,
        Ran,
        Jump,
        JumpLeft,
        JumpRight,
        Landing,
        TurnLeft,
        TurnRight,
        BoostFlont,
        BoostBack,
        BoostLeft,
        BoostRight,
        AttackLeft,
        AttackRight,
    }
    [Tooltip("�ݒn����p�Z���T�[")]
    [SerializeField]
    private WallChecker _groundChecker = default;
    /// <summary> ���݂̃X�e�[�g </summary>
    private ILegState _currentState = default;
    private StateIdle _sIdle = new StateIdle();
    private void Start()
    {
        _currentState = _sIdle;
    }
    private void FixedUpdate()
    {
        
    }
    private void ChangeState()
    {

    }
}
