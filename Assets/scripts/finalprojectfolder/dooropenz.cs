using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropenz : MonoBehaviour
{
    [SerializeField] private float destz;
    [SerializeField] private float startz;
    
    private float speed = 0.0f;
    private bool canmove = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = (destz - startz) / 64;
        //Debug.Log("Door open speed " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            Debug.Log("Now");
            Vector3 doorpos = this.transform.localPosition;
            if (((doorpos.z < destz) && (startz < destz)) || ((doorpos.z > destz) && (startz > destz)))
            {
                doorpos.z = doorpos.z + speed;
                this.transform.localPosition = doorpos;
            }
            else
            {
                canmove = false;
            }
        }
    }
    public void opendoor()
    {
        Debug.Log("Opening");
        canmove = true;

    }
}
