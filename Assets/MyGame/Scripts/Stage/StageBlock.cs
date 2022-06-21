using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlock : MonoBehaviour
{
    public Transform BlockBody = default;
    [SerializeField]
    private float _range = 1f;
    [SerializeField]
    private float _wide = 10f;
    public float Range { get => _range; }
    public Vector3 Dir { get => transform.forward; }
    public Vector3 GroundDir { get => BlockBody.up; }
    public Vector3 EndPos { get => transform.position + transform.forward * _range; }
}
