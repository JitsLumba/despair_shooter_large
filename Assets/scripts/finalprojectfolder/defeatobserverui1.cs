using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class defeatobserverui1 : MonoBehaviour
{
    
    [SerializeField] private defeatviewhandler dev;
    void Awake()
    {

        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateui);
    }
    void onDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_GAME_NOTIF);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateui(Parameters param)
    {
        bool check = param.GetBoolExtra("lose1", false);
        string enemy = param.GetIntExtra("enemiesdestruct", -1) + "";
        string grade = param.GetStringExtra("grader", "Z");
        Debug.Log("Woweeee");
        if (check)
        {
           
            dev.writeon(enemy, grade);
            ViewHandler.Instance.Show(ViewNames.defeat_ui1);
            //GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;



            StartCoroutine(pausemes());

        }
    }
    IEnumerator pausemes()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Worried");
        Time.timeScale = 1.0f;


    }
}
