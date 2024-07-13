using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderroll : MonoBehaviour
{
    
    [SerializeField] private GameObject destobj;
    private float zpos;
    private int rockrolled = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float checkx, checky, checkz;
       /* Vector3 myPos = this.transform.localPosition;
        myPos.z -= 1.5f;
        this.transform.localPosition = myPos;
        Debug.LogError("this is " + this.transform.localPosition.z);
        /*if (this.transform.localPosition.z >= 35.0f)
        {
            Debug.Log("Destroyed");
            GameObject.Destroy(destobj);
            rockrolled++;
        }
        /*Vector3 pos = this.fpssee.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        if ((checkx >= 13.4f && checkx <= 16.6f) && (checky == 0.3599998f) && (checkz >= -4.52f && checkz <= 3.6f))
        {
            if (rockrolled == 0)
            {
                Vector3 myPos = this.transform.localPosition;
                myPos.z -= 1.5f;
                myPos.z -= 1.5f;
                this.transform.localPosition = myPos;
                
                if (this.transform.localPosition.z >= 37.0f)
                {
                    GameObject.Destroy(destobj);
                    rockrolled++;
                }
            }
            
        }
        */
    }
}
