using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpshealth : MonoBehaviour
{
    private int hp = 1;
    private bool canbedmged = true;
    
    //[SerializeField] private hpbehavior hpbeh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.Contains("Ethan"))
        {
            Debug.Log("Health is " + hp);
        }
    }
    void OnParticleCollision(GameObject col)
    {
        ///Debug.Log("Hello mosh");
    }
    public void reducehp()
    {
        if (canbedmged)
        {
            canbedmged = false;
            Debug.Log("Wack");
            hp = hp - 1;
            //Debug.Log("hp " + hp);
            
            //hpbeh.damagecalc();
            StartCoroutine(invisibility());
        }
        
    }
    public bool canbedmgedval()
    {
        return this.canbedmged;
    }
    IEnumerator invisibility()
    {
        yield return new WaitForSeconds(3);
        canbedmged = true;

    }
    void explodedamage()
    {

    }
    void OnTriggerEnter(Collider col)
    {
       if (col.gameObject.name.Contains("Radius"))
        {

        }
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log("Dude");
    }
 }
