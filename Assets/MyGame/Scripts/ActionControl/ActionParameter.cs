using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �p�����[�^�����N���X
/// </summary>
public class ActionParameter: MonoBehaviour
{
    [Tooltip("�s�����x")]
    [SerializeField]
    private float _actionSpeed = 0.8f;
    [Tooltip("���s�ړ���")]
    [SerializeField]
    private float _walkPower = 1.1f;
    [Tooltip("���s�ō����x")]
    [SerializeField]
    private float _maxWalkSpeed = 12f;
    [Tooltip("���s�ړ���")]
    [SerializeField]
    private float _runPower = 1.5f;
    [Tooltip("���s�ō����x")]
    [SerializeField]
    private float _maxRunSpeed = 35f;
    [Tooltip("�����")]
    [SerializeField]
    private float _turnPower = 5f;
    [Tooltip("���񑬓x")]
    [SerializeField]
    private float _turnSpeed = 3f;
    [Tooltip("�W�����v��")]
    [SerializeField]
    private float _jumpPower = 8f;
    [Tooltip("���n�d��")]
    [SerializeField]
    private float _landingTime = 0.5f;
    [Tooltip("���̐��񑬓x")]
    [SerializeField]
    private float _bodyTurnSpeed = 4f;
    [Tooltip("���̐�����E")]
    [SerializeField]
    private float _bodyTurnRange = 0.4f;
    [Tooltip("�J����������E")]
    [SerializeField]
    private float _cameraTurnRange = 50f;
    [Tooltip("���b�N�I���͈�")]
    [SerializeField]
    private float _lockOnRange = 100f;
    [Tooltip("�W�F�b�g��")]
    [SerializeField]
    private float _jetPower = 3f;
    [Tooltip("�W�F�b�g�����")]
    [SerializeField]
    private float _jetControlPower = 0.8f;
    [Tooltip("�W�F�b�g�ړ���")]
    [SerializeField]
    private float _jetMovePower = 0.8f;
    [Tooltip("�W�F�b�g��������")]
    [SerializeField]
    private float _jetTime = 30f;
    [Tooltip("�W�F�b�g�ړ����x")]
    [SerializeField]
    private float _jetSpeed = 40f;
    [Tooltip("�W�F�b�g�ړ��������")]
    [SerializeField]
    private float _needPowerJet = 1f;
    [Tooltip("�z�o�[�ړ���")]
    [SerializeField]
    private float _floatSpeed = 30f;
    [Tooltip("�z�o�[�ō����x")]
    [SerializeField]
    private float _maxFloatSpeed = 500f;
    [Tooltip("��s���K�v�p���[")]
    [SerializeField]
    private float _needPowerFly = 1f;
    [Tooltip("�؋󒆏���x")]
    [SerializeField]
    private float _flyConsumption = 0.1f;
    [Tooltip("�G�l���M�[�񕜑��x")]
    [SerializeField]
    private float _powerRecoverySpeed = 5f;
    /// <summary> �s�����x </summary>
    public float ActionSpeed { get => _actionSpeed; }
    /// <summary> ���s�ړ��� </summary>
    public float WalkPower { get => _walkPower; }
    /// <summary> �ō����s���x </summary>
    public float MaxWalkSpeed { get => _maxWalkSpeed; }
    /// <summary> ���s�ړ��� </summary>
    public float RunPower { get => _runPower; }
    /// <summary> �ō����s���x </summary>
    public float MaxRunSpeed { get => _maxRunSpeed; }
    /// <summary> ����� </summary>
    public float TurnPower { get => _turnPower; }
    /// <summary> ���񑬓x </summary>
    public float TurnSpeed { get => _turnSpeed; }
    /// <summary> �W�����v�� </summary>
    public float JumpPower { get => _jumpPower; }
    /// <summary> ���n�d������ </summary>
    public float LandingTime { get => _landingTime; }
    /// <summary> ���̐��񑬓x </summary>
    public float BodyTurnSpeed { get => _bodyTurnSpeed; }
    /// <summary> ���̐���͈� </summary>
    public float BodyTurnRange { get => _bodyTurnRange; }
    /// <summary> �J��������͈� </summary>
    public float CameraTurnRange { get => _cameraTurnRange; }
    /// <summary> ���G�͈� </summary>
    public float LockOnRange { get => _lockOnRange; }
    /// <summary> �W�F�b�g�� </summary>
    public float JetPower { get => _jetPower; }
    /// <summary> �W�F�b�g����� </summary>
    public float JetControlPower { get => _jetControlPower; }
    /// <summary> �W�F�b�g�ړ��� </summary>
    public float JetMovePower { get => _jetMovePower; }
    /// <summary> �W�F�b�g�������� </summary>
    public float JetTime { get => _jetTime; }
    /// <summary> �W�F�b�g�ړ����x </summary>
    public float JetImpulsePower { get => _jetSpeed; }
    /// <summary> �W�F�b�g�ړ������ </summary>
    public float NeedPowerJet { get => _needPowerJet; }
    /// <summary> �z�o�[���x </summary>
    public float FloatSpeed { get => _floatSpeed; }
    /// <summary> �ō��z�o�[���x </summary>
    public float MaxFloatSpeed { get => _maxFloatSpeed; }
    /// <summary> ��s������� </summary>
    public float NeedPowerFly { get => _needPowerFly; }
    /// <summary> �؋󒆏���x </summary>
    public float FlyConsumption { get => _flyConsumption; }
    /// <summary> �G�l���M�[�񕜑��x </summary>
    public float PowerRecoverySpeed { get => _powerRecoverySpeed; }
}
