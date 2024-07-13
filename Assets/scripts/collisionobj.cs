using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionobj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Ethan"))
        {
            Debug.Log("Hello");
        }
    }
}
