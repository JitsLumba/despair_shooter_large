using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPaddleController : MonoBehaviour {

    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;
    private bool islefton = false;
    private bool isrighton = false;
    private float multiplier = 2.0f;
    private float ticks = 0.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            //this.leftPaddle.transform.Rotate(new Vector3(0.0f, 0.0f, 80.0f));
            islefton = true;
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            //this.leftPaddle.transform.localRotation = Quaternion.identity;
            islefton = false;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            //this.rightPaddle.transform.Rotate(new Vector3(0.0f, 0.0f, -80.0f));
            isrighton = true;
        }

        else if (Input.GetKeyUp(KeyCode.D)) {
            //this.rightPaddle.transform.localRotation = Quaternion.identity;
            isrighton = false;

        }
        if (this.islefton)
        {
            this.ticks += Time.deltaTime * multiplier;
            Quaternion newrot = Quaternion.Euler(0.0f, 0.0f, 80.0f);
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, newrot, ticks);
        }
        else if (!(this.islefton))
        {
            this.ticks += Time.deltaTime * multiplier;
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, Quaternion.identity, this.ticks);
        }
        if (this.isrighton)
        {
            this.ticks += Time.deltaTime * multiplier;
            Quaternion newrot = Quaternion.Euler(0.0f, 0.0f, -80.0f);
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, newrot, this.ticks);
        }
        else if (!(this.isrighton))
        {
            this.ticks += Time.deltaTime * multiplier;
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, Quaternion.identity, this.ticks);
        }
    }
    void FixedUpdate()
    {
        /*if (this.islefton)
        {
            this.ticks += Time.deltaTime * multiplier;
            Quaternion newrot = Quaternion.Euler(0.0f, 0.0f, 80.0f);
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, newrot, ticks);
        }
        else if (!(this.islefton))
        {
            this.ticks += Time.deltaTime * multiplier;
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, Quaternion.identity, this.ticks);
        }
        if (this.isrighton)
        {
            this.ticks += Time.deltaTime * multiplier;
            Quaternion newrot = Quaternion.Euler(0.0f, 0.0f, -80.0f);
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, newrot, this.ticks);
        }
        else if (!(this.isrighton))
        {
            this.ticks += Time.deltaTime * multiplier;
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, Quaternion.identity, this.ticks);
        }*/
    }
}
