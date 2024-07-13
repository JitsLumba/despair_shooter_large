using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodspawn : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] private Transform fpsspot, spawnspot, spearlocat;
    [SerializeField] private GameObject blood;
    [SerializeField] private float maxext;
    private int bloodspawned = 0;
    private GameObject destobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float checky, checkx, checkz;
        Vector3 pos = this.fpsspot.transform.localPosition;
        checkx = pos.x;
        checky = pos.y;
        checkz = pos.z;
        Vector3 spearpos = this.spearlocat.transform.localPosition;
        if ((checkx >= 0.1f && checkx <= 4.41f) && (checky >= 2.35f) && (checkz >= -13.26f && checkz <= -10.1f))
        {
            if (spearpos.x >= maxext)
            {
                if (bloodspawned == 0)
                {
                    /*audio = GetComponent<AudioSource>();
                    audio.Play(0);*/
                    GameObject snowman = GameObject.Instantiate<GameObject>(this.blood, this.transform);
                    snowman.transform.localPosition = this.spawnspot.localPosition;
                    destobj = snowman;
                    bloodspawned++;
                }
                
            }
        }
       /* GameObject snowman = GameObject.Instantiate<GameObject>(this.spearobj, this.transform);
        snowman.transform.localPosition = this.spearspawnpoint.localPosition;
        spearstore = snowman;
        spearspawned++;*/
    }
}
