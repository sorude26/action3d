using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateWalk : ILegState
    {
        private const float TURN_DELAY = 0.2f;
        private float runTime = 1f;
        public void OnEnter(LegController control)
        {
            ChangeDir(control);
            control._stateTimer = runTime;
            control._isStateOn = false;
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
            if (control._stateTimer > 0 && control._isStateOn)
            {
                control._stateTimer -= Time.deltaTime;
                if (control._stateTimer <= 0)
                {
                    control._legAnimetor.ChangeAnimation(LegStateType.Ran);
                }
            }
            if (control._currentDir != control._moveVector)
            {
                ChangeDir(control);
            }
        }
        private void ChangeDir(LegController control)
        {
            control._isStateOn = false;
            control._currentDir = control._moveVector;
            if (control._currentDir.z > 0)
            {
                control._currentDir.x *= TURN_DELAY;
                if (control._stateTimer > 0)
                {
                    control._stateTimer = runTime;
                    control._isStateOn = true;
                    control._legAnimetor.ChangeAnimation(LegStateType.Walk);
                }
                return;
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
            control._stateTimer = runTime;
        }
    }
}
