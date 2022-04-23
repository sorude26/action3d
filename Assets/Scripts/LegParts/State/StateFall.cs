using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateFall : ILegState
    {
        public void OnEnter(LegController control)
        {
        }

        public void OnFixedUpdate(LegController control)
        {
            if (control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Landing);
            }
        }

        public void OnUpdate(LegController control)
        {
        }
    }
}