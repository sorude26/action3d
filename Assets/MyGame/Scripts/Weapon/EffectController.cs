using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particle = default;
    [SerializeField]
    private VisualEffect _vfxEffect = default;
    [SerializeField]
    private float _lifeTime = 1f;
    private float _timer = 0f;
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnDisable()
    {
        if (_particle != null)
        {
            _particle.Stop();
        }
    }
    public void PlayEffect()
    {
        if (_particle != null)
        {
            _particle.Play();
        }
        if (_vfxEffect)
        {
            _vfxEffect.Play();
        }
        _timer = _lifeTime;
    }
}
