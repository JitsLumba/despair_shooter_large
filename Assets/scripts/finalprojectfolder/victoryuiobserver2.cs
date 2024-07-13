using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victoryuiobserver2 : MonoBehaviour
{

    //[SerializeField] private Text enemiesslain, gradetxt;
    void Awake()
    {

        EventBroadcaster.Instance.AddObserver(EventNames.ON_GAME_NOTIF, updateui);
        nextlevelmanager.Initialize();
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
        bool check = param.GetBoolExtra("win2", false);
        Debug.Log("check " + check);
        string enemy = param.GetIntExtra("enemiesdestruct", -1) + "";
        string grade = param.GetStringExtra("grader", "Z");
        if (check)
        {
            nextlevelmanager.Instance.loadlevel(3);
            
            ViewHandler.Instance.Show(ViewNames.victory_ui2);
        }
    }
}
