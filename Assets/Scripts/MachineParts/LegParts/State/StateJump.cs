using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateJump : ILegState
    {
        private const float JUMP_DELAY = 0.5f;
        public void OnEnter(LegController control)
        {
            control._moveController.MoveBrake();
            control._isStateOn = false;
            control._jumpVector = control._moveVector;
            if (control._jumpVector.z == 0)//ジャンプアニメーションの切替
            {
                if (control._jumpVector.x < 0)
                {
                    control._legAnimetor.ChangeAnimation(LegStateType.JumpLeft);
                    return;
                }
                else if (control._jumpVector.x > 0)
                {
                    control._legAnimetor.ChangeAnimation(LegStateType.JumpRight);
                    return;
                }
            }
            control._jumpVector.x *= JUMP_DELAY;
            control._legAnimetor.ChangeAnimation(LegStateType.Jump);
        }

        public void OnFixedUpdate(LegController control)
        {
            if (control._isStateOn)
            {
                return;
            }
            if (control._groundChecker.IsWalled())
            {
                control._moveController.GroundDelay();
            }
        }

        public void OnUpdate(LegController control)
        {
            control._moveController.RotationUpdate();
        }
    }
}