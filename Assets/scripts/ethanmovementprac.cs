using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ethanmovementprac : MonoBehaviour
{
    private const string Ethan_Speed = "EthanSpeed";
    private const string Ethan_Forspeed = "Forwardspeed";
    [SerializeField] private Animator ethananimator;
    [SerializeField] private Transform ethanposition;
    private float rotater = 10.0f;
    private float rotatespeed = 0.0f;
    private float mult = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.ethanposition.transform.localPosition;


        /*if (Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                //walk

                //this.ethananimator.SetInteger(Ethan_Speed, 5);
                this.ethananimator.SetFloat(Ethan_Forspeed, 1.0f);
                pos.z += (Time.deltaTime * 2) * mult;
            }
            else
            {
                //walk

                //this.ethananimator.SetInteger(Ethan_Speed, 2);
                this.ethananimator.SetFloat(Ethan_Forspeed, 0.375f);
                pos.z += (Time.deltaTime * 1) * mult;
            }

            this.ethanposition.transform.localPosition = pos;   
                
            
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            this.ethananimator.SetInteger(Ethan_Speed, 3);
        }
        else
        {
            this.ethananimator.SetFloat(Ethan_Forspeed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.ethanposition.transform.Rotate(Time.deltaTime * Vector3.up * rotater, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.ethanposition.transform.Rotate(Time.deltaTime * Vector3.down * rotater, Space.World);
        }
        /*if (Input.GetKey(KeyCode.S))
        {
            this
        }*/
        

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("FPS"))
        {
            Debug.Log("Hello");
        }
    }
}
