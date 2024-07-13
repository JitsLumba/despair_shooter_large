using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryviewhandler : View
{
    [SerializeField] private Text enemiestxt, gradetext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void writeon(string enemies, string grade)
    {
        //Debug.Log("Sooooo eyyy");
        enemiestxt.text = enemies;
        gradetext.text = grade;
        nextlevelmanager.Instance.sane(1);
        //StartCoroutine(pausemes());
    }
}
