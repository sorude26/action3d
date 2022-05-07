using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rb = default;
    private int _power = 1;
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out IDamageApplicable target);
        if (target != null)
        {
            target.AddlyDamage(_power);
        }
        Hit();
    }
    private void Hit()
    {
        gameObject.SetActive(false);
    }
    public void Shot(int power,float speed)
    {
        _power = power;
        _rb.AddForce(transform.forward * speed,ForceMode.Impulse);
    }
}
