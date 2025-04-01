using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DieState", menuName = "StatesSO/Die")]
public class DieState : StateSO
{
    public override void OnStateEnter(Enemy enemy)
    {
        Debug.Log("Abandoné este mundo de miseria y desesperación");
    }

    public override void OnStateExit(Enemy enemy)
    {
    }

    public override void OnStateUpdate(Enemy enemy)
    {
    }
}
