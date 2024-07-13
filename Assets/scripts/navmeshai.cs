using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshai : MonoBehaviour
{
    [SerializeField] private Transform destobj;
    [SerializeField] private NavMeshAgent nvmeshagent;
    // Start is called before the first frame update
    void Start()
    {
        setDestination(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setDestination()
    {
        Vector3 targetVector = destobj.transform.position;
        nvmeshagent.SetDestination(targetVector);
    }
}
