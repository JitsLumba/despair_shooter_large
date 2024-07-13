using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlecollisionfinalpart : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ethanaifinalpart ethanaipl;
    [SerializeField] private projectilefire projfire;
    [SerializeField] private List<poolelecfinal> poollist = new List<poolelecfinal>();
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("Bullet " + other.name);
        //Debug.Log(other.name);
        //Debug.Log("Heo");
        //int colcount = PSystem.GetSafeCollisionEventSize();
        //Debug.Log(colcount);
        if (other.name.Contains("Break"))
        {
            ethanaipl.receivdamage();
        }
        else if (other.name.Contains("Elec"))
        {
            bool check = ethanaipl.canbeelec();
            if (check)
            {
                for (int i = 0; i < poollist.Count; i++)
                {
                    string name = poollist[i].gamenameret(), name2 = ethanaipl.poolisonname();
                    if (name == name2)
                    {
                        poollist[i].electrocuteall();
                    }
                }
                //pool.electrocuteall();
            }
            else
            {
                ethanaipl.electrocute();
            }

        }
        else if (other.name.Contains("Blow"))
        {
            
            ethanaipl.blowaway();
        }


        projfire.destroyparticle();


    }
}
