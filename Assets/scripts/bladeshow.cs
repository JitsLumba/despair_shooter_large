using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeshow : MonoBehaviour
{
   
    [SerializeField] private GameObject blade;
    [SerializeField] private Transform fpsspot;
    [SerializeField] private Transform bladespawn;
    [SerializeField] private float minbladex, minbladey, minbladez, maxbladex, maxbladey, maxbladez;
    [SerializeField] private float movex, movey, movez;
    [SerializeField] private float minx, maxx, miny, maxy, minz, maxz;
    private GameObject snowman;
    private int bladeshod = 0, blademax = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float checkx, checky, checkz;
        Vector3 fpsPos = this.fpsspot.localPosition;
        Vector3 pos = this.transform.localPosition;
        checkx = fpsPos.x;
        checky = fpsPos.y;
        checkz = fpsPos.z;
        if ((checkx >= minx && checkx <= maxx) && (checky >= 2.35f) && (checkz >= minz && checkz <= maxz))
        {
            if (bladeshod == 0)
            {
                snowman = GameObject.Instantiate<GameObject>(this.blade, this.transform);
                snowman.transform.localPosition = this.bladespawn.localPosition;
                /*audio = GetComponent<AudioSource>();
                audio.Play(0);*/
                bladeshod++;
            }



        }
        if (bladeshod == 1)
        {
            
            if (blademax == 0)
            {
                if ((pos.z >= maxbladez && movez > 0))
                {
                    blademax++;
                    pos.x += movex;
                    pos.z -= movez;
                }
                else if ((pos.z <= maxbladez && movez < 0))
                {
                    blademax++;
                    pos.x += movex;
                    pos.z += movez;
                }
                else
                {
                    pos.x += movex;
                    pos.z += movez;
                }

                this.transform.localPosition = pos;
            }
            else
            {

                pos.x += movex;
                if (movez < 0)
                {
                    pos.z -= movez;
                }
                else
                {
                    pos.z += movez;
                }
                
                this.transform.localPosition = pos;
                if (pos.x >= maxbladex)
                {
                  
                    GameObject.Destroy(snowman);
                    GameObject.Destroy(this);
                }
                
                
            }
        }
    }
}
