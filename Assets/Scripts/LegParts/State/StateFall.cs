using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateFall : ILegState
    {
        public void OnEnter(LegController control)
        {
            control._legAnimetor.ChangeAnimation(LegStateType.Fall);
        }

        public void OnFixedUpdate(LegController control)
        {
            control._moveController.FlyDelay();
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