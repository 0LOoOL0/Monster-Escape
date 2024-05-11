using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(StartFollowingAfterDelay(10f));
    }

    IEnumerator StartFollowingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        agent.destination = target.transform.position;
    }
}