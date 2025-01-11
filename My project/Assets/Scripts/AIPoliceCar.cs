using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class AIPoliceCar : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.destination = player.position;
    }
}