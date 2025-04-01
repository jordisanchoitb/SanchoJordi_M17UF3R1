using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StateSO
{
    public override void OnStateEnter(Enemy enemy)
    {
    }

    public override void OnStateExit(Enemy enemy)
    {
        enemy.StopMoving();
    }

    public override void OnStateUpdate(Enemy enemy)
    {
        Debug.Log("Ven que te quiero decir una cosa");
        enemy.MoveToTarget();
    }
}
