using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    protected Transform _followTarget = default;
    [SerializeField]
    protected Transform _rotationTarget = default;
    [SerializeField]
    protected float _followSpeed = 1f;
    [SerializeField]
    protected float _rotationSpeed = 1f;
    private void FixedUpdate()
    {
        RotationControl();
        MoveControl();
    }
    protected virtual void RotationControl()
    {
        transform.forward = Vector3.Lerp(transform.forward, _rotationTarget.forward, _rotationSpeed * Time.fixedDeltaTime);
    }
    protected virtual void MoveControl()
    {
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, _followSpeed * Time.fixedDeltaTime);
    }
}
