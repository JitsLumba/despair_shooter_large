using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolelectricz : MonoBehaviour
{
    [SerializeField] private List<ethanaiz> ethanailist = new List<ethanaiz>();
    [SerializeField] private projectilefire projectfire;
    
    [SerializeField] private player_collision player_collide;
    [SerializeField] private gamenotifier gamenotif;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.name);
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
        bool player_can_elec = player_collide.get_can_elec();
        if (player_can_elec) {
            gamenotif.reduceplayerhp();
        }
        float remaining_player_hp = gamenotif.get_player_hp();
        if (remaining_player_hp >= 1.0) {
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
    }
    public string gamenameret()
    {
        return this.name;
    }
}
