using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateJump : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (control._moveVector.x < 0)
            {
                control.ChangeAnimation(LegStateType.JumpLeft);
            }
            else if(control._moveVector.x > 0)
            {
                control.ChangeAnimation(LegStateType.JumpRight);
            }
            else
            {
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