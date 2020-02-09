using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : StateMachineBehaviour
{
    bool IsOver;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
        if (!IsOver && stateInfo.normalizedTime >= 1)
        {
            IsOver = true;
            var resource = Resources.FindObjectsOfTypeAll<CanvasReturn>()[0];

            resource.gameObject.SetActive(true);
        }

    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
