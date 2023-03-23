using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterController : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent1;
    [SerializeField] NavMeshAgent navMeshAgent2;
    [SerializeField] LayerMask layerMask;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit,float.MaxValue, layerMask))
            {
                navMeshAgent1.SetDestination(hit.point);
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
            {
                navMeshAgent2.SetDestination(hit.point);
            }
        }
    }
}
