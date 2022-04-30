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
    BodyController _bodyControl = default;
    [SerializeField]
    Transform _front = default;
    Vector3 _inputAxis = Vector3.zero;
    private float _angleY = 0.6f;
    public Vector3 InputAxis { get => _inputAxis; }
    public Transform LookTarget { get; protected set; }
    public ActionParameter Parameter { get => _parameter; }
    private float _angle = default;
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
    public void InputLook(Quaternion angle)
    {
        if (_legControl.Current == LegStateType.Float) //ホバー状態なら旋回行動を行う
        {
            _legControl.Turn(angle.y);
            return;
        }
        _inputAxis = Vector3.zero;
        _bodyControl.SetBodyRotaion(angle);
        if (Mathf.Abs(angle.y) > _angleY) //胴体旋回限界で旋回行動を行う
        {
            if (_angle > Mathf.Abs(angle.y))
            {
                return;
            }
            _angle = Mathf.Abs(angle.y);
            _inputAxis.x = angle.y;
        }
        _legControl.Move(_inputAxis);
    }
}
