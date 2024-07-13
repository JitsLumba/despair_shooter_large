using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleForce : MonoBehaviour {

    [SerializeField] private float yForce = 0.0f;

    private bool hasValidInput = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInputToggle(bool flag) {
        this.hasValidInput = flag;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name.Contains("Sphere") && this.hasValidInput) {
            Debug.Log("Collided with " +collision.gameObject.name);
            Vector3 force = new Vector3(0.0f, collision.transform.localPosition.y + yForce, 0.0f);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}
