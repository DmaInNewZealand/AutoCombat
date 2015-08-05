using UnityEngine;
using System.Collections;

public class BattleUnitStateMachineController : MonoBehaviour
{
    private Animator animator;

    private int isDelayedHash = Animator.StringToHash("IsDelayed");
    private int isInterruptedHash = Animator.StringToHash("IsInterrupted");
    private int hitHash = Animator.StringToHash("Hit");

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void Update()
    {
       
    }

    public void OnHit(int type)
    {
        Debug.Log("GetHit!   " + type.ToString());
        //See Hit Type
        if (type == 0)
        {
            //nothing
        }
        else if (type == 1)
        {
            //delay
            animator.SetBool(isDelayedHash, true);
        }
        else
        {
            //interrupt
            animator.SetBool(isInterruptedHash, true);
        }

        //Raise Hit Trigger
        animator.SetTrigger(hitHash);
    }
}
