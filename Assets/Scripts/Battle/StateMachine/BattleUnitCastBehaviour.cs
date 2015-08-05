using UnityEngine;
using System.Collections;

public class BattleUnitCastBehaviour : StateMachineBehaviour
{
    private float castingTime;

    //ParameterHash
    private int castingTimeHash = Animator.StringToHash("CastingTime");
    private int isDelayedHash = Animator.StringToHash("IsDelayed");
    private int isInterruptedHash = Animator.StringToHash("IsInterrupted");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Get castingTime
        castingTime = animator.GetFloat(castingTimeHash);

        //TODO:castTime should get from current skill
        float skillCastTime = 1.2f;

        if (castingTime < 0.0f || castingTime > skillCastTime)
        {
            castingTime = skillCastTime;
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (castingTime >= 0)
        {
            castingTime -= Time.deltaTime;
            animator.SetFloat(castingTimeHash, castingTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (castingTime >= 0)
        {
            //Does not finish casting, hero is hit
            if (animator.GetBool(isDelayedHash))
            {
                castingTime += 0.5f;
                animator.SetFloat(castingTimeHash, castingTime);
                return;
            }

            if (animator.GetBool(isInterruptedHash))
            {
                castingTime = 0.0f - float.Epsilon;
                animator.SetFloat(castingTimeHash, castingTime);
                return;
            }
        }
    }
}
