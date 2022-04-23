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
        WalkBack,
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
    [Tooltip("接地判定用センサー")]
    [SerializeField]
    private WallChecker _groundChecker = default;
    /// <summary> 現在のステート </summary>
    private ILegState _currentState = default;
    private StateIdle _sIdle = new StateIdle();
    private Vector3 _moveVector = default;
    private void Start()
    {
        _currentState = _sIdle;
    }
    private void FixedUpdate()
    {
        
    }
    private void ChangeState(StateType targetState)
    {

    }
    private void ChangeAnimation(StateType type)
    {

    }
    public void Move(Vector3 dir)
    {
        
    }
    public void Look(Vector3 dir)
    {

    }
}
