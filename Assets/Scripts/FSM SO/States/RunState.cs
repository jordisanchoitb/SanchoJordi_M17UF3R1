using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "RunState", menuName = "StatesSO/Run")]
public class RunState : StateSO
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
        enemy.ScapeTarget(enemy.target.transform, enemy.transform);
        Debug.Log("CoSorro");
    }
}
