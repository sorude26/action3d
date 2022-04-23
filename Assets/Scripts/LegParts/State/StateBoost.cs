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
                control.ChangeAnimation(StateType.BoostBack);
            }
            else if (control._moveVector.x < 0)
            {
                control.ChangeAnimation(StateType.BoostLeft);
            }
            else if(control._moveVector.x > 0)
            {
                control.ChangeAnimation(StateType.BoostRight);
            }
            else
            {
                control.ChangeAnimation(StateType.BoostFlont);
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