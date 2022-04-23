using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateBoost : ILegState
    {
        public void OnEnter(LegController control)
        {
            if (control._moveVector.z < 0)
            {
                control.ChangeAnimation(LegStateType.BoostBack);
            }
            else if (control._moveVector.x < 0)
            {
                control.ChangeAnimation(LegStateType.BoostLeft);
            }
            else if(control._moveVector.x > 0)
            {
                control.ChangeAnimation(LegStateType.BoostRight);
            }
            else
            {
                control.ChangeAnimation(LegStateType.Boost);
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