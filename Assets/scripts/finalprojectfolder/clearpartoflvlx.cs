using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearpartoflvlx : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int num;
    [SerializeField] private dooropenx door1, door2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reduceenemy()
    {
        num = num - 1;
        if (num == 0)
        {
            door1.opendoor();
            door2.opendoor();
        }
    }
}
