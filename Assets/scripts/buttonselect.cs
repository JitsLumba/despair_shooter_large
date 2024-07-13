using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonselect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        roomlvlmanager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onmainmenuclick()
    {
        roomlvlmanager.Instance.startscene();
    }
}
