using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockspawnblood : MonoBehaviour
{
    [SerializeField] private Transform fpsspot, spawnpoint, rockdist;
    [SerializeField] private GameObject bloodobj;
    [SerializeField] private float distance;
    private int bloodspawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float checkx, checky, checkz;
        Vector3 pos = this.fpsspot.transform.localPosition;
        Vector3 rockpos = this.rockdist.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        if ((checkx >= 40.1f && checkx <= 50.1f) && (checky >= 2.35f) && (checkz >= 10.29f && checkz <= 20.1f))
        {
            if (rockpos.x >= distance)
            {
                if (bloodspawn == 0)
                {
                    bloodspawn++;
                    GameObject snowman = GameObject.Instantiate<GameObject>(this.bloodobj, this.transform);
                    snowman.transform.localPosition = this.spawnpoint.localPosition;
                }
            }
        }
    }
}
