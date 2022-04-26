using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ˌ��֌W�̌v�Z���s��
/// </summary>
public class ShootingCalculation
{
    private const int PREDICTION_FLAME_COUNT = 3;
    /// <summary>
    /// ���`�\���ɂ��\���ڕW���W��Ԃ�
    /// </summary>
    /// <param name="startPos">�J�n�_</param>
    /// <param name="targetPos">�ڕW�_</param>
    /// <param name="beforePos">�P�t���[���O�̍��W</param>
    /// <param name="shotSpeed">�e��</param>
    /// <returns></returns>
    public static Vector3 LinearPrediction(Vector3 startPos, Vector3 targetPos, Vector3 beforePos, float shotSpeed)
    {
        //���݂̑��x
        Vector3 currentMoveSpeed = targetPos - beforePos;
        //�ڕW�Ƃ̋���
        float targetDistance = Vector3.Distance(startPos, targetPos);
        return targetPos + currentMoveSpeed * targetDistance / (shotSpeed / Time.fixedDeltaTime);
    }
    /// <summary>
    /// �~�`�\���ɂ��\���ڕW���W��Ԃ�
    /// </summary>
    /// <param name="attackerPos"></param>
    /// <param name="targetPos"></param>
    /// <param name="beforePos"></param>
    /// <param name="twoBeforePos"></param>
    /// <param name="shotSpeed"></param>
    /// <returns></returns>
    public static Vector3 CirclePrediction(Vector3 attackerPos, Vector3 targetPos, Vector3 beforePos, Vector3 twoBeforePos, float shotSpeed)
    {
        //3�_����~�`�̒��S�_�����߂�
        Vector3 CenterPosition = Circumcenter(targetPos, beforePos, twoBeforePos);

        Vector3 axis = Vector3.Cross(beforePos - CenterPosition, targetPos - CenterPosition);
        float angle = Vector3.Angle(beforePos - CenterPosition, targetPos - CenterPosition);

        float predictionFlame = Vector3.Distance(targetPos, attackerPos) / shotSpeed;
        for (int i = 0; i < PREDICTION_FLAME_COUNT; ++i)
        {
            predictionFlame = Vector3.Distance(RotateToPos(targetPos, CenterPosition, axis, angle * predictionFlame), attackerPos) / shotSpeed;
        }

        return RotateToPos(targetPos, CenterPosition, axis, angle * predictionFlame);
    }

    /// <summary>
    /// �O�p�`�̒��_�O�_�̈ʒu����O�S�̈ʒu��Ԃ�
    /// </summary>
    /// <param name="posA"></param>
    /// <param name="posB"></param>
    /// <param name="posC"></param>
    /// <returns></returns>
    public static Vector3 Circumcenter(Vector3 posA, Vector3 posB, Vector3 posC)
    {
        //�O�ӂ̒����̓����o��
        float edgeA = Vector3.SqrMagnitude(posB - posC);
        float edgeB = Vector3.SqrMagnitude(posC - posA);
        float edgeC = Vector3.SqrMagnitude(posA - posB);

        //�d�S���W�n�Ōv�Z����
        float a = edgeA * (-edgeA + edgeB + edgeC);
        float b = edgeB * (edgeA - edgeB + edgeC);
        float c = edgeC * (edgeA + edgeB - edgeC);

        float abc = a + b + c;
        if (abc == 0)//0�����h��
        {
            abc = 3;
        }
        return (posA * a + posB * b + posC * c) / abc;
    }
    /// <summary>
    /// �ڕW�ʒu���Z���^�[�ʒu�Ŏ��Ɗp�x�ŉ�]�������ʒu��Ԃ�
    /// </summary>
    /// <param name="target"></param>
    /// <param name="center"></param>
    /// <param name="axis"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static Vector3 RotateToPos(Vector3 target, Vector3 center, Vector3 axis, float angle)
    {
        return Quaternion.AngleAxis(angle, axis) * (target - center) + center;
    }
}
