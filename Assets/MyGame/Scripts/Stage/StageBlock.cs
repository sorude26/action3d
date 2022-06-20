using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBlock : MonoBehaviour
{
    [SerializeField]
    private Transform _endJoint = default;
    [SerializeField]
    private float _range = 1f;
    [SerializeField]
    private float _wide = 10f;
    public Vector3 GroundDir { get; private set; }
}
