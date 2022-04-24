using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateWalk : ILegState
    {
        private Vector3Int _currentDir = default;
        public void OnEnter(LegController control)
        {
            ChangeDir(control);
        }

        public void OnFixedUpdate(LegController control)
        {
            control._moveController.UpdateController();
            if (!control._groundChecker.IsWalled())
            {
                control.ChangeState(LegStateType.Fall);
            }
        }

        public void OnUpdate(LegController control)
        {
            if (_currentDir != control._moveVector)
            {
                ChangeDir(control);
            }
        }
        private void ChangeDir(LegController control)
        {
            _currentDir = control._moveVector;
            if (_currentDir.z > 0)
            {
                control.ChangeAnimation(LegStateType.Walk);
            }
            else if (_currentDir.z < 0)
            {
                control.ChangeAnimation(LegStateType.WalkBack);
            }
            else if (_currentDir.x < 0)
            {
                control.ChangeAnimation(LegStateType.TurnLeft);
            }
            else if (_currentDir.x > 0)
            {
                control.ChangeAnimation(LegStateType.TurnRight);
            }
            else
            {
                control.ChangeState(LegStateType.Idle);
            }
        }
    }
}
