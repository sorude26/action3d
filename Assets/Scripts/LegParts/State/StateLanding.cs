using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class LegController
{
    public class StateLanding : ILegState
    {
        public void OnEnter(LegController control)
        {
            control.ChangeAnimation(LegStateType.Landing);
            control._stateTimer = control._parameter.LandingTime;
            control._isStateOn = true;
        }

        public void OnFixedUpdate(LegController control)
        {
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Fall);
            }
        }

        public void OnUpdate(LegController control)
        {
            if (!control._isStateOn)
            {
                return;
            }
            control._stateTimer -= Time.deltaTime;
            if (control._stateTimer <= 0)
            {
                control.ChangeAnimation(LegStateType.LandingEnd);
                control._isStateOn = false;
            }
        }
    }
}