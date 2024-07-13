using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancecalculate : MonoBehaviour
{
    [SerializeField] private GameObject bould;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private Transform porttransform;
    private int rockrolled = 0;
    // Start is called before the first frame update
    void Start()
    {
        roomlvlmanager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float checkx, checky, checkz;
        Vector3 portalPos = this.porttransform.localPosition;
        Vector3 myPos = this.transform.localPosition;
        
        Debug.Log("y: " + portalPos.y);
        checkx = portalPos.x;
        checky = portalPos.y;
        checkz = portalPos.z;
        Debug.Log("x: " + portalPos.x);
        Debug.Log("z: " + portalPos.z);
        if ((checkx >= 2.99f && checkx <= 6.7f) && (checky >= 2.35f) && (checkz >= 15.5f && checkz <= 19.67f))
        {
            //z 15.66 19.46 x 3.09 6.64
            roomlvlmanager.Instance.nextscene();
        }
        /*if ((checkx >= 13.4f && checkx <= 16.6f) && (checky == 0.3599998f) && (checkz >= -4.52f && checkz <= 3.6f))
        {
            if (this.rockrolled == 0)
            {
                Debug.Log("Rolling rock here");
                //summoning the rock
                GameObject snowman = GameObject.Instantiate<GameObject>(this.bould, this.transform);
                snowman.transform.localPosition = this.spawnpoint.localPosition;
              
                rockrolled++;
            }
            else
            {
                Debug.Log("Not rolling rock");
            }
            
        }*/
    }
}
