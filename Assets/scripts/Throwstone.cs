using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwstone : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] private Transform fpsspot;
    [SerializeField] private GameObject stoneobj;
    [SerializeField] private Transform spawnspot;
    [SerializeField] private float maxend, maxspeed;
    private int stonespawned = 0;
    private GameObject destobj;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audy;
        audy = audio;
        float checky, checkx, checkz;
        Vector3 pos = this.fpsspot.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        Vector3 spearpos = this.transform.localPosition;
        Vector3 spawnpos = this.transform.localPosition;
        //Debug.Log("x: " + pos.x + " y: " + pos.y + " z: " + pos.z);
        if ((checkx >= 40.1f && checkx <= 50.1f) && (checky >= 2.35f) && (checkz >= 10.29f && checkz <= 20.1f))
        {
            if (stonespawned == 0)
            {
                GameObject snowman = GameObject.Instantiate<GameObject>(this.stoneobj, this.transform);
                snowman.transform.localPosition = this.spawnspot.localPosition;
                destobj = snowman;
                stonespawned++;
            }



        }
        if (stonespawned == 1)
        {
            spawnpos.x += maxspeed;
            this.transform.localPosition = spawnpos;
           
            if (spawnpos.x >= maxend)
            {
                
                
                GameObject.Destroy(destobj);
            }
        }
    }
}

