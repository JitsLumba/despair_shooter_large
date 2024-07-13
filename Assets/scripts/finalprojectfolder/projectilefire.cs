using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilefire : MonoBehaviour
{
    private int elecbullets = 20;
    private Transform samper;
    //[SerializeField] private ParticleSystem PSystem;
    [SerializeField] private bool elecenabled, blowenabled;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject firepoint;
    [SerializeField] private List<GameObject> vfx = new List<GameObject>(), vfx1 = new List<GameObject>();
    private GameObject effectspawn;
    private bool canshoot = true;
    private bool canselect = true;
    [SerializeField] private gunscript gscript;
    private GameObject samp;
    private string bulletype = "Break";
    private ParticleCollisionEvent[] CollisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        effectspawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && canselect) {
            bulletype = "Break";
            effectspawn = vfx[0];
            canselect = false;
            StartCoroutine(canchoosebulletagain());
        }
        if (Input.GetKey(KeyCode.Alpha2) && canselect && elecenabled) {
            bulletype = "Elec";
            effectspawn = vfx[1];
            canselect = false;
            StartCoroutine(canchoosebulletagain());
        }
        if (Input.GetKey(KeyCode.Alpha3) && canselect && blowenabled)
        {
            bulletype = "Knockdown";
            effectspawn = vfx[2];
            canselect = false;
            StartCoroutine(canchoosebulletagain());
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireparticles();
        }
    }
    public void destroyparticle()
    {
        int size = vfx1.Count - 1;
        GameObject.Destroy(vfx1[size]);
        vfx1.RemoveAt(size);
    }
    void fireparticles()
    {
        bool canshooter = true;
        if (elecbullets == 0 && bulletype == "Elec")
        {
            canshooter = false;
        }
        else
        {
            elecbullets = elecbullets - 1;
        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (firepoint != null && canshoot && canshooter)
        {
            
            canshoot = false;
            StartCoroutine(example());
            samp = GameObject.Instantiate(effectspawn, firepoint.transform.position, Quaternion.LookRotation(ray.direction));
            /*if (gscript != null)
            {
                samp.transform.localRotation = gscript.getRotater();
            }*/
            









            samp.SetActive(true);
            vfx1.Add(samp);
            
        }
    }
    IEnumerator example()
    {
        yield return new WaitForSeconds(1);
        canshoot = true;
    }
   void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hello world");
        /*Debug.Log("Hello");
        int collCount = PSystem.GetSafeCollisionEventSize();

        if (collCount > CollisionEvents.Length)
            CollisionEvents = new ParticleCollisionEvent[collCount];

        int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);
        Debug.Log(eventCount);
        for (int i = 0; i < eventCount; i++)
        {
            Debug.Log("1+");
            //TODO: Do your collision stuff here. 
            // You can access the CollisionEvent[i] to obtaion point of intersection, normals that kind of thing
            // You can simply use "other" GameObject to access it's rigidbody to apply force, or check if it implements a class that takes damage or whatever
        }*/
    }
    IEnumerator canchoosebulletagain()
    {
        yield return new WaitForSeconds(1);
        canselect = true;
    }
}
