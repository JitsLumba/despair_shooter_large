using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ethanai : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float navermeshspeed;
    [SerializeField] private fpshealth fpshealther;
    private bool canelec, isondanger = false;
    [SerializeField] private string ethantype;
    private string poolison;
    // Start is called before the first frame update
    [SerializeField] private int hp = 3;
    private bool move = false;
    private bool isnotattacking = true;
    private bool candmg = false;
    private const string ethanrun = "ethanmove";
    [SerializeField] private float startx, endx, startz, endz;
    [SerializeField] private Transform destobj;
    [SerializeField] private NavMeshAgent nvmeshagent;
    [SerializeField] private Animator aianimator;
    [SerializeField] private Transform ethanpos;
    [SerializeField] private clearpartoflvlx cplx;
    [SerializeField] private gamenotifier gamenotif;
    [SerializeField] private GameObject soundloc, punchsound;
    [SerializeField] private GameObject ethanobjai;
    private GameObject sfx;
    void Start()
    {
        //StartCoroutine(waiter());
        nvmeshagent.enabled = false;
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
        //Debug.Log("x: " + distx + " y: " + disty + " z: " + distz);
        if ((fpsx >= startx && fpsx <= endx) && (fpsz >= startz && fpsz <= endz) && !(nvmeshagent.enabled))
        {
            move = true;
            nvmeshagent.enabled = true;
        }
        if (move)
        {
            setDestination();
            this.aianimator.SetInteger(ethanrun, 1);
        }

        if (distz <= 3.5f && distx <= 3.5f && isnotattacking && move)
        {
            nvmeshagent.speed = 0.0f;
            move = false;
            isnotattacking = false;
            this.aianimator.SetInteger(ethanrun, 2);
            StartCoroutine(attackinterval());
            
            //Debug.Log("Attacking");
        }
        
        else
        {
            if (isnotattacking)
            {
                
                nvmeshagent.speed = navermeshspeed;
            }
        }
        
    }
    public void receivdamage()
    {
        if (ethantype == "normal")
        {
            hp = hp - 1;

        }

        checkhp();

    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        move = true;
        Debug.Log("3 seconds");
        nvmeshagent.enabled = true;
        
        
    }
    IEnumerator attackinterval()
    {
        yield return new WaitForSeconds(0.75f);
        this.aianimator.SetInteger(ethanrun, 0);
        candmg = true;
        StartCoroutine(damagestop());
    }
    IEnumerator damagestop()
    {
        yield return new WaitForSeconds(0.5f);
        candmg = false;
        
        StartCoroutine(breatheratt());
    }
    IEnumerator breatheratt()
    {
        yield return new WaitForSeconds(5);
        this.candmg = false;
        //Debug.Log("Can attack again");
        this.isnotattacking = true;
        move = true;
    }
    void setDestination()
    {
        Vector3 targetVector = destobj.transform.position;
        nvmeshagent.SetDestination(targetVector);
    }
    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name.Contains("Water"))
        {
            poolison = col.gameObject.name;
            canelec = true;
        }
       


    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name.Contains("Water"))
        {
            poolison = "";
            //Debug.Log("Swim");
            canelec = false;
        }
    }
    public void instantkill()
    {
        hp = 0;
        checkhp();
    }
    public void electrocute()
    {
        if (ethantype != "explode")
        {
            if (canelec)
            {
                // Debug.Log("Watered");
                instantkill();
            }
            else
            {
                hp = hp - 1;
                checkhp();
            }
        }

        
    }
    void checkhp()
    {
        if (hp == 0)
        {

            //Debug.Log("Ethan is dead");
            GameObject.Destroy(ethanobjai);
            gamenotif.reduceenemies();
            cplx.reduceenemy();
        }
    }
    public bool canbeelec()
    {
        return this.canelec;
    }
    public string poolisonname()
    {
        return poolison;
    }
    public bool candmgval()
    {
        return this.candmg;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name.Contains("Mega") && candmg)
        {
            bool canbedmger = fpshealther.canbedmgedval();
            if (canbedmger)
            {
                Debug.Log("HERE IS THE REDUCE DAMAGE");
                fpshealther.reducehp();
                gamenotif.reduceplayerhp();
                sfx = GameObject.Instantiate(this.punchsound, soundloc.transform);
                sfx.transform.localPosition = soundloc.transform.localPosition;
                sfx.SetActive(true);
            }

            //fpshealther.reducehp();
            //Debug.Log("Hiro");
        }
        else if (col.gameObject.name.Contains("Radius"))
        {
            
            isondanger = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name.Contains("Mega"))
        {
            // Debug.Log("Hire");
        }
        else if (col.gameObject.name.Contains("Radius"))
        {
            isondanger = false;
        }
    }
    IEnumerator sinemar()
    {
        yield return new WaitForSeconds(1.0f);
        rb.useGravity = true;
        rb.isKinematic = true;
    }
    public void blowaway()
    {
        Debug.Log("Blog2");
        
        rb.isKinematic = false;
        rb.useGravity = false;
        Vector3 force = new Vector3(destobj.transform.forward.x * 1500, 0, destobj.transform.forward.z * 1500);
        rb.AddForce(force);
        Debug.Log(destobj.transform.forward.x + " " + destobj.transform.forward.z);
        StartCoroutine(sinemar());
    }
    /*public void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Helo");
        if (col.gameObject.name.Contains("Mega"))
        {
            Debug.Log("Hi");
        }
        
    }
    */
    public bool isondangerval()
    {
        return this.isondanger;
    }
}
