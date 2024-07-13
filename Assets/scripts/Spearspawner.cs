using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearspawner : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] private GameObject spearobj;
    [SerializeField] private Transform spearspawnpoint;
    [SerializeField] private Transform fpsspot;
    [SerializeField] private float extmove, extmax;
    private GameObject spearstore, bloodstore;
    private int spearspawned = 0, bloodspawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float checkx, checky, checkz;
        Vector3 pos = this.fpsspot.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        Vector3 spearpos = this.transform.localPosition;
        
        /*Vector3 pos = this.fpsspot.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        Vector3 spearpos = this.transform.localPosition;
        Debug.Log("x: " + pos.x + " y: " + pos.y + " z: " + pos.z);*/
        if ((checkx >= 0.1f && checkx <= 4.41f) && (checky >= 2.35f) && (checkz >= -13.26f && checkz <= -10.1f))
        {
            if (spearspawned == 0)
            {
                /*audio = GetComponent<AudioSource>();
                audio.Play(0);*/
                GameObject snowman = GameObject.Instantiate<GameObject>(this.spearobj, this.transform);
                snowman.transform.localPosition = this.spearspawnpoint.localPosition;
                spearstore = snowman;
                spearspawned++;
            }



        }
        if (spearspawned == 1)
        {
            if (spearpos.x < extmax)
            {
                spearpos.x += extmove;
                Debug.Log("Checker");
                this.transform.localPosition = spearpos;
            }
           
        }
    }
}
