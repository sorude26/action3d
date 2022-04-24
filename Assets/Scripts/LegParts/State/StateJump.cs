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
            control._jumpVector = control._moveVector;
            if (control._jumpVector.z == 0)
            {
                if (control._jumpVector.x < 0)
                {
                    control.ChangeAnimation(LegStateType.JumpLeft);
                }
                else if (control._jumpVector.x > 0)
                {
                    control.ChangeAnimation(LegStateType.JumpRight);
                }
                else
                {
                    control.ChangeAnimation(LegStateType.Jump);
                }
            }
            else
            {
                control._jumpVector.x *= JUMP_DELAY;
                control.ChangeAnimation(LegStateType.Jump);
            }
        }

        public void OnFixedUpdate(LegController control)
        {
        }

        public void OnUpdate(LegController control)
        {
        }
    }
}