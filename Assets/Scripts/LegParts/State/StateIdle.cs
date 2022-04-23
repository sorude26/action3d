using System.Collections;
using System.Collections.Generic;
using UnityEngine;

partial class LegController
{
    public class StateIdle : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Fall);
                return;
            }
            control.ChangeAnimation(LegStateType.Idle);
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
        }
    }
}