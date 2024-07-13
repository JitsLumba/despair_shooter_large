using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles mouse clicking to determine the nav mesh position.
/// </summary>
public class MouseClicker : MonoBehaviour {

    [SerializeField] private Camera mainCamera;
    [SerializeField] private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
            Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.green, 3.0f);

            RaycastHit hit;
            if(Physics.Raycast(ray.origin, ray.direction, out hit)) {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                this.agent.SetDestination(hit.point);
            }
        }
	}
}
