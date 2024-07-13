using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class defeatviewhandler : View
{
    [SerializeField] private Text enemiestxt, gradetext;
    // Start is called before the first frame update
    void Start()
    {
        nextlevelmanager.Initialize();
        
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
    IEnumerator pausemes()
    {
        yield return new WaitForSeconds(0.25f);
        Time.timeScale = 0.0f;
        Debug.Log("Worried");
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
    }
}
