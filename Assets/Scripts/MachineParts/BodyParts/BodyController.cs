using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BodyController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _bodyControlBase = new Transform[2];
    [SerializeField]
    private Transform[] _rightControlBase = new Transform[4];
    [SerializeField]
    private Transform[] _leftControlBase = new Transform[4];
    [SerializeField]
    private Transform[] _controlTarget = new Transform[3];
    private Quaternion _bodyRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _headRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _lArmRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _lArmRotaion2 = Quaternion.Euler(0, 0, 0);
    private Quaternion _rArmRotaion = Quaternion.Euler(0, 0, 0);
    private Quaternion _rArmRotaion2 = Quaternion.Euler(0, 0, 0);

    public float BodyRSpeed { get; set; } = 3.0f;
    private void PartsMotion()
    {
        //��������
        _bodyControlBase[1].localRotation = Quaternion.Lerp(_bodyControlBase[1].localRotation, _headRotaion, BodyRSpeed * Time.deltaTime);
        //���̑���
        _bodyControlBase[0].localRotation = Quaternion.Lerp(_bodyControlBase[0].localRotation, _bodyRotaion, BodyRSpeed * Time.deltaTime);
        //��������
        _leftControlBase[0].localRotation = Quaternion.Lerp(_leftControlBase[0].localRotation, _lArmRotaion, BodyRSpeed * Time.deltaTime);
        //���r����
        _leftControlBase[2].localRotation = Quaternion.Lerp(_leftControlBase[2].localRotation, _lArmRotaion2, BodyRSpeed * Time.deltaTime);
        //�E������
        _rightControlBase[0].localRotation = Quaternion.Lerp(_rightControlBase[0].localRotation, _rArmRotaion, BodyRSpeed * Time.deltaTime);
        //�E�r����
        _rightControlBase[2].localRotation = Quaternion.Lerp(_rightControlBase[2].localRotation, _rArmRotaion2, BodyRSpeed * Time.deltaTime);
    }
}
