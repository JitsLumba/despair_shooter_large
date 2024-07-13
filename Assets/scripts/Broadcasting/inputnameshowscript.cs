using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputnameshowscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            ViewHandler.Instance.Show(ViewNames.name_unity);
        }
    }
    
}
