using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defeatobserverui2 : MonoBehaviour
{
    [SerializeField] private Text enemiesslain, gradetxt;
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
        bool check = param.GetBoolExtra("lose2", false);
        string enemy = param.GetIntExtra("enemiesdestruct", -1) + "";
        string grade = param.GetStringExtra("grader", "Z");
        if (check)
        {
            enemiesslain.text = enemy;
            gradetxt.text = grade;
            ViewHandler.Instance.Show(ViewNames.defeat_ui2);
        }
    }
}
