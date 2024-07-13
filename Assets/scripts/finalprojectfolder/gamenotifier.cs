using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamenotifier : MonoBehaviour
{
    // Start is called before the first frame update
    private bool notpaused = true, cango = true;
    private float hp = 10, maxhp = 10, hpratio = 1.0f;
    [SerializeField] string level;
    private int enemiesdestroyed = 0;
    [SerializeField] private int enemiesleft;
    //[SerializeField] private Text txt;
    private string elecname = "Elec - ";
    private int electricbullet = 20;
    [SerializeField] private string enemiesleftword = "";
    private string endtitle = "none";
    private string bullettext = "Break", bulletname = "Break";
    private bool canshow = false;
    private float rcolor = 0.0f, gcolor = 0.0f, bcolor = 1.0f, acolor = 1.0f;
    private bool won1 = false, lost1 = false, won2 = false, won3 = false, lost2 = false, lost3 = false;
    private string grade = "S";
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            txt.color = new Color(0, 0, 1, 1);
        }*/
        
    }
    public void canshowendscreen()
    {
        canshow = true;
    }
    public void gotexploded()
    {
        hp = hp - 5;
        hpratio = hp / maxhp;
        updatetest();
    }
    public void changebullet(string bull)
    {
        if (bull == "Break")
        {
            bullettext = "break";
        }
    }
    public void changebullet(string name, float rcolor, float gcolor, float bcolor, float acolor, int elecbullet)
    {
        bulletname = name;
        if (name == "Elec")
        {
            bullettext = name + " - " + elecbullet;
        }
        else
        {
            bullettext = name;
        }
        this.rcolor = rcolor;
        this.gcolor = gcolor;
        this.bcolor = bcolor;
        this.acolor = acolor;
        updatetest();
    }
    public void reduceelecbullet()
    {
        Debug.Log("Electric");
        electricbullet = electricbullet - 1;
        bullettext = bulletname + " - " + electricbullet;
        
        updatetest();
    }
    
    public void reduceenemies()
    {
        enemiesleft = enemiesleft - 1;
        enemiesleftword = "" + enemiesleft + " left";
        enemiesdestroyed = enemiesdestroyed + 1;
        if (enemiesleft == 0)
        {
            if (level == "lvl1")
            {
                won1 = true;
            }
            else if (level == "lvl2")
            {
                won2 = true;
            }
            else if (level == "lvl3")
            {
                won3 = true;
            }
        }
        updatetest();
    }
    public void reduceplayerhp()
    {
        hp = hp - 1;
        hpratio = hp / maxhp;
        if ((hp == 0 && enemiesleft == 0) || hp == 0)
        {
            if (level == "lvl1")
            {
                lost1 = true;
            }
            else if (level == "lvl2")
            {
                lost2 = true;
            }
            else if (level == "lvl3")
            {
                lost3 = true;
            }
        }
        {
            
        }
        updatetest();
    }
    void updatetest()
    {
        Parameters param = new Parameters();
        param.PutExtra("hpnum", hpratio);
        param.PutExtra("bullettext", bullettext);
        param.PutExtra("enemiesleft", enemiesleftword);
        param.PutExtra("rcolor", rcolor);
        param.PutExtra("gcolor", gcolor);
        param.PutExtra("bcolor", bcolor);
        param.PutExtra("acolor", acolor);
        param.PutExtra("win1", won1);
        param.PutExtra("win2", won2);
        param.PutExtra("win3", won3);
        param.PutExtra("lose1", lost1);
        param.PutExtra("lose2", lost2);
        param.PutExtra("lose3", lost3);
        param.PutExtra("enemiesdestruct", enemiesdestroyed);
        param.PutExtra("grader", grade);
        EventBroadcaster.Instance.PostEvent(EventNames.ON_GAME_NOTIF, param);
    }
    IEnumerator pauseinterval()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Can we go");
        cango = true;
    }
}
