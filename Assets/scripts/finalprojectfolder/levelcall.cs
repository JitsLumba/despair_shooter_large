using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcall : MonoBehaviour
{

    [SerializeField] private int levelnum;
    // Start is called before the first frame update
    void Start()
    {
        nextlevelmanager.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callnextlvl()
    {
        Time.timeScale = 1.0f;
        nextlevelmanager.Instance.loadlevel(levelnum);
    }
    
}
