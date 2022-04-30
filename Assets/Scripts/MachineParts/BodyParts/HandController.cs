using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private const float ATTACK_ANGLE = 0.999f;
    private readonly Quaternion HAND_ANGLE = Quaternion.Euler(-90, 0, 0);
    [SerializeField]
    private Transform[] _handBases = new Transform[4];
    [SerializeField]
    private Transform[] _controlTarget = new Transform[3];
    private Quaternion _topRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _handRotaion = Quaternion.Euler(0, 0, 0);

    private Vector3 _targetCurrent = default;
    private Vector3 _targetBefore = default;
    private Vector3 _targetTwoBefore = default;
    public float BodyRSpeed { get; set; } = 3.0f;
    public float WeaponShotSpeed { get; set; } = 120f;
    public void PartsMotion()
    {
        _handBases[0].localRotation = Quaternion.Lerp(_handBases[0].localRotation, _topRotaion, BodyRSpeed * Time.deltaTime);
        _handBases[2].localRotation = Quaternion.Lerp(_handBases[2].localRotation, _handRotaion, BodyRSpeed * Time.deltaTime);
    }
    public void SetLockOn(Vector3 targetPos)
    {
        _targetBefore = targetPos;
        _targetTwoBefore = targetPos;
        LockOn(targetPos);
    }
    private void LockOn(Vector3 targetPos)
    {
        _targetCurrent = ShootingCalculation.CirclePrediction(_handBases[2].position, targetPos, _targetBefore, _targetTwoBefore, WeaponShotSpeed);
        _controlTarget[2].forward = _targetCurrent - _handBases[2].position;
        _handRotaion = _controlTarget[2].localRotation * HAND_ANGLE;
        _targetTwoBefore = _targetBefore;
        _targetBefore = targetPos;
    }
    private bool ChackAngle()
    {
        var angle = Quaternion.Dot(_handRotaion, _handBases[2].localRotation);
        return angle > ATTACK_ANGLE || angle < -ATTACK_ANGLE;
    }
}
