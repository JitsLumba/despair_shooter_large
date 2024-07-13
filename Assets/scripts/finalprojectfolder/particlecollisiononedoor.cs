using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlecollisiononedoor : MonoBehaviour
{
    [SerializeField] private ParticleSystem PSystem;
    [SerializeField] private ethainaionedoor ethanaipl;
    [SerializeField] private projectilefire projfire;
    private ParticleCollisionEvent[] CollisionEvents;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnParticleCollision(GameObject other)
    {
        //Debug.Log(other.name);
        //Debug.Log("Heo");
        int colcount = PSystem.GetSafeCollisionEventSize();
        //Debug.Log(colcount);
        ethanaipl.receivdamage();
        projfire.destroyparticle();

    }
}
