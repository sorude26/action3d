using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateFloat : ILegState
    {
        public void OnEnter(LegController control)
        {
            control._legAnimetor.SetAnimationFloat(true);
            control._isFloat = true;
        }

        public void OnFixedUpdate(LegController control)
        {
            Vector3 dir = control._legAnimetor.transform.forward * control._moveVector.z + control._legAnimetor.transform.right * control._moveVector.x;
            control._moveController.MoveFloat(dir);
            control._moveController.FloatDelay();
        }

        public void OnUpdate(LegController control)
        {
            control._moveController.RotationUpdate();
            if (!control._isFloat)
            {
                control._legAnimetor.SetAnimationFloat(false);
                control.ChangeState(LegStateType.Idle);
            }
        }
    }
}