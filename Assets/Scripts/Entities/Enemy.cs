using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : AEntity
{
    public GameObject target;
    public bool onRange = false, onAttackRange = false;
    public float speed;
    public StateSO currentNode;
    public List<StateSO> Nodes;
    private NavMeshAgent agent;

    private void Awake()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        GetComponent<EnemyVision>().player = target.transform;
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void Hurt(float damage)
    {
        base.Hurt(damage);
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            onRange = true;
        CheckEndingConditions();
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            onRange = false;
        CheckEndingConditions();
    }*/
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            onAttackRange = true;
        CheckEndingConditions();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            onAttackRange = false;
        CheckEndingConditions();
    }
    private void Update()
    {
        CheckEndingConditions();
        currentNode.OnStateUpdate(this);
    }
    public void CheckEndingConditions()
    {
        foreach (ConditionSO condition in currentNode.EndConditions)
            if (condition.CheckCondition(this) == condition.answer) ExitCurrentNode();
    }
    public void ExitCurrentNode()
    {
        foreach (StateSO stateSO in Nodes)
        {
            if (stateSO.StartCondition == null)
            {
                EnterNewState(stateSO);
                break;
            }
            else
            {
                if (stateSO.StartCondition.CheckCondition(this) == stateSO.StartCondition.answer)
                {
                    EnterNewState(stateSO);
                    break;
                }
            }
        }
        currentNode.OnStateEnter(this);
    }
    private void EnterNewState(StateSO state)
    {
        currentNode.OnStateExit(this);
        currentNode = state;
        currentNode.OnStateEnter(this);
    }

    public void MoveToTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    public void MoveToTarget(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void StopMoving()
    {
        agent.ResetPath();
    }

    public void Attack()
    {
        if (TryGetComponent(out IHurt tg)) {
            tg.Hurt(10);
        }
    }

    public void ScapeTarget(Transform target, Transform origin)
    {
        Vector3 direction = (origin.position - target.position).normalized;
        Vector3 newPos = origin.position + direction;
        agent.SetDestination(newPos);
    }
}
