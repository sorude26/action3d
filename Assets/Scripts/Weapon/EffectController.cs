using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particle = default;
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
    }
}
