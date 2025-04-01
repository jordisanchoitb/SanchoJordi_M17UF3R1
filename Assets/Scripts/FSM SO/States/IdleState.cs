using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "StatesSO/Idle")]
public class IdleState : StateSO
{
    public override void OnStateEnter(Enemy enemy)
    {

    }

    public override void OnStateExit(Enemy enemy)
    {
    }

    public override void OnStateUpdate(Enemy enemy)
    {
        Debug.Log("Here chillin");
        enemy.GetComponent<PatrolEnemy>().StartPatrol();
    }
}
