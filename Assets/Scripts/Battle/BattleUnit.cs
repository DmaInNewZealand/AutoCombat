using System;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    private int side;                           //Battle Unit Side
    private BaseCharacter battleUnit;           //Battle Unit Attributes

    private const int TOTAL_ATTRIBUTES = 50;    //Battle Unit Initiate Attributes Count

    public BattleUnit Target;

    void Awake()
    {
        InitBattleUnitAttributes();
    }

    void Update()
    {
        //Calculate Neareat Target
        Target = GetTarget();

        //Adjust Direction
        transform.LookAt(Target.transform, Vector3.up);
    }

    private BattleUnit GetTarget()
    {
        List<BattleUnit> targets = side == 0 ? BattleManager.Instance.RightSideTeam : BattleManager.Instance.LeftSideTeam;

        float distance = float.MaxValue;
        BattleUnit nearestBattleUnit = null;

        foreach (var target in targets)
        {
            var dis = Vector3.Distance(transform.position, target.transform.position);
            if (distance > dis)
            {
                distance = dis;
                nearestBattleUnit = target;
            }
        }
        return nearestBattleUnit;
    }

    private void InitBattleUnitAttributes()
    {
        battleUnit = new BaseCharacter();

        int attributesCount = Enum.GetValues(typeof(AttributeName)).Length;
        int[] attributes = new int[attributesCount];

        //Randomly Generate Attributes
        for (int i = 0; i < TOTAL_ATTRIBUTES; i++)
        {
            attributes[UnityEngine.Random.Range(0, attributesCount)]++;
        }

        //Set Attributes to Character
        for (int i = 0; i < attributesCount; i++)
        {
            battleUnit.GetAttribute(i).Add(attributes[i]);
        }
    }

    public void SetBattleUnitSide(int _side)
    {
        //0, Left, 1 , Right
        side = _side;
    }
}
