using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]
public class ChaseState : StateSO
{
    public override void OnStateEnter(Enemy enemy)
    {
        enemy.GetComponent<Animator>().SetBool("IsRunning", true);
    }

    public override void OnStateExit(Enemy enemy)
    {
        enemy.StopMoving();
        enemy.GetComponent<Animator>().SetBool("IsRunning", false);
    }

    public override void OnStateUpdate(Enemy enemy)
    {
        Debug.Log("Ven que te quiero decir una cosa");
        enemy.MoveToTarget();
    }
}
