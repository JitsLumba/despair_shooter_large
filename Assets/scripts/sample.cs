using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    private float timestep = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
        roomlvlmanager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        this.timestep += Time.deltaTime;
        Debug.Log("Time: " + Time.deltaTime);
        if (timestep >= 12.0f)
        {
            roomlvlmanager.Instance.startgame();
        }
    }
}
