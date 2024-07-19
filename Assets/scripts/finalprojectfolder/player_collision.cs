using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canelec = false;
    private bool isondanger = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool get_can_elec() {
        return canelec;
    }
    public bool get_is_on_danger() {
        return isondanger;
    }
     private void OnCollisionStay(Collision col)
    {
      
        if (col.gameObject.name.Contains("Water"))
        {
            
            canelec = true;
        }
       

    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name.Contains("Radius"))
        {
            
            isondanger = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Contains("Radius"))
        {
            
            isondanger = false;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name.Contains("Water"))
        {
            
            canelec = false;
        }
        
    }
}
