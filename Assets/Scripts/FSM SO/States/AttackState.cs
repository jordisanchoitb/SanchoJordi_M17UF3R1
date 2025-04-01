using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "StatesSO/Attack")]
public class AttackState : StateSO
{
    private float attackTime = 0.5f;
    private Coroutine attackCoroutine;
    public override void OnStateEnter(Enemy enemy)
    {
        attackCoroutine = enemy.StartCoroutine(Attack(enemy.target));
    }

    public override void OnStateExit(Enemy enemy)
    {
        enemy.StopCoroutine(attackCoroutine);
    }

    public override void OnStateUpdate(Enemy enemy)
    {
    }

    private IEnumerator Attack(GameObject target)
    {
        yield return new WaitForSeconds(attackTime);
        target.GetComponent<Player>().Hurt(10);
        Debug.Log("Te reviento a chancletaso");
        attackCoroutine = target.GetComponent<Player>().StartCoroutine(Attack(target));
    }


}
