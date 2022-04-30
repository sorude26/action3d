using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BodyController : MonoBehaviour
{
    [Tooltip("ƒJƒƒ‰‚Ì–Ú•W")]
    [SerializeField]
    public Transform _bodyRotaionTarget = default;
    [SerializeField]
    private Transform[] _bodyControlBase = new Transform[2];
    [SerializeField]
    private Transform _controlTarget = default;
    [SerializeField]
    private HandController _leftArm = default;
    [SerializeField]
    private HandController _rightArm = default;

    private IBodyState _currentState = default;
    private StateIdle _sIdle = new StateIdle();
    private Quaternion _bodyRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _headRotaion = Quaternion.Euler(0, 0, 0);
    private Vector3 _targetCurrent = default;
    private Vector3 _targetBefore = default;
    private Vector3 _targetTwoBefore = default;
    public float BodyRSpeed { get; set; } = 3.0f;
    public float BodyTurnRange { get; set; } = 0.4f;
    public float WeaponShotSpeed { get; set; } = 120f;
    private void Start()
    {
        _currentState = _sIdle;
    }
    private void Update()
    {
        _currentState.OnUpdate(this);
    }
    private void PartsMotion()
    {
        //“ª•”‘€ì
        _bodyControlBase[1].localRotation = Quaternion.Lerp(_bodyControlBase[1].localRotation, _headRotaion, BodyRSpeed * Time.deltaTime);
        //“·‘Ì‘€ì
        _bodyControlBase[0].localRotation = Quaternion.Lerp(_bodyControlBase[0].localRotation, _bodyRotaion, BodyRSpeed * Time.deltaTime);
        _bodyRotaionTarget.localRotation = _bodyControlBase[0].localRotation;
        if (_leftArm)
        {
            _leftArm.PartsMotion();
        }
        if (_rightArm)
        {
            _rightArm.PartsMotion();
        }
    }
    public void SetLockOn(Vector3 targetPos)
    {
        _targetBefore = targetPos;
        _targetTwoBefore = targetPos;
        LockOn(targetPos);
    }
    private void LockOn(Vector3 targetPos)
    {
        Vector3 targetDir = targetPos - _bodyControlBase[0].position;
        targetDir.y = 0.0f;
        if (BodyTurnRange > 0 && Vector3.Dot(targetDir.normalized, _bodyControlBase[0].forward) < BodyTurnRange)
        {
            return;
        }
        _targetCurrent = ShootingCalculation.CirclePrediction(_bodyControlBase[0].position, targetPos, _targetBefore, _targetTwoBefore, WeaponShotSpeed);
        targetDir = _targetCurrent - _bodyControlBase[0].position;
        targetDir.y = 0.0f;
        _controlTarget.forward = targetDir;
        _bodyRotaion = _controlTarget.localRotation;
        _targetTwoBefore = _targetBefore;
        _targetBefore = targetPos;
    }
    private void AttackEnd()
    {
    }
    public void SetBodyRotaion(Quaternion angle)
    {
        angle.x = 0;
        angle.z = 0;
        _bodyRotaion = angle;
    }
}
