using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private const int RAY_COUNT = 3;
    [SerializeField]
    Rigidbody _rb = default;
    [SerializeField]
    private float _lifeTime = 2;
    [SerializeField]
    private EffectController _effect = default;
    [SerializeField]
    private bool _rayCheck = true;
    private int _power = 1;
    private Vector3 _beforePos = default;
    private int _count = 0;
    private float _timer = 0;
    private bool _isShot = default;
    private void Update()
    {
        if (!_isShot) { return; }
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _isShot = false;
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (_rayCheck)
        {
            HitCheck();
        }
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.TryGetComponent(out IDamageApplicable target))
        {
            target.AddlyDamage(_power);
        }
        HitAction(transform.position);
    }
    private void HitCheck()
    {
        if (!_isShot) { return; }
        if (_count < RAY_COUNT)
        {
            _count++;
            return;
        }
        if (Physics.Raycast(_beforePos, transform.forward, out RaycastHit hit, Vector3.Distance(_beforePos, transform.position)))
        {
            if (hit.collider.TryGetComponent(out IDamageApplicable target))
            {
                target.AddlyDamage(_power);
            }
            HitAction(hit.point);
            _isShot = false;
            gameObject.SetActive(false);
        }
        _beforePos = transform.position;
        _count = 0;
    }
    private void HitAction(Vector3 hit)
    {
        if (ObjectPoolManager.Instance.Use(_effect.gameObject).TryGetComponent(out EffectController effect))
        {
            effect.transform.position = hit;
            effect.transform.forward = transform.forward;
            effect.PlayEffect();
        }
        _isShot = false;
        gameObject.SetActive(false);
    }
    public void Shot(int power, float speed)
    {
        _isShot = true;
        _timer = _lifeTime;
        _beforePos = transform.position;
        _count = 0;
        _power = power;
        _rb.velocity = transform.forward * speed;
    }
}
