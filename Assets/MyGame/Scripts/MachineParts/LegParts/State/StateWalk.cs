using System.Collections;
using System.Collections.Generic;
using UnityEngine;
partial class LegController
{
    public class StateWalk : ILegState
    {
        private const float TURN_DELAY = 0.2f;
        private float _runTime = 5f;
        private bool _runModeCheck = false;
        private bool _isRunning = false;
        public void OnEnter(LegController control)
        {
            if (control._isFloat)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.Float);
                return;
            }
            ChangeDir(control);
            _runModeCheck = false;
            _isRunning = false;
        }

        public void OnFixedUpdate(LegController control)
        {
            control._moveController.GroundDelay();
            if (!control._groundChecker.IsWalled())
            {
                control._moveController.MoveBrake();
                control.ChangeState(LegStateType.Fall);
            }
        }

        public void OnUpdate(LegController control)
        {
            control._moveController.RotationUpdate();
            if (_runModeCheck && !_isRunning)
            {
                control._stateTimer -= Time.deltaTime;
                if (control._stateTimer <= 0)
                {
                    _runModeCheck = false;
                    _isRunning = true;
                    control._legAnimetor.ChangeAnimation(LegStateType.Ran);
                }
            }
            if (control._turnVector != control._moveVector)
            {
                ChangeDir(control);
            }
        }
        /// <summary>
        /// �����ɍ��킹���A�j���[�V�����ɐؑւ���
        /// </summary>
        /// <param name="control"></param>
        private void ChangeDir(LegController control)
        {
            control._turnVector = control._moveVector;
            if (control._turnVector.z > 0)
            {
                control._turnVector.x *= TURN_DELAY;
                if (!_runModeCheck && !_isRunning)
                {
                    _runModeCheck = true;
                    control._stateTimer = _runTime;
                    control._legAnimetor.ChangeAnimation(LegStateType.Walk,true);
                }
                return;
            }
            else if (control._turnVector.z < 0)
            {
                control._turnVector.x *= TURN_DELAY;
                control._legAnimetor.ChangeAnimation(LegStateType.WalkBack,true);
            }
            else if (control._turnVector.x < 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.TurnLeft,true);
            }
            else if (control._turnVector.x > 0)
            {
                control._legAnimetor.ChangeAnimation(LegStateType.TurnRight,true);
            }
            else
            {
                control.ChangeState(LegStateType.Idle);
            }
            _runModeCheck = false;
            _isRunning = false;
        }
    }
}
