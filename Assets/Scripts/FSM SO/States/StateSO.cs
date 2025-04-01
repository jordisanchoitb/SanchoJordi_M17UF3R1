using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSO : ScriptableObject
{
    public ConditionSO StartCondition;
    public List<ConditionSO> EndConditions;
    public abstract void OnStateEnter(Enemy enemy);
    public abstract void OnStateUpdate(Enemy enemy);
    public abstract void OnStateExit(Enemy enemy);

}
