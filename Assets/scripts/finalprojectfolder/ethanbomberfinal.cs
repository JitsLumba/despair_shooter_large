using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ethanbomberfinal : MonoBehaviour
{
    private bool wentnear;
    private bool isondanger = false;
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    [SerializeField] private float navermeshspeed;
    [SerializeField] private fpshealth fpshealther;
    private bool canelec;
    [SerializeField] private string ethantype;
    private string poolison;
    // Start is called before the first frame update
    [SerializeField] private int hp = 3;
    private bool move = false;
    private bool isnotattacking = true;
    private bool candmg = false;
    private const string ethanrun = "ethanmove";
    private GameObject soundrep;
    [SerializeField] private GameObject soundobj;
    [SerializeField] private float startx, endx, startz, endz;
    [SerializeField] private Transform destobj;
    [SerializeField] private NavMeshAgent nvmeshagent;
    [SerializeField] private Animator aianimator;
    [SerializeField] private Transform ethanpos;
    [SerializeField] private GameObject explsound, soundloc;
    private GameObject sfx;
    [SerializeField] private gamenotifier gamenotif;
    [SerializeField] private GameObject indic, colliderredii, particleexp;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private GameObject ethanobjai;
    [SerializeField] private List<ethanaifinalpart> ethanppl = new List<ethanaifinalpart>();
    private bool hasexploded = true;
    private bool canexplode = false, initiate = false;
    // Start is called before the first frame update
    void Start()
    {
        nvmeshagent.enabled = false;
        aianimator.SetInteger(ethanrun, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distx, disty, distz, fpsx, fpsz;
        Vector3 ethanaipos = this.ethanpos.localPosition;
        Vector3 fpspos = this.destobj.localPosition;
        distx = Mathf.Abs(ethanaipos.x - fpspos.x);
        disty = Mathf.Abs(ethanaipos.y - fpspos.y);
        distz = Mathf.Abs(ethanaipos.z - fpspos.z);
        fpsx = fpspos.x;
        fpsz = fpspos.z;

        if ((fpsx >= startx && fpsx <= endx) && (fpsz >= startz && fpsz <= endz) && !(nvmeshagent.enabled))
        {
            move = true;
            initiate = true;
            nvmeshagent.enabled = true;
            Debug.Log("Supper");
        }
        if (move && !(canexplode))
        {

            setDestination();

            this.aianimator.SetInteger(ethanrun, 1);
            if (initiate)
            {

                initiate = false;
                StartCoroutine(explodecounter());
            }


        }

        else if (move && canexplode)
        {

            nvmeshagent.speed = 0.0f;
            aianimator.SetInteger(ethanrun, 3);
            //StartCoroutine(explodecounter());
        }
        if (distz <= 3.5f && distx <= 3.5f && !(canexplode) && move)
        {
            nvmeshagent.speed = 0.0f;
            move = false;
            wentnear = true;






            // Debug.Log("Attacking");
        }
        else if (distz > 3.5f && distx > 3.5f && !(canexplode) && !(move) && wentnear)
        {
            if (!(move) && wentnear)
            {
                nvmeshagent.speed = navermeshspeed;
                wentnear = false;
                move = true;
            }
        }
        //aianimator
    }
    void setDestination()
    {
        Vector3 targetVector = destobj.transform.position;
        nvmeshagent.SetDestination(targetVector);
    }
    void explode()
    {

    }
    IEnumerator tick()
    {
        yield return new WaitForSeconds(3);
        canexplode = true;
    }
    IEnumerator explodecounter()
    {
        yield return new WaitForSeconds(15);
        canexplode = true;
        indic.SetActive(true);
        colliderredii.SetActive(true);
        particleexp.SetActive(true);
        StartCoroutine(explodestart());
    }
    IEnumerator explodestart()
    {
        yield return new WaitForSeconds(3);
        sfx = GameObject.Instantiate(explsound, soundloc.transform);
        sfx.transform.localPosition = soundloc.transform.localPosition;
        sfx.SetActive(true);
        explosion.Play();
        for (int i = 0; i < ethanppl.Count; i++)
        {
            bool check = ethanppl[i].isondangerval();
            Debug.Log(i + " - " + check);
            if (check)
            {
                ethanppl[i].instantkill();
            }
        }
        gamenotif.reduceenemies();
        StartCoroutine(explosiondur());
    }
    IEnumerator explosiondur()
    {
        yield return new WaitForSeconds(0.25f);

        GameObject.Destroy(this.ethanobjai);
    }
    public void blowaway()
    {


        rb.isKinematic = false;
        rb.useGravity = false;
        Vector3 force = new Vector3(destobj.transform.forward.x * 1500, 0, destobj.transform.forward.z * 1500);
        rb.AddForce(force);

        StartCoroutine(sinemar());
    }
    IEnumerator sinemar()
    {
        yield return new WaitForSeconds(1.0f);
        rb.useGravity = true;
        rb.isKinematic = true;
    }
}
