using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateWalk : ILegState
    {
        private const float TURN_DELAY = 0.2f;
        public void OnEnter(LegController control)
        {
            ChangeDir(control);
        }

        public void OnFixedUpdate(LegController control)
        {
            control._moveController.GroundDelay();
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Fall);
            }
        }

        public void OnUpdate(LegController control)
        {
            if (control._currentDir != control._moveVector)
            {
                ChangeDir(control);
            }
        }
        private void ChangeDir(LegController control)
        {
            control._currentDir = control._moveVector;
            if (control._currentDir.z > 0)
            {
                control._currentDir.x *= TURN_DELAY;
                control._legAnimetor.ChangeAnimation(LegStateType.Walk);
            }
            else if (control._currentDir.z < 0)
            {
                control._currentDir.x *= TURN_DELAY;
                control._legAnimetor.ChangeAnimation(LegStateType.WalkBack);
            }
            else if (control._currentDir.x < 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.TurnLeft);
            }
            else if (control._currentDir.x > 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.TurnRight);
            }
            else
            {
                control.ChangeState(LegStateType.Idle);
            }
        }
    }
}
