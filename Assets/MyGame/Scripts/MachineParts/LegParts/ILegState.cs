using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController
{
    /// <summary>
    /// 脚部パーツのステート
    /// </summary>
    public interface ILegState
    {
        /// <summary>
        /// ステート開始時
        /// </summary>
        /// <param name="control"></param>
        void OnEnter(LegController control);
        /// <summary>
        /// ステートUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(LegController control);
        /// <summary>
        /// ステート移動関係Update
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(LegController control);
    }
}
/// <summary>
/// 脚部状態名称
/// </summary>
public enum LegStateType
{
    Idle,
    Fall,
    Walk,
    WalkBack,
    Ran,
    Jump,
    JumpLeft,
    JumpRight,
    Float,
    Landing,
    LandingEnd,
    TurnLeft,
    TurnRight,
    Boost,
    BoostBack,
    BoostLeft,
    BoostRight,
    AttackLeft,
    AttackRight,
}