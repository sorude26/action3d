using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController : MonoBehaviour
{
    
    [Tooltip("接地判定用センサー")]
    [SerializeField]
    private WallChecker _groundChecker = default;
    [Tooltip("脚部アニメーション制御")]
    [SerializeField]
    private LegAnimationController _legAnimetor = default;
    private ActionParameter _parameter = default;
    private Vector3Int _moveVector = default;
    /// <summary> 現在のステート </summary>
    private ILegState _currentState = default;
    private float _stateTimer = default;
    private bool _isStateOn = default;
    #region LegState
    private StateIdle _sIdle = new StateIdle();
    private StateWalk _sWalk = new StateWalk();
    private StateJump _sJump = new StateJump();
    private StateFall _sFall = new StateFall();
    private StateFloat _sFloat = new StateFloat();
    private StateBoost _sBoost = new StateBoost();
    private StateLanding _sLanding = new StateLanding();
    #endregion
    private void Start()
    {
        _currentState = _sIdle;
    }
    private void Update()
    {
        _currentState.OnUpdate(this);
    }
    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);
    }
    private void ChangeState(LegStateType targetState)
    {
        switch (targetState)
        {
            case LegStateType.Idle:
                _currentState = _sIdle;
                break;
            case LegStateType.Fall:
                _currentState = _sFall;
                break;
            case LegStateType.Walk:
                _currentState = _sWalk;
                break;
            case LegStateType.Jump:
                _currentState = _sJump;
                break;
            case LegStateType.Float:
                _currentState = _sFloat;
                break;
            case LegStateType.Landing:
                _currentState = _sLanding;
                break;
            case LegStateType.Boost:
                _currentState = _sBoost;
                break;
            default:
                break;
        }
        _currentState.OnEnter(this);
    }
    private void ChangeAnimation(LegStateType type)
    {
        _legAnimetor.ChangeAnimation(type);
    }
    public void Move(Vector3 dir)
    {

    }
    public void Look(Vector3 dir)
    {

    }
}
