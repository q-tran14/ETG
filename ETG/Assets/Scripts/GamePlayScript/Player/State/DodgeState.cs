using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : IState
{
    public override void EnterState()
    {
        if(base.stateManager.hand.activeSelf == true && base.stateManager.weaponActive == true)
        {
            base.stateManager.hand.SetActive(false);
        }
        base.setValueAndPlay("Dodge");
        base.stateManager.isOnFloor = false;
    }

    public override void UpdateState()
    {
        if (base.stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            base.stateManager.isDodging = false;
            if (base.stateManager.hand.activeSelf == false && base.stateManager.weaponActive == true)
            {
                base.stateManager.hand.SetActive(true);
            }
            base.stateManager.SwitchState(new RunState());
        }
    }
}
