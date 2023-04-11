using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IState
{
    public override void EnterState()
    {
        base.setValueAndPlay("Dodge");
        base.stateManager.isOnFloor = false;
    }

    public override void UpdateState()
    {
        if (base.stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8)
        {
            base.stateManager.isDodging = false;
            base.stateManager.SwitchState(new RunState());
        }
    }
}
