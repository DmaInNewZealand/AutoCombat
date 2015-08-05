using UnityEngine;
using System.Collections;

public class BattleUnitNonAttackBehaviour : StateMachineBehaviour
{
    //HeroController
    //public BattleUnitStateMachineController Controller;

    //ParameterHash
    private int attackCDHash = Animator.StringToHash("AttackCD");
    private float attackCD = 3.0f;

    private int distanceHash = Animator.StringToHash("Distance");
    private float attackRange = 10f;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Calculate AttackCD
        if (attackCD >= 0)
        {
            attackCD -= Time.deltaTime;
            animator.SetFloat(attackCDHash, attackCD);
        }

        var Target = animator.GetComponent<BattleUnit>().Target;

        //Calculate Distance
        if (Target != null)
        {
            animator.SetFloat(distanceHash, Vector3.Distance(animator.transform.position, Target.transform.position) - attackRange);
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        attackCD = 3.0f;
        animator.SetFloat(attackCDHash, attackCD);
    }

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
    //
    //}
}
