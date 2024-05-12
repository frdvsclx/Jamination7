using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range; //radius of sphere

    public Transform centrePoint; //centre of the area the agent wants to move around in

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        range = Random.Range(22, 40);
        centrePoint = GameObject.FindGameObjectWithTag("CenterFocus").transform;
    }

    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(6);
        Vector3 point;
        if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
        {
            agent.SetDestination(point);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
