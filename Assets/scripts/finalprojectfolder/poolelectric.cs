using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolelectric : MonoBehaviour
{
    [SerializeField] private List<ethanai> ethanailist = new List<ethanai>();
    [SerializeField] private projectilefire projectfire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = ethanailist.Count - 1; i > -1; i--)
        {
            if (ethanailist[i] == null)
                ethanailist.RemoveAt(i);
        }
    }
    public void OnParticleCollision(GameObject other)
    {
        Debug.Log("other " + other.gameObject.name);
        if (other.gameObject.name.Contains("Elec"))
        {
            Debug.Log("elec");
            electrocuteall();
        }
        projectfire.destroyparticle();


    }
    public void electrocuteall()
    {
        for (int i = 0; i < ethanailist.Count; i++)
        {
            bool check = ethanailist[i].canbeelec();
            string poolname = ethanailist[i].poolisonname();
            if (check && (poolname == this.name))
            {
                ethanailist[i].electrocute();
            }

        }
    }
    public string gamenameret()
    {
        return this.name;
    }
}
