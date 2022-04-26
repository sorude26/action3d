using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    [SerializeField]
    ActionParameter _parameter = default;
    [SerializeField]
    MoveController _moveControl = default;
    [SerializeField]
    LegController _legControl = default;
    [SerializeField]
    Transform _bodyAngle = default;
    [SerializeField]
    Transform _front = default;
    Vector3 _inputAxis = Vector3.zero;

    public Vector3 InputAxis { get => _inputAxis; }
    public Transform LookTarget { get; protected set; }
    public ActionParameter Parameter { get => _parameter; }

    private void Start()
    {
        _moveControl.StartSet(_parameter);
        _legControl.StartSet(_parameter, _moveControl);
    }
    public void InputMove(float x, float z)
    {
        _inputAxis = Vector3.zero;
        _inputAxis.x = x;
        _inputAxis.z = z;
        _legControl.Move(_inputAxis);
    }
    public void InputJump()
    {
        _legControl.Jump();
    }
    public void InputBoost()
    {
        _legControl.Boost();
    }
    public void InputJetBoost()
    {
        _legControl.JetBoost();
    }
    public void MoveEnd()
    {
        _inputAxis = Vector3.zero;
        _legControl.Move(_inputAxis);
    }
    public void InputChangeMode()
    {
        _legControl.ChangeMode();
    }
}
