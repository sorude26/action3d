using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class LegController
{
    public class StateIdle : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (control._isFloat)
            {
                control.ChangeState(LegStateType.Float);
                return;
            }
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Fall);
                return;
            }
            if (control._moveVector == Vector3.zero)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.Idle);
            }
            else
            {
                control.ChangeState(LegStateType.Walk);
            }
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
            control._moveController.RotationUpdate();
        }
    }
}