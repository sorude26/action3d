using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BodyController
{
    /// <summary>
    /// ���̃p�[�c�̃X�e�[�g
    /// </summary>
    public interface IBodyState
    {
        /// <summary>
        /// �X�e�[�g�J�n��
        /// </summary>
        /// <param name="control"></param>
        void OnEnter(BodyController control);
        /// <summary>
        /// �X�e�[�gUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnUpdate(BodyController control);
        /// <summary>
        /// �X�e�[�g�ړ��֌WUpdate
        /// </summary>
        /// <param name="control"></param>
        void OnFixedUpdate(BodyController control);
    }
}