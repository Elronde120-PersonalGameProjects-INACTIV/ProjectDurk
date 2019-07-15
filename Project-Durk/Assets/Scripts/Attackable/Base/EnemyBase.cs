using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBase : Attackable 
{
    NavMeshAgent m_navMeshAgent { get; set; }
    public Transform m_destination { get; set; }

    [SerializeField, Header("EnemyBase Variables")]
    private NavMeshAgent Agent;
    [SerializeField, Tooltip("An inspector way to set the agents initial destination. Changing this variable midgame will not change any behaviour")]
    private Transform StartDestination;

    public override void Awake()
    {
        base.Awake();
        if (StartDestination != null) m_navMeshAgent = Agent;
        else Debug.LogError("EnemyBase " + m_name + ": NavMeshAgent was not set on this object!");
        if (StartDestination != null) m_destination = StartDestination;
    }

    public override void Update()
    {
        base.Update();
        if(m_destination != null && m_navMeshAgent.destination != m_destination.position)
        {
            m_navMeshAgent.destination = m_destination.position;
        }
    }

}
