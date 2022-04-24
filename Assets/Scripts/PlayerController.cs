using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    MachineController _controller = default;
    void Start()
    {
        GameScene.InputManager.Instance.OnInputAxisRaw += _controller.InputMove;
        GameScene.InputManager.Instance.OnFirstInputJump += _controller.InputJump;
        GameScene.InputManager.Instance.OnInputAxisRawExit += _controller.MoveEnd;
    }
}
