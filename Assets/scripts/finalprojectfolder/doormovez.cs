using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormovez : MonoBehaviour
{
    [SerializeField] private float destz;
    [SerializeField] private float startz;
    [SerializeField] private float startfpsx, endfpsx, startfpsz, endfpsz;
    [SerializeField] private Transform fpsloc;
    private float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = (destz - startz) / 64;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fpsposer = fpsloc.transform.localPosition;
        Vector3 doorpos = this.transform.localPosition;
        int z;
        //Debug.Log("x: " + fpsposer.x + " y: " + fpsposer.y + " z: " + fpsposer.z);
        float posx = fpsposer.x, posz = fpsposer.z;
        if ((posx >= startfpsx && posx <= endfpsx) && (posz >= startfpsz && posz <= endfpsz))
        {
            if (((doorpos.z < destz) && (startz < destz)) || ((doorpos.z > destz) && (startz > destz)))
            {
                doorpos.z = doorpos.z + speed;
                this.transform.localPosition = doorpos;
            }
        }
    }
}
