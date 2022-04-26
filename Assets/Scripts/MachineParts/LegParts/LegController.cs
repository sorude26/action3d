using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController : MonoBehaviour
{
    private const float JUMP_UPVECTOR = 0.5f;
    private const float JET_UPVECTOR = 0.2f;
    [Tooltip("接地判定用センサー")]
    [SerializeField]
    private WallChecker _groundChecker = default;
    [Tooltip("脚部アニメーション制御")]
    [SerializeField]
    private LegAnimationController _legAnimetor = default;
    #region PrivateField
    private ActionParameter _parameter = default;
    private MoveController _moveController = null;
    /// <summary> 起動中フラグ </summary>
    private bool _isActive = false;
    /// <summary> 移動目標方向 </summary>
    private Vector3 _moveVector = default;
    private Vector3 _jumpVector = default;
    private Vector3 _turnVector = default;
    private Vector3 _jetVector = default;
    /// <summary> 現在のステート </summary>
    private ILegState _currentState = default;
    /// <summary> 現在のステート種類 </summary>
    private LegStateType _currentStateType = default;
    /// <summary> ステート用タイマー </summary>
    private float _stateTimer = default;
    /// <summary> ステート用フラグ </summary>
    private bool _isStateOn = default;
    /// <summary> 浮遊モードフラグ </summary>
    private bool _isFloat = default;
    #region LegState
    private StateIdle _sIdle = new StateIdle();
    private StateWalk _sWalk = new StateWalk();
    private StateJump _sJump = new StateJump();
    private StateFall _sFall = new StateFall();
    private StateFloat _sFloat = new StateFloat();
    private StateBoost _sBoost = new StateBoost();
    private StateLanding _sLanding = new StateLanding();
    #endregion
    #endregion
    public LegStateType Current { get => _currentStateType; }
    private void Start()
    {
        _currentStateType = LegStateType.Idle;
        _currentState = _sIdle;
        _legAnimetor.OnMove += OnMove;
        _legAnimetor.OnTurn += OnTurn;
        _legAnimetor.OnStop += OnStop;
        _legAnimetor.OnJump += OnJump;
        _legAnimetor.OnBrake += OnBreak;
        _legAnimetor.OnJetBoost += OnJetBoost;
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

    #region LegAnimationEvent
    private void OnMove()
    {
        if (_moveVector.z > 0)
        {
            if (_stateTimer < 0)
            {
                _moveController.MoveRun(_legAnimetor.transform.forward);
                return;
            }
            _moveController.MoveWalk(_legAnimetor.transform.forward);
        }
        else
        {
            _moveController.MoveWalk(-_legAnimetor.transform.forward);
        }
    }
    private void OnTurn()
    {
        _moveController.Turn(_turnVector.x);
    }
    private void OnJump()
    {
        Vector3 dir = _legAnimetor.transform.forward * _jumpVector.z + _legAnimetor.transform.right * _jumpVector.x + Vector3.up * JUMP_UPVECTOR;
        _moveController.MoveJump(dir.normalized);
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
        _moveController.MoveBoost(dir.normalized);
    }
    private void OnJetBoost()
    {
        Vector3 dir = _legAnimetor.transform.forward * _jetVector.z + _legAnimetor.transform.right * _jetVector.x + Vector3.up * JET_UPVECTOR;
        _moveController.MoveJetBoost(dir.normalized);
    }
    #endregion
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
    public void JetBoost()
    {
        if (_currentStateType == LegStateType.Fall || _currentStateType == LegStateType.Float || _currentStateType == LegStateType.Jump)
        {
            ChangeState(LegStateType.Boost);
            return;
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
