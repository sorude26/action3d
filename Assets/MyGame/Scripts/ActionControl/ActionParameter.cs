using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// パラメータ総合クラス
/// </summary>
public class ActionParameter: MonoBehaviour
{
    [Tooltip("行動速度")]
    [SerializeField]
    private float _actionSpeed = 0.8f;
    [Tooltip("歩行移動力")]
    [SerializeField]
    private float _walkPower = 1.1f;
    [Tooltip("歩行最高速度")]
    [SerializeField]
    private float _maxWalkSpeed = 12f;
    [Tooltip("走行移動力")]
    [SerializeField]
    private float _runPower = 1.5f;
    [Tooltip("走行最高速度")]
    [SerializeField]
    private float _maxRunSpeed = 35f;
    [Tooltip("旋回力")]
    [SerializeField]
    private float _turnPower = 5f;
    [Tooltip("旋回速度")]
    [SerializeField]
    private float _turnSpeed = 3f;
    [Tooltip("ジャンプ力")]
    [SerializeField]
    private float _jumpPower = 8f;
    [Tooltip("着地硬直")]
    [SerializeField]
    private float _landingTime = 0.5f;
    [Tooltip("胴体旋回速度")]
    [SerializeField]
    private float _bodyTurnSpeed = 4f;
    [Tooltip("胴体旋回限界")]
    [SerializeField]
    private float _bodyTurnRange = 0.4f;
    [Tooltip("カメラ旋回限界")]
    [SerializeField]
    private float _cameraTurnRange = 50f;
    [Tooltip("ロックオン範囲")]
    [SerializeField]
    private float _lockOnRange = 100f;
    [Tooltip("ジェット力")]
    [SerializeField]
    private float _jetPower = 3f;
    [Tooltip("ジェット制御力")]
    [SerializeField]
    private float _jetControlPower = 0.8f;
    [Tooltip("ジェット移動力")]
    [SerializeField]
    private float _jetMovePower = 0.8f;
    [Tooltip("ジェット持続時間")]
    [SerializeField]
    private float _jetTime = 30f;
    [Tooltip("ジェット移動速度")]
    [SerializeField]
    private float _jetSpeed = 40f;
    [Tooltip("ジェット移動時消費量")]
    [SerializeField]
    private float _needPowerJet = 1f;
    [Tooltip("ホバー移動力")]
    [SerializeField]
    private float _floatSpeed = 30f;
    [Tooltip("ホバー最高速度")]
    [SerializeField]
    private float _maxFloatSpeed = 500f;
    [Tooltip("飛行時必要パワー")]
    [SerializeField]
    private float _needPowerFly = 1f;
    [Tooltip("滞空中消費速度")]
    [SerializeField]
    private float _flyConsumption = 0.1f;
    [Tooltip("エネルギー回復速度")]
    [SerializeField]
    private float _powerRecoverySpeed = 5f;
    /// <summary> 行動速度 </summary>
    public float ActionSpeed { get => _actionSpeed; }
    /// <summary> 歩行移動力 </summary>
    public float WalkPower { get => _walkPower; }
    /// <summary> 最高歩行速度 </summary>
    public float MaxWalkSpeed { get => _maxWalkSpeed; }
    /// <summary> 走行移動力 </summary>
    public float RunPower { get => _runPower; }
    /// <summary> 最高走行速度 </summary>
    public float MaxRunSpeed { get => _maxRunSpeed; }
    /// <summary> 旋回力 </summary>
    public float TurnPower { get => _turnPower; }
    /// <summary> 旋回速度 </summary>
    public float TurnSpeed { get => _turnSpeed; }
    /// <summary> ジャンプ力 </summary>
    public float JumpPower { get => _jumpPower; }
    /// <summary> 着地硬直時間 </summary>
    public float LandingTime { get => _landingTime; }
    /// <summary> 胴体旋回速度 </summary>
    public float BodyTurnSpeed { get => _bodyTurnSpeed; }
    /// <summary> 胴体旋回範囲 </summary>
    public float BodyTurnRange { get => _bodyTurnRange; }
    /// <summary> カメラ旋回範囲 </summary>
    public float CameraTurnRange { get => _cameraTurnRange; }
    /// <summary> 索敵範囲 </summary>
    public float LockOnRange { get => _lockOnRange; }
    /// <summary> ジェット力 </summary>
    public float JetPower { get => _jetPower; }
    /// <summary> ジェット制御力 </summary>
    public float JetControlPower { get => _jetControlPower; }
    /// <summary> ジェット移動力 </summary>
    public float JetMovePower { get => _jetMovePower; }
    /// <summary> ジェット持続時間 </summary>
    public float JetTime { get => _jetTime; }
    /// <summary> ジェット移動速度 </summary>
    public float JetImpulsePower { get => _jetSpeed; }
    /// <summary> ジェット移動消費量 </summary>
    public float NeedPowerJet { get => _needPowerJet; }
    /// <summary> ホバー速度 </summary>
    public float FloatSpeed { get => _floatSpeed; }
    /// <summary> 最高ホバー速度 </summary>
    public float MaxFloatSpeed { get => _maxFloatSpeed; }
    /// <summary> 飛行時消費量 </summary>
    public float NeedPowerFly { get => _needPowerFly; }
    /// <summary> 滞空中消費速度 </summary>
    public float FlyConsumption { get => _flyConsumption; }
    /// <summary> エネルギー回復速度 </summary>
    public float PowerRecoverySpeed { get => _powerRecoverySpeed; }
}
