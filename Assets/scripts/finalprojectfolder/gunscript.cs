using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    // Start is called before the first frame update
    private int elecbullets = 20;
    private float damage = 10.0f;
    private bool canselect = true;
    private float range = 100.0f;
    private bool cansound = true;
    private bool canshoot = true;
    private bool canchoose = true;
    //[SerializeField] private ethanai aiethan;
    [SerializeField] private Camera fpscam;
    [SerializeField] private GameObject breaksound;
    [SerializeField] private GameObject electricsound, electricchoose, breakchoose, blowchoose, blowsound;
    [SerializeField] private gamenotifier gamenotif;
    [SerializeField] private GameObject soundloc;
    [SerializeField] private List<GameObject> soundeffectlist;
    [SerializeField] private bool elecbuletenabled, knockbackenabled;
    private Quaternion rotation;
    private Vector3 direction;
    private Quaternion rotater;
    private GameObject soundrep;
    private string bullet = "break";
    private GameObject selectedsound;
    void Start()
    {
        Debug.Log("break");
        selectedsound = breaksound;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.localPosition;
        
        //Debug.Log(fpscam.transform.eulerAngles.x);
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("Hello shoot");
            shoot();
        }
        if (Input.GetKey(KeyCode.Alpha3) && canchoose && knockbackenabled)
        {
            canchoose = false;
            bullet = "Knockback";
            selectbullet();
            
        }
        if (Input.GetKey(KeyCode.Alpha2) && canchoose && elecbuletenabled)
        {
            canchoose = false;
            bullet = "Elec";
            selectbullet();
            
        }
        if (Input.GetKey(KeyCode.Alpha1) && canchoose)
        {
            canchoose = false;
            bullet = "Break";
            selectbullet();
          
        }
    }
    void selectbullet()
    {
        float rcolor = 0.0f, gcolor = 0.0f, bcolor = 1.0f, acolor = 1.0f;
        GameObject choosebulletsound = this.breakchoose;
        if (bullet == "Break")
        {
            selectedsound = this.breaksound;
            choosebulletsound = this.breakchoose;
        }
        else if (bullet == "Elec")
        {
            selectedsound = this.electricsound;
            choosebulletsound = this.electricchoose;
            rcolor = 1.0f;
            gcolor = 0.92f;
            bcolor = 0.016f;
            acolor = 1.0f;
        }
        else if (bullet == "Knockback")
        {
            selectedsound = this.blowsound;
            choosebulletsound = this.blowchoose;
            rcolor = 0.0f;
            gcolor = 1.0f;
            bcolor = 1.0f;
            acolor = 1.0f;
        }
        soundrep = GameObject.Instantiate<GameObject>(choosebulletsound, soundloc.transform);
        soundrep.transform.localPosition = soundloc.transform.localPosition;
        soundrep.SetActive(true);
        gamenotif.changebullet(bullet, rcolor, gcolor, bcolor, acolor, elecbullets);

        StartCoroutine(cansoundchooseagain());
    }
    void shoot()
    {
        bool cantry = true;
        if (cansound)
        {
            
            if ((bullet == "Elec" && elecbullets != 0))
            {
                elecbullets = elecbullets - 1;
                gamenotif.reduceelecbullet();
            }
           else if ((bullet == "Elec" && elecbullets == 0))
            {
                cantry = false;
            }
           if (cantry)
            {
                Debug.Log("Boom");
                cansound = false;
                soundrep = GameObject.Instantiate<GameObject>(this.selectedsound, soundloc.transform);
                soundrep.transform.localPosition = soundloc.transform.localPosition;
                soundrep.SetActive(true);
                soundeffectlist.Add(soundrep);
                StartCoroutine(cansoundagain());
            }
            
            
        }
        
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range) && canshoot)
        {
            
            canshoot = false;
            
            //Debug.Log(hit.transform.name);
            //aiethan.receivdamage();
            StartCoroutine(example());
            //RotateMouseDir(gameObject, hit.point);
        }
        else
        {
            //RotateMouseDir(gameObject, hit.point);
        }

    }
    IEnumerator example()
    {
        yield return new WaitForSeconds(1);
        canshoot = true;
    }
    void RotateMouseDir(GameObject obj, Vector3 dest)
    {
        direction = dest - obj.transform.position;
        rotater = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotater, 1);
    }
    public Quaternion getRotater()
    {
        return rotater;
    }
    IEnumerator cansoundagain()
    {
        
        yield return new WaitForSeconds(1);
        cansound = true;
        Debug.Log("Sound");
    }
    IEnumerator cansoundchooseagain()
    {
        yield return new WaitForSeconds(1);
        canchoose = true;
    }
}
