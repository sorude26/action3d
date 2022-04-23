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
        void OnEnter(LegControl control);
        /// <summary>
        /// �X�e�[�gUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(LegControl control);
        /// <summary>
        /// �X�e�[�g�ړ��֌WUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(LegControl control);
    }
}