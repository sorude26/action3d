using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    protected float _shotSpeed = 100f;
    [SerializeField]
    protected Transform _muzzle = default;
    public float ShotSpeed { get => _shotSpeed; }
    public void Fire()
    {

    }
}
