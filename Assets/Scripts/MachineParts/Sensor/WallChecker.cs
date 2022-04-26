using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ǔ�����s��
/// </summary>
public class WallChecker : MonoBehaviour
{
    [SerializeField]
    private Transform[] _checkPosLeft = default;
    [SerializeField]
    private Transform[] _checkPosRight = default;
    [SerializeField]
    private Vector3 _checkDirLeft = Vector3.down;
    [SerializeField]
    private Vector3 _checkDirRight = Vector3.down;
    [SerializeField]
    private float _checkRange = 0.2f;
    [SerializeField]
    private int _minConunt = 1;
    [SerializeField]
    private LayerMask _layer = default;
    /// <summary>
    /// �ǔ��茋�ʂ�Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool IsWalled()
    {
        int leftCount = default;
        int rightCount = default;
        foreach (var pos in _checkPosLeft)
        {
            Vector3 start = pos.position;
            Vector3 end = start + _checkDirLeft * _checkRange;
            bool left = Physics.Linecast(start, end, _layer);
            if (left)
            {
                leftCount++;
                if (leftCount > _minConunt)//�ŏ����萔�ȏ�Ȃ��
                {
                    return true;
                }
            }
        }
        foreach (var pos in _checkPosRight)
        {
            Vector3 start = pos.position;
            Vector3 end = start + _checkDirRight * _checkRange;
            bool right = Physics.Linecast(start, end, _layer);
            if (right)
            {
                rightCount++;
                if (rightCount > _minConunt)//�ŏ����萔�ȏ�Ȃ��
                {
                    return true;
                }
            }
        }
        if (leftCount > 0 && rightCount > 0)//�����̔����_��1�ȏ�Ȃ��
        {
            return true;
        }
        return false;
    }
}
