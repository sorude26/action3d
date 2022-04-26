using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateBoost : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (control._moveVector == Vector3.zero)
            {
                control.ChangeState(LegStateType.Idle);
                return;
            }
            control._jetVector = control._moveVector;
            if (control._moveVector.z < 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.BoostBack);
            }
            else if (control._moveVector.x < 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.BoostLeft);
            }
            else if(control._moveVector.x > 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.BoostRight);
            }
            else
            {
                control._legAnimetor.ChangeAnimation(LegStateType.Boost);
            }
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