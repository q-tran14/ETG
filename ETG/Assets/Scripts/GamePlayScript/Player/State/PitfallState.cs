using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallState : IState
{
    // follow the key input
    public float previous_direction_ver;
    public float previous_direction_hori;
    public override void EnterState()
    {
        previous_direction_hori = base.stateManager.hori;
        previous_direction_ver = base.stateManager.ver;
        base.stateManager.animator.Play("Pitfall");
    }

    public override void UpdateState()
    {
        if (base.stateManager.animator.GetCurrentAnimatorStateInfo(0).IsName("Pitfall") && base.stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            base.stateManager.transform.position = base.stateManager.lastPos;
            base.stateManager.animator.Play("PitfallReturn");
        }
        if (base.stateManager.animator.GetCurrentAnimatorStateInfo(0).IsName("PitfallReturn") && base.stateManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            base.stateManager.SwitchState(new IdleState());
        }
    }
}
