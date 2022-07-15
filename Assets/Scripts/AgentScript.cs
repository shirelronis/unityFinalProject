using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    void Start () { agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();  }
    void Update () { agent.SetDestination(target.position);  }
}
