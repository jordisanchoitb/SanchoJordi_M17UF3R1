using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "StatesSO/Attack")]
public class AttackState : StateSO
{
    private float attackTime = 1.5f;
    private Coroutine attackCoroutine;
    public override void OnStateEnter(Enemy enemy)
    {
        attackCoroutine = enemy.StartCoroutine(Attack(enemy));
    }

    public override void OnStateExit(Enemy enemy)
    {
        enemy.StopCoroutine(attackCoroutine);
    }

    public override void OnStateUpdate(Enemy enemy)
    {
    }

    private IEnumerator Attack(Enemy enemy)
    {
        enemy.GetComponent<Animator>().SetTrigger("IsAttack");
        yield return new WaitForSeconds(attackTime);
        enemy.target.GetComponent<Player>().Hurt(10);
        Debug.Log("Te reviento a chancletaso");
    }


}
