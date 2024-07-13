using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormovex : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float destx;
    [SerializeField] private float startx;
    [SerializeField] private float startfpsx, endfpsx, startfpsz, endfpsz;
    [SerializeField] private Transform fpsloc;
    
    private float speed = 0.0f;
    void Start()
    {
        speed = (destx - startx) / 64;
        //Debug.Log("Speed " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fpsposer = fpsloc.transform.localPosition;
        Vector3 doorpos = this.transform.localPosition;
        int x;
        //Debug.Log("x: " + fpsposer.x + " y: " + fpsposer.y + " z: " + fpsposer.z);
        float posx = fpsposer.x, posz = fpsposer.z;
        if ((posx >= startfpsx && posx <= endfpsx) && (posz >= startfpsz && posz <= endfpsz))
        {
            if (((doorpos.x < destx) && (startx < destx)) || ((doorpos.x > destx) && (startx > destx)))
            {
                doorpos.x = doorpos.x + speed;
                this.transform.localPosition = doorpos;
            }
        }
        
    }
}
