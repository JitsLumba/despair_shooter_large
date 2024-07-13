using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowmanAI : MonoBehaviour
{
    [SerializeField] private float minspeed = 5.0f;
    [SerializeField] private float maxpseed = 10.0f;

    private enum Direction
    {
        FORWARD = 0, BACKWARD = 1, LEFT = 2, RIGHT = 3
    }
    
    private Direction currentDir = Direction.FORWARD;
    private float timeStep = 0.0f;
    private const float Interval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*this.timeStep += Time.deltaTime;
        if (this.timeStep >= Interval)
        {
            this.timeStep = 0.0f;
            this.currentDir = (Direction)Random.Range(0, 4);
            Debug.Log(this.currentDir + " checker");
           
        }

        //direction
        if(this.currentDir == Direction.BACKWARD)
        {
            float speed = Random.Range(this.minspeed, this.maxpseed);
            Vector3 pos = this.transform.localPosition;
            pos.x -= (speed * Time.deltaTime);
            this.transform.localPosition = pos;
        }
        else if (this.currentDir == Direction.FORWARD)
        {
            float speed = Random.Range(this.minspeed, this.maxpseed);
            Vector3 pos = this.transform.localPosition;
            pos.x += (speed * Time.deltaTime);
            this.transform.localPosition = pos;
        }
        else if (this.currentDir == Direction.LEFT)
        {
            float speed = Random.Range(this.minspeed, this.maxpseed);
            Vector3 pos = this.transform.localPosition;
            pos.z += (speed * Time.deltaTime);
            this.transform.localPosition = pos;
        }
        else if (this.currentDir == Direction.RIGHT)
        {
            float speed = Random.Range(this.minspeed, this.maxpseed);
            Vector3 pos = this.transform.localPosition;
            pos.z -= (speed * Time.deltaTime);
            this.transform.localPosition = pos;
        }
        */
    }
}
