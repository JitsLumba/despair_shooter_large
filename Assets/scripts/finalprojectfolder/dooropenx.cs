using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropenx : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float destx;
    [SerializeField] private float startx;
    private bool canmove = false;
    private float speed = 0.0f;
    void Start()
    {
        speed = (destx - startx) / 64;
        //Debug.Log("Door open speed " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (canmove)
        {
            Debug.Log("Now");
            Vector3 doorpos = this.transform.localPosition;
            if (((doorpos.x < destx) && (startx < destx)) || ((doorpos.x > destx) && (startx > destx)))
            {
                doorpos.x = doorpos.x + speed;
                this.transform.localPosition = doorpos;
            }
            else
            {
                canmove = false;
            }
        }
    }
    public void opendoor()
    {
        Debug.Log("Opening");
        canmove = true;
        
    }
}
