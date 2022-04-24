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
    private MoveController _moveController = null;
    private bool _isActive = false;
    private Vector3 _moveVector = default;
    private Vector3 _jumpVector = default;
    private Vector3 _currentDir = default;
    /// <summary> 現在のステート </summary>
    private ILegState _currentState = default;
    private LegStateType _currentStateType = default;
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
        _currentStateType = LegStateType.Idle;
        _currentState = _sIdle;
        _legAnimetor.OnMove += OnMove;
        _legAnimetor.OnTurn += OnTurn;
        _legAnimetor.OnStop += OnStop;
        _legAnimetor.OnJump += OnJump;
        _legAnimetor.OnBrake += OnBreak;
    }
    private void Update()
    {
        if (_isActive)
        {
            _currentState.OnUpdate(this);
        }
    }
    private void FixedUpdate()
    {
        if (_isActive)
        {
            _currentState.OnFixedUpdate(this);
        }
    }
    private void ChangeState(LegStateType targetState)
    {
        if (_currentStateType == targetState)
        {
            return;
        }
        _currentStateType = targetState;
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
    private void OnMove()
    {
        if(_moveVector.z > 0)
        {
            _moveController.MoveWalk(_legAnimetor.transform.forward);
        }
        else
        {
            _moveController.MoveWalk(-_legAnimetor.transform.forward);
        }
    }
    private void OnTurn()
    {
        _moveController.Turn(_currentDir.x);
    }
    private void OnJump()
    {
        Vector3 dir = _legAnimetor.transform.forward * _jumpVector.z + _legAnimetor.transform.right * _jumpVector.x;
        _moveController.MoveJump(dir.normalized + Vector3.up);
    }
    private void OnStop()
    {
        ChangeState(LegStateType.Idle);
    }
    private void OnBreak()
    {
        _moveController.MoveBrake();
    }
    private void OnBoost()
    {
        Vector3 dir = _legAnimetor.transform.forward * _moveVector.z + _legAnimetor.transform.right * _moveVector.x + Vector3.up;
        _moveController.MoveJet(dir.normalized);
    }
    public void StartSet(ActionParameter parameter, MoveController controller)
    {
        _parameter = parameter;
        _moveController = controller;
        _isActive = true;
        _legAnimetor.SetAnimationSpeed(_parameter.ActionSpeed);
    }
    public void Jump()
    {
        if (_currentStateType == LegStateType.Float)
        {
            return;
        }
        if (_groundChecker.IsWalled())
        {
            ChangeState(LegStateType.Jump);
        }
    }
    public void Boost()
    {
        if (_currentStateType == LegStateType.Fall)
        {
            OnBoost();
        }
    }
    public void ChangeMode()
    {
        if (_currentStateType == LegStateType.Landing)
        {
            return;
        }
        if (_currentStateType == LegStateType.Float)
        {
            _isStateOn = false;
        }
        else
        {
            ChangeState(LegStateType.Float);
        }
    }
    public void Move(Vector3 dir)
    {
        _moveVector = Vector3.zero;
        if (dir.x > 0)
        {
            _moveVector.x = 1;
        }
        else if (dir.x < 0)
        {
            _moveVector.x = -1;
        }
        if(dir.z > 0)
        {
            _moveVector.z = 1;
        }
        else if(dir.z < 0)
        {
            _moveVector.z = -1;
        }
        if (_currentStateType != LegStateType.Idle)
        {
            return;
        }
        if (_moveVector != Vector3.zero) 
        {
            ChangeState(LegStateType.Walk);
        }
    }
    public void Look(Vector3 dir)
    {

    }
}
