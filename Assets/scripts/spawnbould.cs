using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbould : MonoBehaviour
{

    [SerializeField] private Transform fpsposit;
    [SerializeField] private GameObject bould;
    [SerializeField] private Transform spawnpoint;
    private GameObject destobj;
    private int bouldy = 0;
    private float timestep = 0.0f;
    private int rocky;
    private int rockrolled = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float checkx, checky, checkz;
        Vector3 pos = this.fpsposit.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        if ((checkx >= 13.4f && checkx <= 16.6f) && (checky >- 2.35f) && (checkz >= -4.52f && checkz <= 3.6f))
        {
            if (rocky == 0)
            {
                GameObject snowman = GameObject.Instantiate<GameObject>(this.bould, this.transform);
                snowman.transform.localPosition = this.spawnpoint.localPosition;
                destobj = snowman;
                rocky++;
            }
            
            
            
        }
        if (rocky == 1)
        {

            Vector3 myPos = destobj.transform.localPosition;
            myPos.z -= 0.25f;
            Quaternion myRot = destobj.transform.localRotation;
            myRot.x -= 0.25f;
            destobj.transform.localPosition = myPos;

            if (destobj.transform.localPosition.z <= -35.0f && rockrolled == 0)
            {
                Debug.Log("Destroyed");
                GameObject.Destroy(destobj);
                rockrolled++;
            }
        }

    }
}
