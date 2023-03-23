using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

[RequireComponent(typeof(Collider), typeof(NavMeshModifierVolume))]
public class Water : MonoBehaviour
{
    NavMeshModifierVolume navMeshModifierVolume;

    private void Awake()
    {
        navMeshModifierVolume = GetComponent<NavMeshModifierVolume>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (navMeshModifierVolume.AffectsAgentType(agent.agentTypeID))
            {
                agent.speed /= NavMesh.GetAreaCost(navMeshModifierVolume.area);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            if (navMeshModifierVolume.AffectsAgentType(agent.agentTypeID))
            {
                agent.speed *= NavMesh.GetAreaCost(navMeshModifierVolume.area);
            }
        }
    }
}
