using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BodyController : MonoBehaviour
{
    [Tooltip("ÉJÉÅÉâÇÃñ⁄ïW")]
    [SerializeField]
    public Transform _bodyRotaionTarget = default;
    [SerializeField]
    private Transform[] _bodyControlBase = new Transform[2];
    [SerializeField]
    private Transform[] _controlTarget = new Transform[3];
    [SerializeField]
    private HandController _leftArm = default;
    [SerializeField]
    private HandController _rightArm = default;

    private IBodyState _currentState = default;
    private StateIdle _sIdle = new StateIdle();
    private Quaternion _bodyRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _headRotaion = Quaternion.Euler(0, 0, 0);

    public float BodyRSpeed { get; set; } = 3.0f;
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
        //ì™ïîëÄçÏ
        _bodyControlBase[1].localRotation = Quaternion.Lerp(_bodyControlBase[1].localRotation, _headRotaion, BodyRSpeed * Time.deltaTime);
        //ì∑ëÃëÄçÏ
        _bodyControlBase[0].localRotation = Quaternion.Lerp(_bodyControlBase[0].localRotation, _bodyRotaion, BodyRSpeed * Time.deltaTime);
        _bodyRotaionTarget.localRotation = _bodyControlBase[0].localRotation;
        //_leftArm.PartsMotion();
        //_rightArm.PartsMotion();
    }
    void AttackEnd()
    { 
    }
        public void SetBodyRotaion(Quaternion angle)
    {
        angle.x = 0;
        angle.z = 0;
        _bodyRotaion = angle;
    }
}
