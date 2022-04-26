using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LegController
{
    /// <summary>
    /// �r���p�[�c�̃X�e�[�g
    /// </summary>
    public interface ILegState
    {
        /// <summary>
        /// �X�e�[�g�J�n��
        /// </summary>
        /// <param name="control"></param>
        void OnEnter(LegController control);
        /// <summary>
        /// �X�e�[�gUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(LegController control);
        /// <summary>
        /// �X�e�[�g�ړ��֌WUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(LegController control);
    }
}
/// <summary>
/// �r����Ԗ���
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