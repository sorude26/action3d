using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateWalk : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (control._moveVector.z > 0)
            {
                control.ChangeAnimation(StateType.Walk);
            }
            else
            {
                control.ChangeAnimation(StateType.WalkBack);
            }
        }

        public void OnFixedUpdate(LegController control)
        {
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(StateType.Fall);
            }
        }

        public void OnUpdate(LegController control)
        {
        }
    }
}
