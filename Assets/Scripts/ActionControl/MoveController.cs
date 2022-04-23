using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動関係を扱う
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class MoveController : MonoBehaviour
{
    private const float BRAKE_DECELERATE = 0.3f;
    private const float FLOAT_DELAY = 0.999f;
    private const float GROUND_DELAY = 0.991f;
    private ActionParameter _parameter = default;
    private Rigidbody _rb = default;
    private Quaternion _baseRotation = default;

    public Transform BaseTransform = null;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// 旋回Update
    /// </summary>
    private void RotationUpdate()
    {
        BaseTransform.localRotation = Quaternion.Lerp(BaseTransform.localRotation, _baseRotation, _parameter.TurnSpeed * Time.deltaTime);
    }
    /// <summary>
    /// ホバー中移動速度減衰
    /// </summary>
    private void FloatDelay()
    {
        Vector3 current = Vector3.zero;
        current.x = _rb.velocity.x;
        current.z = _rb.velocity.z;
        _rb.velocity = current * FLOAT_DELAY;
    }
    /// <summary>
    /// 地上移動速度減衰
    /// </summary>
    private void GroundDelay()
    {
        Vector3 current = _rb.velocity;
        float currentY = current.y;
        current *= GROUND_DELAY;
        current.y = currentY;
        _rb.velocity = current;
    }
    private void ShortMove(Vector3 dir, float power, float maxSpeed)
    {
        if (_rb.velocity.sqrMagnitude < maxSpeed)
        {
            _rb.AddForce(dir * power, ForceMode.Impulse);
        }
    }
    private void VelocityMove(Vector3 dir, float speed, float maxSpeed)
    {
        if (_rb.velocity.sqrMagnitude < maxSpeed)
        {
            _rb.velocity = dir * speed;
        }
    }
    public void UpdateController()
    {
        GroundDelay();
        RotationUpdate();
    }
    public void UpdateControllerFloat()
    {
        FloatDelay();
        RotationUpdate();
    }
    public void MoveBrake()
    {
        var v = _rb.velocity;
        _rb.velocity = v * BRAKE_DECELERATE;
    }
    public void MoveJump(Vector3 dir)
    {
        _rb.AddForce(dir * _parameter.JumpPower, ForceMode.Impulse);
    }
    public void MoveJet(Vector3 dir)
    {
        _rb.AddForce(dir * _parameter.JetMovePower);
    }
    public void MoveWalk(Vector3 dir)
    {
        MoveBrake();
        ShortMove(dir, _parameter.WalkPower, _parameter.MaxWalkSpeed * _parameter.ActionSpeed);
    }
    public void MoveRun(Vector3 dir)
    {
        ShortMove(dir, _parameter.RunPower, _parameter.MaxRunSpeed * _parameter.ActionSpeed);
    }
    public void MoveFloat(Vector3 dir)
    {
        VelocityMove(dir, _parameter.FloatSpeed, _parameter.MaxFloatSpeed);
    }
    public void Turn(float angle)
    {
        _baseRotation = Quaternion.Euler(Vector3.up * angle * _parameter.TurnPower) * _baseRotation;
    }
    public void Turn(Quaternion angle)
    {
        _baseRotation = angle * _baseRotation;
    }
}
