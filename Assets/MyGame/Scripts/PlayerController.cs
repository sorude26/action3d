using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CameraController _camera = default;
    [SerializeField]
    private MachineController _controller = default;
    void Start()
    {
        GameScene.InputManager.Instance.OnInputAxisRaw += _controller.InputMove;
        GameScene.InputManager.Instance.OnFirstInputJump += _controller.InputJump;
        GameScene.InputManager.Instance.OnInputJump += _controller.InputBoost;
        GameScene.InputManager.Instance.OnInputAxisRawExit += _controller.MoveEnd;
        GameScene.InputManager.Instance.OnFirstInputChangeMode += _controller.InputChangeMode;
        GameScene.InputManager.Instance.OnFirstInputBooster += _controller.InputJetBoost;
        GameScene.InputManager.Instance.OnInputCameraRaw += CameraCon;
        GameScene.InputManager.Instance.OnInputCameraRawExit += CameraExit;
    }
    private void CameraCon(Vector2 dir)
    {
        _camera.FreeLock(dir);
        _controller.InputLook(_camera.CameraRot);
    }
    private void CameraExit()
    {
        _camera.ResetLock();
        _controller.InputLook(_camera.CameraRot);
    }
}
