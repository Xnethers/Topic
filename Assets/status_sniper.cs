using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status_sniper : StateMachineBehaviour
{
    public Transform _boss;
    [SerializeField] sniper _sniper;
    void awake()
    {
        _boss = GameObject.Find("Boss").transform;
        _sniper = _boss.GetComponentInChildren<sniper>(); 
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		  _boss = GameObject.Find("Boss").transform;
        _sniper = _boss.GetComponentInChildren<sniper>(); 
        _sniper.UseSkill();
        int i = animator.GetInteger("use_sniper") + 1;
        animator.SetInteger("use_sniper", i);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _sniper.UseSkill();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
