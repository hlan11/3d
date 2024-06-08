using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavmest : MonoBehaviour
{
    public Transform destination;
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(destination.position);
    }
}
