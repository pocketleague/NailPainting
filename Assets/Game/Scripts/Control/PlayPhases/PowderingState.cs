using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PlayPhasesControl))]
    public class PowderingState : State
    {
        private void Awake()
        {
            mPlayPhasesControl = GetComponent<PlayPhasesControl>();
        }

        public override void OnEnter()
        {
            // TODO
        }

        public override void OnExit()
        {
            // TODO
        }

        private PlayPhasesControl mPlayPhasesControl;
    }
}
