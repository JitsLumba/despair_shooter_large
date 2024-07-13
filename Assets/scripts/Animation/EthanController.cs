using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EthanController : MonoBehaviour {

    private const string ETHAN_SPEED_KEY = "EthanSpeed";
    private const string ETHAN_JUMP_KEY = "Jump";
    private const string ETHAN_CROUCH_KEY = "Crouch";

    private const string ETHAN_FORWARD_KEY = "ForwardSpeed";
    private const string ETHAN_TURN_KEY = "Turn";


    [SerializeField] private Animator ethanAnimator;

    private const float CAMERA_TURN_AMOUNT = 200.0f;

    private const float FORWARD_MULTIPLIER = 2.0f;
    private const float TURN_MULTIPLIER = 2.0f;

    private float forwardSpeed = 0.0f;
    private float turnSpeed = 0.0f;

    private KeyCode lastTurnPress;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) {
            
           
            if(Input.GetKey(KeyCode.LeftShift)) {
                //run
                //this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 5);
                if (this.forwardSpeed < 1.0f) {
                    this.forwardSpeed += Time.deltaTime * FORWARD_MULTIPLIER;
                }
                this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);
            }
            else {
                //walk
                //this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 2);
                if(this.forwardSpeed < 0.5f) {
                    this.forwardSpeed += Time.deltaTime *  FORWARD_MULTIPLIER;
                    this.forwardSpeed = Mathf.Clamp(this.forwardSpeed, 0.0f, 0.5f);
                }
                else if(this.forwardSpeed > 0.5f) {
                    this.forwardSpeed -= Time.deltaTime * FORWARD_MULTIPLIER;
                }
                this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);

            }
        }
        else {
            //this.ethanAnimator.SetInteger(ETHAN_SPEED_KEY, 0);

            if(this.forwardSpeed > 0.0f) {
                this.forwardSpeed -= Time.deltaTime * FORWARD_MULTIPLIER;
            }

            this.ethanAnimator.SetFloat(ETHAN_FORWARD_KEY, this.forwardSpeed);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            this.ethanAnimator.SetTrigger(ETHAN_JUMP_KEY);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)) {
            this.ethanAnimator.SetBool(ETHAN_CROUCH_KEY, true);
        }

        if(Input.GetKeyUp(KeyCode.LeftControl)) {
            this.ethanAnimator.SetBool(ETHAN_CROUCH_KEY, false);
        }

        if(Input.GetKey(KeyCode.D)) {
            if(this.turnSpeed > -1.0f) {
                this.turnSpeed -= Time.deltaTime * TURN_MULTIPLIER;
            }

            transform.Rotate(Vector3.up * Time.deltaTime * CAMERA_TURN_AMOUNT, Space.World);
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);

            this.lastTurnPress = KeyCode.D;
        }

        if(Input.GetKey(KeyCode.A)) {
            if (this.turnSpeed < 1.0f) {
                this.turnSpeed += Time.deltaTime * TURN_MULTIPLIER;
            }

            transform.Rotate(Vector3.down * Time.deltaTime * CAMERA_TURN_AMOUNT, Space.World);
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);

            this.lastTurnPress = KeyCode.A;
        }

        //if user is not pressing any turn, reduce turn speed gradually.
        if (this.turnSpeed < 0.0f && !Input.GetKey(KeyCode.D) && this.lastTurnPress == KeyCode.D) {
            this.turnSpeed += Time.deltaTime * TURN_MULTIPLIER;
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);
        }
        else if(this.turnSpeed > 0.0f && !Input.GetKey(KeyCode.A) && this.lastTurnPress == KeyCode.A) {
            this.turnSpeed -= Time.deltaTime * TURN_MULTIPLIER;
            this.ethanAnimator.SetFloat(ETHAN_TURN_KEY, this.turnSpeed);
        }

    }
}
