using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessStageController : MonoBehaviour
{
    [SerializeField]
    private float _scrollSpeed = 1f;
    [SerializeField]
    private int _createBlockCount = 30;
    [SerializeField]
    private int _cameraRange = 10;
    [SerializeField]
    private int _playerRange = 15;
    [SerializeField]
    private float _upRange = 1f;
    [SerializeField]
    private Vector3 _upDir = Vector3.up;
    [SerializeField]
    private Transform _lockTarget = default;
    [SerializeField]
    private Transform _lockTargetUp = default;
    [SerializeField]
    private Transform _playerTarget = default;
    [SerializeField]
    private Transform _playerTargetUp = default;
    [SerializeField]
    private StageBlock _blockPrefab = null;
    private StageBlock[] _stage = null;
    private float _stageRange = default;
    [SerializeField]
    private Vector3 _scrollDir = -Vector3.forward;
    [SerializeField]
    private Vector3 _moveDir = Vector3.forward;
    private float _scrollRange = default;
    private int _scrollCount = 0;
    private int _stageScrollCount = 0;
    private void Start()
    {
        _stage = new StageBlock[_createBlockCount];
        _stageRange = _blockPrefab.Range;
        _stage[0] = Instantiate(_blockPrefab, transform);
        _stage[0].transform.position = transform.position;
        for (int i = 1; i < _createBlockCount; i++)
        {
            _stage[i] = Instantiate(_blockPrefab, transform);
            _stage[i].transform.position = _stage[i - 1].EndPos;
            _stage[i].transform.forward = _stage[i - 1].Dir;
        }
    }
    private void FixedUpdate()
    {
        StageScroll();
    }
    private void StageScroll()
    {
        var scrollRange = _scrollSpeed * Time.fixedDeltaTime;
        foreach (var block in _stage)
        {
            block.transform.position += _scrollDir * scrollRange;
        }
        _scrollRange += scrollRange;
        if (_scrollRange >= _stageRange)
        {
            var endCount = _scrollCount > 0 ? _scrollCount - 1 : _createBlockCount - 1;
            _stage[_scrollCount].transform.position = _stage[endCount].EndPos;
            _stage[_scrollCount].BlockBody.up = _upDir;
            _stage[_scrollCount].transform.forward = _moveDir;
            _stageScrollCount++;
            _scrollCount++;
            if (_scrollCount >= _createBlockCount)
            {
                _scrollCount = 0;
            }
            var lockCount = _scrollCount + _cameraRange >= _createBlockCount ? _scrollCount + _cameraRange - _createBlockCount : _scrollCount + _cameraRange;
            _lockTarget.transform.position = _stage[lockCount].transform.position;
            _lockTargetUp.up = _stage[lockCount].BlockBody.up;
            _lockTarget.forward = _stage[lockCount].transform.forward;
            var playerCount = _scrollCount + _playerRange >= _createBlockCount ? _scrollCount + _playerRange - _createBlockCount : _scrollCount + _playerRange;
            _playerTarget.transform.position = _stage[playerCount].transform.position + _stage[playerCount].GroundDir * _upRange;
            _playerTargetUp.up = _stage[playerCount].BlockBody.up;
            _playerTarget.forward = _stage[playerCount].transform.forward;
            _scrollRange -= _stageRange;
            _scrollDir = -_stage[_scrollCount].transform.forward;
        }
    }
}
