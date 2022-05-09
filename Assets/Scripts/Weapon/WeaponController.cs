using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    protected float _shotSpeed = 100f;
    [SerializeField]
    protected Transform _muzzle = default;
    [SerializeField]
    protected int _shotPower = 1;
    [SerializeField]
    private BulletController _bullet = default;
    [SerializeField]
    private float _swingWidth = 0.1f;
    [SerializeField]
    private float _shotInterval = 0.1f;
    [SerializeField]
    private int _maxShotCount = 1;
    [SerializeField]
    private int _diffusion = 0;
    private float _timer = 0;
    private int _shotCount = 0;
    private bool _isShoting = default;
    public float ShotSpeed { get => _shotSpeed; }
    private void Start()
    {
        GameScene.InputManager.Instance.OnFirstInputShot1 += Fire;
    }
    /// <summary>
    /// UŒ‚‚ÌƒuƒŒ‚ğ•Ô‚·
    /// </summary>
    /// <returns></returns>
    private Vector3 SwingVector()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(0, _swingWidth);
        Vector3 swingVector = _muzzle.up * y + _muzzle.right * x;
        return swingVector.normalized * z;
    }
    private void Shot()
    {
        if (ObjectPoolManager.Instance.Use(_bullet.gameObject).TryGetComponent<BulletController>(out var shot))
        {
            shot.transform.position = _muzzle.position;
            shot.transform.forward = _muzzle.forward + SwingVector();
            shot.Shot(_shotPower, _shotSpeed);
        }
    }
    private IEnumerator Shoting()
    {
        while (_shotCount > 0 || _timer < 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0 && _shotCount > 0)
            {
                _timer = _shotInterval;
                _shotCount--;
                for (int i = 0; i < _diffusion; i++)
                {
                    Shot();
                }
                Shot();
            }
            yield return null;
        }
        _isShoting = false;
    }
    public void Fire()
    {
        _shotCount = _maxShotCount;
        if (!_isShoting)
        {
            _isShoting = true;
            StartCoroutine(Shoting());
        }
    }
}
