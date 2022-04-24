using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateFloat : ILegState
    {
        public void OnEnter(LegController control)
        {
        }

        public void OnFixedUpdate(LegController control)
        {
            control._moveController.UpdateControllerFloat();
        }

        public void OnUpdate(LegController control)
        {
        }
    }
}