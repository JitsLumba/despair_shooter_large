using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    [SerializeField] private PaddleForce leftPaddleForce;
    [SerializeField] private PaddleForce rightPaddleForce;

    [SerializeField] private Transform leftPaddle;
    [SerializeField] private Transform rightPaddle;

    private float ticks = 0.0f;
    private const float TICKS_MULTIPLIER = 2.0f;


    private bool leftPaddleOn = false;
    private bool rightPaddleOn = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A)) {
            this.leftPaddleOn = true; this.ticks = 0.0f;
            this.leftPaddleForce.SetInputToggle(true);
        }
        else if(Input.GetKeyUp(KeyCode.A)) {
            this.leftPaddleOn = false; this.ticks = 0.0f;
            this.leftPaddleForce.SetInputToggle(false);
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            this.rightPaddleOn = true; this.ticks = 0.0f;
            this.rightPaddleForce.SetInputToggle(true);
        }

        else if (Input.GetKeyUp(KeyCode.D)) {
            this.rightPaddleOn = false; this.ticks = 0.0f;
            this.rightPaddleForce.SetInputToggle(false);
        }

        


    }
    void FixedUpdate ()
    {
        if (this.leftPaddleOn)
        {
            this.ticks += Time.deltaTime * TICKS_MULTIPLIER;
            Quaternion newRot = Quaternion.Euler(0.0f, 0.0f, 80.0f);
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, newRot, this.ticks);
        }
        else if (!this.leftPaddleOn)
        {
            this.ticks += Time.deltaTime * TICKS_MULTIPLIER;
            this.leftPaddle.localRotation = Quaternion.Slerp(this.leftPaddle.localRotation, Quaternion.identity, this.ticks);
        }

        if (this.rightPaddleOn)
        {
            this.ticks += Time.deltaTime * TICKS_MULTIPLIER;
            Quaternion newRot = Quaternion.Euler(0.0f, 0.0f, -80.0f);
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, newRot, this.ticks);
        }
        else if (!this.rightPaddleOn)
        {
            this.ticks += Time.deltaTime * TICKS_MULTIPLIER;
            this.rightPaddle.localRotation = Quaternion.Slerp(this.rightPaddle.localRotation, Quaternion.identity, this.ticks);
        }
    }
}
