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
            control._jumpVector = control._moveVector;
            if (control._jumpVector.z == 0)
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
        }

        public void OnUpdate(LegController control)
        {
        }
    }
}