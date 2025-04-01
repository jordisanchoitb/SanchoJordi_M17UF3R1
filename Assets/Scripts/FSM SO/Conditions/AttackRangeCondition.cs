using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackRangeCondition", menuName = "ConditionSO/OnAttackRange")]
public class AttackRangeCondition : ConditionSO
{
    public override bool CheckCondition(Enemy enemy)
    {
        return enemy.onAttackRange;
    }
}
