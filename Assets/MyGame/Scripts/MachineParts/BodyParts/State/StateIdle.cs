using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public partial class BodyController
{
    private class StateIdle : IBodyState
    {
        public void OnEnter(BodyController control)
        {
        }

        public void OnFixedUpdate(BodyController control)
        {
        }

        public void OnUpdate(BodyController control)
        {
            control.PartsMotion();
        }
    }
}
