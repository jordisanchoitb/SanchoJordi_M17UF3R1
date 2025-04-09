using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    private Enemy enemy;
    public GameObject patrol;
    public float toleranceDistance = 0.5f;
    public List<Transform> waypoints;
    public int currentWaypointIndex;
    public bool isSearching;

    private void OnEnable()
    {
        currentWaypointIndex = 0;
        isSearching = false;
        if (enemy != null)
        {
            patrol.transform.position = transform.position;
        }
    }

    private void Start()
    {
        patrol = GameObject.Find("Patrol");
        waypoints = patrol.GetComponentsInChildren<Transform>().ToList();
        waypoints.RemoveAt(0);
        enemy = GetComponent<Enemy>();
    }

    public void StartPatrol()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < toleranceDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0;
            }
        }
        enemy.MoveToTarget(waypoints[currentWaypointIndex].position);
    }

    private bool IsWaypointsInNavMesh()
    {
        int validWaypointsCount = 0;
        foreach (Transform waypoint in waypoints)
        {
            if (NavMesh.SamplePosition(waypoint.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
            {
                validWaypointsCount++;
            }
        }

        return validWaypointsCount >= 2;
    }
    private void Update()
    {
        if (isSearching && !IsWaypointsInNavMesh())
        {
            RotatePatrol();
        }
        else if (isSearching)
        {
            isSearching = false;
        }
    }
    private void RotatePatrol()
    {
        Vector3[] directions = { transform.forward, -transform.forward, transform.right, -transform.right };
        foreach (Vector3 direction in directions)
        {
            patrol.transform.rotation = Quaternion.LookRotation(direction);
            if (IsWaypointsInNavMesh())
            {
                isSearching = false;
                return;
            }
        }
    }
}
